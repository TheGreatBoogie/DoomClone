using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    public GameObject GunHitEffect;
    public float enemyHealth = 2f;
    private Vector3 _playerPosition;
    
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Instantiate(GunHitEffect, transform.position, Camera.main.transform.rotation);
        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this); Destroy(gameObject);

        }
    }
    
}
