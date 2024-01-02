using UnityEngine;

public class Boss : Character
{
    private int minDamageTank;
    private int maxDamageTank;

    public Boss(int maxHealth, int maxDamage, int minDamage, int maxDamageT, int minDamageT)
        : base (maxHealth, maxDamage, minDamage)
    {
        this.minDamageTank = minDamageT;
        this.maxDamageTank = maxDamageT;
    }

    public int AttackTank(Character target) {
        int dmg = Random.Range(minDamageTank, maxDamageTank);
        totalDamageDealt += dmg;
        target.TakeDamage(dmg);
        return dmg;
    }

}
