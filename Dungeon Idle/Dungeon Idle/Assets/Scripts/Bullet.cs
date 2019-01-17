using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public float speed = 2f;

    public int damage = 1;

    enum FacingDirection {
        UP = 270,
        DOWN = 90,
        LEFT = 180,
        RIGHT = 0
    }

    public void Seek(Transform _target) {
        target = _target;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        LookAt2D(target, 17f, FacingDirection.RIGHT);
    }

    void LookAt2D(Transform theTarget, float theSpeed, FacingDirection facing) {
        Vector3 vectorToTarget = theTarget.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        angle -= (float)facing;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * theSpeed);
    }
    void HitTarget() {
        Damage(target);
        Destroy(gameObject);
    }
     void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null) {
            e.TakeDamage(damage);
        }
    }
}
