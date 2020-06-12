using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RobotEnemyShooting : NetworkBehaviour {

    HealthScript PlayerHealth;
    public int minWeaponDamage = 25;
    public int maxWeaponDamage = 50;


	void Start () {
        PlayerHealth = FindObjectOfType<HealthScript>();
	
	}

	void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.CurrentHealth -= Random.Range(minWeaponDamage, maxWeaponDamage + 1);
            PlayerHealth.SetHealthUI();
        }
        }
	
}

