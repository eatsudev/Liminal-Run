using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        Health health = collider.GetComponent<Health>();

        
        if (health != null && !collider.CompareTag("Enemy"))
        {
            
            health.Damage(damage);
        }
    }
}
