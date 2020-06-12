using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
	public CharacterControls player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    private float respawnDelay = 3f;
    private bool gravityStore;
    private GameObject cloneParticle;
    public float respawnEffect = 3;
	public HealthManager2 healthManager;
	private CameraSmooth cam;



    // Use this for initialization
    void Start ()
    {
		player = FindObjectOfType<CharacterControls>();
		healthManager = FindObjectOfType<HealthManager2> ();
		cam = FindObjectOfType<CameraSmooth> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    
	}

    public void RespawnPlayer()
    {
		StartCoroutine(RespawnPlayerCo());
    }

     public IEnumerator RespawnPlayerCo()
    {
		
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
		cam.isFollowing = false;
        gravityStore = player.GetComponent<Rigidbody2D>().isKinematic = true;
        //player.GetComponent<Rigidbody>().mass = 0f;
        //player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
		healthManager.FullHealth ();
		healthManager.isDead = false;
		cam.isFollowing = true;
        cloneParticle = Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation) as GameObject;
        Destroy(cloneParticle, respawnEffect);
    }
}
