using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 walkDirection = Vector2.left;

    private void Update()
    {
        // Move the enemy in the specified direction
        transform.Translate(walkDirection * speed * Time.deltaTime);
    }
}
