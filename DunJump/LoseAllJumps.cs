using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseAllJumps : MonoBehaviour {

    PlayerController PlayerJumps;


	void Start () {
       PlayerJumps = GetComponent<PlayerController>();

        PlayerJumps.count = -1;
	}
	
	
	public void RegainJumps()
    {
        PlayerJumps.count = 0;
    }
}
