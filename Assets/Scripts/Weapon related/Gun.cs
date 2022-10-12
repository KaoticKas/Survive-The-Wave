using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool shooting;
    public Bullet projectile;
    public float projecticlespeed;

    public float fireRate;
    private float timeTillNextShot;

    private bool reloading;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1;

    public Transform ExitPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        isFiring();

        if (shooting == true && reloading == false)
        {
            timeTillNextShot -= Time.deltaTime;
            if (timeTillNextShot <= 0)
            {
                timeTillNextShot = fireRate;

                if (currentAmmo <= 0)
                {
                    reloading = true;
                }

                else
                {
                    if (reloading == true)
                    {
                        return;
                    }

                     Bullet newBullet = Instantiate(projectile, ExitPoint.position, ExitPoint.rotation) as Bullet;
 
                    newBullet.moveSpeed = projecticlespeed;
                    currentAmmo = currentAmmo - 1;

                }
             
            }

        }
    }

    void isFiring()
    {
 
        if (Input.GetMouseButtonDown(0)&& !reloading)
        {
            shooting = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(reload());
            return;
        }
    }
    IEnumerator reload()
    {
        Debug.Log("Reloading in progress");
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        reloading = false;
    }
}
