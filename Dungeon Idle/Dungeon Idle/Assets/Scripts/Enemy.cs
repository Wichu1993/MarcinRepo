using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyDamage = 10f;

    public float startSpeed = 1f;
    public float startHealth = 10f;

    private float health;
    private float speed;

    // public GameObject deathEffect; // efekt po śmierci
    public GameObject coin; //spawn cointa po śmierci

    public Image healthBar;// paski życia nad enemy

    private bool isDead = false;

    private void Start() {
        speed = startSpeed;
        health = startHealth;
    }

    private void Update() {
        transform.Translate(Vector2.left * speed * (Time.time / 10 + 1) * Time.deltaTime);
    }

    public void TakeDamage(float amount) {
        amount = PlayerStats.damage =
            PlayerStats.baseDamage * (
            PlayerStats.cityDamage *
            PlayerStats.heroDamage *
            PlayerStats.rebirthDamage *
            PlayerStats.perkDamage);
        health -= amount;
        healthBar.fillAmount = health / startHealth; 

        if (health <= 0 && !isDead)
            Die();
    }

    void Die() {
        isDead = true;
        int rand = Random.Range(1, 5);
        PlayerStats.exp += rand;
        Instantiate(coin, transform.position, Quaternion.identity);
        
        

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Kolizja");
        if (col.gameObject.tag != "Enemy") {
            PlayerStats.hp -= enemyDamage;
            speed = 0f;
            Destroy(gameObject);
        }
    }
        
}

