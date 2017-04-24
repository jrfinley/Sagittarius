using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatCard : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Text healthText;
    public Image icon;
    public Image healthBar;
    int health = 100;
    int maxHealth = 100;
    bool isDead = false;

    public void CreateCombatCard(BaseCharacter character) //Players
    {
        nameText.text = character.Name;
        levelText.text = "Level: " + character.Level.ToString();
        int charHealth = character.Health;
        int charMaxHealth = character.MaxHealth;
        health = charHealth;
        maxHealth = charMaxHealth;
        healthText.text = charHealth.ToString() + "/" + charMaxHealth.ToString();
        healthBar.fillAmount = (float)charHealth / (float)charMaxHealth;
        //icon.sprite = character.GetIcon();
    }

    public void AlterHealth(int _health)
    {
        if (isDead) //Remove if we add some sort of "revive" feature
            return;

        health += _health;
        if (health >= maxHealth)
            health = maxHealth;
        if(health <= 0)
        {
            isDead = true;
            health = 0;
            icon.color = new Color32(95, 95, 95, 255);
        }
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }  
    public void CreateCombatCard(BaseMonster monster) //Enemies
    {

    }
   
}
