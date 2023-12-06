using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Vector3 direction = Vector3.right;

    private void Start()
    {
        // Set the projectile to destroy itself after a certain time to prevent memory leaks
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        // Move the projectile forward
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction == Vector3.left)
        {
            // Assuming the projectile sprite initially faces right in local space
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Reset the scale if the direction is right
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }
}
