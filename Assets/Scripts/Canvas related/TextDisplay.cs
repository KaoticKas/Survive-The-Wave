using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text healthText;

     Player player;

    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            healthText.text = "HEALTH: " + player.pHealth.ToString();
        }
        else
        {
            healthText.text = "HEALTH: 0";
        }
    }
}
