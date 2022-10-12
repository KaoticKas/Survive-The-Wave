using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Text ammoText;

    Gun gun;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            gun = GameObject.Find("Player").GetComponentInChildren<Gun>();
            ammoText.text = "AMMO:" + gun.currentAmmo.ToString() + "/" + gun.maxAmmo.ToString();
        }
    }
}
