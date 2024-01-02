using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Character
{
    private int mana;

    public Healer(int maxHealth, int maxDamage, int minDamage, int mana)
        : base (maxHealth, maxDamage, minDamage)
    {
        this.mana = mana;
    }

    public void SmallHeal(Character target) {
        if (mana >= 5) {
            target.GetHealing(15);
        this.mana -= 5;
        }
    }

    public void BigHeal(Character target) {
        if (mana >= 10) {
            target.GetHealing(25);
        this.mana -= 10;
        }
    }

    public void RestoreMana(int mana) {
        this.mana += mana;
    }
}
