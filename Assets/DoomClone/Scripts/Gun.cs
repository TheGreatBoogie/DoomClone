using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{        
    private InputManager _inputManager;
    public EnemyManager enemyManager;
    private BoxCollider gunTrigger;
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;
    public Collider[] enemyColliders;

    
    public float range = 20f;
    public float verticalRange = 20f;
    public float bigDamage = 2f;
    public float smallDamage = 1f;
    public float gunShotRadius = 35f;

    public int maxAmmo = 100;
    private int _ammo = 10;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        _inputManager.fire.performed += Fire;
    }

    private void OnDisable()
    {
        _inputManager.fire.performed -= Fire;
    }
    
    private void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy) enemyManager.AddEnemy(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy) enemyManager.RemoveEnemy(enemy);
    }
    
    private void Fire(InputAction.CallbackContext context)
    {
        if (_ammo >= 0)
        {
            _ammo--;
            // Simulate gunshot radius
            enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);
            // Alert enemy
            foreach (var enemyColider in enemyColliders)
            {
                enemyColider.GetComponent<EnemyAwarness>().AggroSound();
            }

            DamageEnemies();
            PlayAudio();
        }


    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        _ammo += amount;
        Destroy(pickup);

        if (_ammo > maxAmmo) _ammo = maxAmmo;
        Debug.Log("Ammo given");

    }

    private void PlayAudio()
    {
        // Todo : Implement audio
    }

    private void DamageEnemies()
    {
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            // Get enemy direction
            Vector3 dir = (enemy.transform.position - transform.position);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, range * 1.05f, raycastLayerMask))
            {
                Debug.DrawRay(transform.position, dir, Color.blue, 5f);
                if (hit.transform.gameObject == enemy.transform.gameObject)
                {
                    // Range Test
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);
                    
                    if (dist < range * 0.5f)
                    {
                        // Take Damage
                        enemy.TakeDamage(bigDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(smallDamage);
                    }
                }
            }
            
        }
    }
}
