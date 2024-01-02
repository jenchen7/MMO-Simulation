using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class Level2Sim : MonoBehaviour
{
    public Text scoreText;

    public GameObject button;

    public Boss boss;
    public Character warrior;
    public Character rogue;
    public Character mage;
    public Character druid;
    public Healer priest;

    int totalDamagePlayers;
    int totalDamageBoss;

    public int timeStepCounter;
    FileWriter writer;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();

        button = GameObject.Find("Button1");
        button.SetActive(false);

        timeStepCounter = 0;

        boss = new Boss(5000, 5, 21, 40, 51);
        warrior = new Character(3000, 5, 11);
        rogue = new Character(1500, 15, 26);
        mage = new Character(1000, 5, 31);
        druid = new Character(1250, 5, 16);
        priest = new Healer(900, 0, 0, 1000);

        writer = new FileWriter(@"level2.csv");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!CheckForDeath()) {
            Simulation();
        }
        else {
            EndSim();
        }
        
        // display on screen
        scoreText.text = boss.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ boss.GetTotalDamage().ToString()
        +"\n"+ warrior.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ warrior.GetTotalDamage().ToString()
        +"\n"+ rogue.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ rogue.GetTotalDamage().ToString()
        +"\n"+ mage.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ mage.GetTotalDamage().ToString()
        +"\n"+ druid.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ druid.GetTotalDamage().ToString()
        +"\n"+ priest.GetCurrentHealth().ToString() +"\t\t\t\t\t\t\t\t"+ priest.GetTotalDamage().ToString();

    }

    // runs once per time step
    void Simulation()
    {
        // boss's attacks
        totalDamageBoss += boss.Attack(rogue) + boss.Attack(mage) +  boss.Attack(druid) + boss.Attack(priest) + boss.AttackTank(warrior);

        // party's attacks
        totalDamagePlayers += warrior.Attack(boss) + rogue.Attack(boss) + mage.Attack(boss) + druid.Attack(boss);

        // healer stuff, randomly selects a target then heals tank
        SmallHeal();
        priest.BigHeal(warrior);
        priest.RestoreMana(3);

        // random heal if tank is at <=1500 health
        if (warrior.GetCurrentHealth() <= 1500) {
            if (Random.Range(0,2) == 0) {
                SmallHeal();
                priest.RestoreMana(5);
            }
            else {
                priest.BigHeal(warrior);
                priest.RestoreMana(10);
            }
        }

        timeStepCounter++;
        WriteTimestepToFile(); // write to file after each time step
    }

    // ends simulation upon character death
    void EndSim() {
        button.SetActive(true);

        // checks max damage
        if (totalDamageBoss > DisplayScores.maxDamageBoss2) {
            DisplayScores.maxDamageBoss2 = totalDamageBoss;
        }
        if (totalDamagePlayers > DisplayScores.maxDamagePlayers2) {
            DisplayScores.maxDamagePlayers2 = totalDamagePlayers;
        }
    }

    void WriteTimestepToFile() {
        string row = timeStepCounter +","+ boss.GetCurrentHealth() +","+ warrior.GetCurrentHealth() +","+ rogue.GetCurrentHealth() 
        +","+ mage.GetCurrentHealth() +","+ druid.GetCurrentHealth() +","+ priest.GetCurrentHealth();

        writer.Write(row);

    }
    
    bool CheckForDeath() {
        return (boss.isDead || warrior.isDead || rogue.isDead || mage.isDead || druid.isDead || priest.isDead);
    }

    void SmallHeal() {
        int target = Random.Range(0, 6);
        if (target == 0) {
            priest.SmallHeal(rogue);
        }
        else if (target == 1) {
            priest.SmallHeal(mage);
        }
        else if (target == 2) {
            priest.SmallHeal(druid);
        }
        else {
            priest.SmallHeal(priest);
        }
    }

}
