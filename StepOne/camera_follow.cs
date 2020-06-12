using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour {

    Vector2 velocity;
    
	public GameObject player;
    public bool bounds;
    public float smoothTimeX, smoothTimeY;
    public Vector3 minBound, maxBound;
	
	// Update is called once per frame
	void Update () {
		//ici on rend le mouvement de la caméra fluide
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);		
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        this.transform.position = new Vector3(posX, posY, this.transform.position.z);

        if(bounds)
        {
			this.transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, minBound.x, maxBound.x),
				//les "Clamp" empeche la camera de dépasser certaines valeurs
				Mathf.Clamp (this.transform.position.y, minBound.y, maxBound.y),										
				Mathf.Clamp (this.transform.position.z, minBound.z, maxBound.z));
        }
    }
}
