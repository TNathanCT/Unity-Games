using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedRunScript : MonoBehaviour {

    private float speed = 0.5f;
    public float coefficient = 0.1f;
    public float offset = 5;

    public Vector3 direction = new Vector3(1, 0, 0);
    private Vector2 movement;

    public GameObject Tutorial;
    public float Timey;

    float startTime;

    // Use this for initialization
    void Start () {

        startTime = Time.time;
        Timey = 3;

    }
	
	// Update is called once per frame
	void Update () {

        var deltaTime = Time.time - startTime;

        speed = coefficient * deltaTime + offset;
        transform.Translate(direction * speed * Time.deltaTime);

        Timey -= Time.deltaTime;
        if(Timey <= 0) {
            Tutorial.SetActive(false);

        }
    }

}
