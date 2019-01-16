using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 1f;
    public float startHealth = 10f;

    private float health;
    private float speed;

   // public GameObject deathEffect; // efekt po śmierci

    public Image healthBar;// paski życia nad postacią

    private bool isDead = false;

    private void Start() {
        speed = startSpeed;
        health = startHealth;
    }

    private void Update() {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    public void TakeDamage(float amount) {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
            Die();
    }

    void Die() {
        isDead = true;

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        Destroy(gameObject);
    }
}

