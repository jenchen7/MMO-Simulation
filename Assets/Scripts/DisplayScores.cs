using UnityEngine;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{
    public Text scoreText;
    public static int maxDamagePlayers1;
    public static int maxDamageBoss1;
    public static int maxDamagePlayers2;
    public static int maxDamageBoss2;
    public static int maxDamagePlayers3;
    public static int maxDamageBoss3;
 
    void Start () {
        scoreText = GetComponent<Text>();
    }
 
    void Update () {
        scoreText.text = maxDamagePlayers1.ToString() +"\t\t\t\t\t\t\t\t"+ maxDamageBoss1.ToString()
        +"\n\n"+ maxDamagePlayers2.ToString() +"\t\t\t\t\t\t\t\t"+ maxDamageBoss2.ToString()
        +"\n\n"+ maxDamagePlayers3.ToString() +"\t\t\t\t\t\t\t\t"+ maxDamageBoss3.ToString();
    }

}
