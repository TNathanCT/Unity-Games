

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseGrapple : MonoBehaviour
{
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    public float climbSpeed = 3f;
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    private bool ropeAttached;
    private Vector2 playerPosition;
    private List<Vector2> ropePositions = new List<Vector2>();
    private float ropeMaxCastDistance = 20f;
    private Rigidbody2D ropeHingeAnchorRb;
    private bool distanceSet;
    private SpriteRenderer ropeHingeAnchorSprite;

    public bool TouchRock;

    void Awake()
    {
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    
    }



   



    void Update()
    {
        if (ropeAttached)
        {
            //The player will be moving towards the top of the rope.
            ropeJoint.distance -= Time.deltaTime * climbSpeed;
        }
            //This allows the game to calculate the position of the mouse in the 2D scene.  
            var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            //This will let the comp. know if the player is pointing behind, or in front of the character.
            var facingDirection = worldMousePosition - transform.position;
            var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
            if (aimAngle < 0f)
            {
                aimAngle = Mathf.PI * 2 + aimAngle;
            }
            //This allows the player to aim in a radius.
            var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
            //Around the player's current position.
            playerPosition = transform.position;
            UpdateRopePositions();
            HandleInput(aimDirection);
             }       

    


    private void HandleInput(Vector2 aimDirection)
    {
        //When we press on the mouse button
        if (Input.GetMouseButtonDown(0))
        {   
            //the ropeRenderer that is connected to the player will be enabled.
            ropeRenderer.enabled = true;
            //And will shoot out a sprite that will begin at the player's position, and go in the direction of the mouse,
            var hit = Physics2D.Raycast(playerPosition, aimDirection,ropeMaxCastDistance, ropeLayerMask);
            //Until it hits a gameobject with the tag 'Rocks', and that has a collider.
            if (hit.collider.tag == "Rocks" && hit.collider != null)
            {
                //Then, the boolen ropeAttached will be set to true,
                ropeAttached = true;
                if (!ropePositions.Contains(hit.point))
                {
                    //This adds force to the player. This will knock the player a little in the air, to give the sensation that he/she is jumping.
                    transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    //Activate the sprite of the hinge of the rope.
                    ropeHingeAnchorSprite.enabled = true;
                }
            }
            //if we click on a gameobject that doesn't have a 'Rocks' tag, nor a collider, then nothing happens.
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }

            
        }


        if (Input.GetMouseButtonUp(0))
        {

            ResetRope();

        }
    }

    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }



    private void UpdateRopePositions()
    {
        if (ropeAttached)
        {
            ropeRenderer.positionCount = ropePositions.Count + 1;

            for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
            {
                if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
                {
                    ropeRenderer.SetPosition(i, ropePositions[i]);

                    // Set the rope anchor to the 2nd to last rope position (where the current hinge/anchor should be) or if only 1 rope position then set that one to anchor point
                    if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                    {
                        if (ropePositions.Count == 1)
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                        else
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                    }
                    else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                    {
                        // if the line renderer position we're on is meant for the current anchor/hinge point...
                        var ropePosition = ropePositions.Last();
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else
                {
                    //set the position of the player.
                    ropeRenderer.SetPosition(i, transform.position);
                }
            }
        }
    }
}
