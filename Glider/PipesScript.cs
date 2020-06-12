using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesScript : MonoBehaviour
{
    AudioSource audio;
    public Transform spawnCoinTransform;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GliderController>() != null)
        {
            GameManager.instance.Score();
            audio.Play();
        }
    }
}
