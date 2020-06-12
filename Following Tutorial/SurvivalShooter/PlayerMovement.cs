using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 6f;
    Vector3 m_Movement;
    Animator m_Anim;
    Rigidbody m_PlayerRigidbody;
    int floorMask;
    float m_camRayLength = 100f;
   


   


    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        m_Anim = GetComponent<Animator> ();
        m_PlayerRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");//immediately at full speed when he starts moving.
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        m_Movement.Set(h, 0f, v);
        m_Movement = m_Movement.normalized * m_Speed * Time.deltaTime;

        m_PlayerRigidbody.MovePosition(transform.position + m_Movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Floorhit;

        if (Physics.Raycast(camRay, out Floorhit, m_camRayLength, floorMask))
        {
            Vector3 playertoMouse = Floorhit.point - transform.position;
            playertoMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playertoMouse);
            m_PlayerRigidbody.MoveRotation(newRotation);

        }

    }

    void Animating (float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        m_Anim.SetBool("IsWalking", walking);


    }

}
