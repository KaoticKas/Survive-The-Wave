using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 5;

    public float bulletLife = 5;

    public int damage = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        TimeToDecay();
    }
    void OnTriggerEnter(Collider hit)
    {
        Enemy enemy = hit.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    
    }
    void TimeToDecay()
    {
        if (bulletLife <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            bulletLife -= Time.deltaTime;
        }
    }
}
