/*using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
  
    public LevelManager LevelManager;

    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManager.RespawnPlayer();
        }

    }
}
*/