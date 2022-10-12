using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyDamage = 20;
    public float speed;
    public int points = 10;


    float immuneTime = 0;
    float nextDmg = 1;

    public Transform target;

    Vector3[] path;
    int targetIndex;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {


        if (GameObject.Find("Player") != null)
        {

            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }

    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    targetIndex = 0;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;

        }
    }

 
    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
    public void OnTriggerStay(Collider _Collision)
    {
        if (immuneTime <= 0 && _Collision.gameObject.tag == "Player")
        {

            _Collision.gameObject.GetComponent<Player>().RecieveDamage(enemyDamage);
            immuneTime = nextDmg;
        }
        else
        {
            immuneTime -= Time.deltaTime;
        }
    }

    void Die()
    {
        ScoreText.scoreVal = ScoreText.scoreVal + points;
        Destroy(gameObject);
    }
}