using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameObject deathVFX;
    //[SerializeField] AudioClip deathSFX;

    Collider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    public void DealDamage(int damage)
    {
        health = health-damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX){ return; }
        Vector2 position = (Vector2)transform.position + myCollider.offset;
        GameObject deathVFXObject = Instantiate(deathVFX, position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
