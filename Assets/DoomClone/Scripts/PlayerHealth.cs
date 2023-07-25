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
        armor = maxArmor;
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
}
