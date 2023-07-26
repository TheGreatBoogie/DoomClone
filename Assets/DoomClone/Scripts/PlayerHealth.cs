using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int maxArmor;
    private int health;
    private int armor;
    
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DamagePlayer(50);
            Debug.Log("Player Damaged");
        }
    }

    private void DamagePlayer(int damage)
    {
        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            } else if (damage > armor)
            {
                int remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Debug.Log("Player id Dead");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void GiveHealth(int healthAmount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += healthAmount;
            Destroy(pickup);
            Debug.Log("Health Given");
        }

        if (health > maxHealth) health = maxHealth;
    }

    public void GiveArmor(int armorAmount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            armor += armorAmount;
            Destroy(pickup);
            Debug.Log("Armor Given");
        }

        if (armor > maxArmor) armor = maxArmor;
    }
    
}
