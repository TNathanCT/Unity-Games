using UnityEngine;
using System.Collections;

public class ArrowMovementVertical : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
