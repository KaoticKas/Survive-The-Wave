using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTxt : MonoBehaviour
{
    WaveManager waveNumber;

    public Text wave;

    private int currentWave;

    // Update is called once per frame
    void Update()
    {
        waveNumber = GameObject.FindObjectOfType<WaveManager>();

        currentWave = waveNumber.waveNum + 1;
        wave.text = "Wave" + "\r\n" + currentWave.ToString();
    }
}
