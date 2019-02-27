using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{   [SerializeField]
    private GameObject target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CoinMagnet");
    }

    // Update is called once per frame
    void Update() {
        

        Vector2 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            PlayerStats.gold += 100 * PlayerStats.cityGold;
            Destroy(gameObject);
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
}
