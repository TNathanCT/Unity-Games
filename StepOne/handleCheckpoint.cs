using UnityEngine;
using System.Collections;

public class handleCheckpoint : MonoBehaviour {

	//Ceci est le script qui gère l'animation du checkpoint et des éclairs

	public Sprite checkpointOn;
	public Object lightning;

	private bool crossed = false;

	void OnTriggerEnter2D()
	{
		if(!crossed)
		{
			Destroy(Instantiate(lightning,transform.position,Quaternion.identity),1f);
			Invoke("Invoked",1);
			crossed = true;
		}
	}

	void Invoked()
	{
		GetComponent<SpriteRenderer>().sprite = checkpointOn;
	}

	public void Spawn()
	{
		Destroy(Instantiate(lightning,transform.position,Quaternion.identity),2f);
	}
}
