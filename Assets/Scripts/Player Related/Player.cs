using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//
public class Player : MonoBehaviour
//
{
    public int pHealth = 100;
  //  


    public void RecieveDamage(int enemyDamage)
    {
        //
        pHealth -= enemyDamage;
        //
        if (pHealth <= 0)
        //
        {
            Die();
            //
        }
    }
    void Die()
        //
    {
        Debug.Log("You have died!");
        //
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        //
        Object.Destroy(gameObject);
        //
    }
}
