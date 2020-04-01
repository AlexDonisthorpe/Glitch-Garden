using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Parameters")]
    [SerializeField] float rotationSpeed = -360;
    [SerializeField] [Range(0, 5f)] float currentSpeed = 1f;
    [SerializeField] int projectileDamage = 1;
    
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime, Space.World);
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }

}
