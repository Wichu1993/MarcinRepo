using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float timeBtwSpawn = 1f;
    public GameObject[] enemies;
    public GameObject[] spawners;

    void Start()
    {
        
    }

    void Update() {
        Spawn();
    }

    private void Spawn() {
        int _rand = Random.Range(0, spawners.Length);
        int rand = Random.Range(0, enemies.Length);
        if (timeBtwSpawn <= 0f) {
            Instantiate(enemies[rand], spawners[_rand].transform.position, Quaternion.identity);
            timeBtwSpawn = 1f;
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
