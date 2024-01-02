using UnityEngine;

public class Character
{
    private int maxHealth = 0; // max health
    private int currentHealth = 0; // current health
    private int minDamage = 0; // minimum damage this chracter can deal
    private int maxDamage = 0; // maximum damage this chracter can deal

    protected int totalDamageDealt = 0;
    public bool isDead = false;


    public Character(int maxHealth, int maxDamage, int minDamage) {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.maxDamage = maxDamage;
        this.minDamage = minDamage;
        this.isDead = false;
    }

    public int Attack(Character target) {
        int dmg = Random.Range(minDamage, maxDamage);
        totalDamageDealt += dmg;
        target.TakeDamage(dmg);
        return dmg;
    }

    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        if (currentHealth <= 0) {
            isDead = true;
        }
    }

    public void GetHealing(int heal) {
        currentHealth += heal;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public int GetTotalDamage() {
        return totalDamageDealt;
    }

    
}
