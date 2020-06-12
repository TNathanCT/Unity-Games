using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;  //Approximate time for the camera to move.              
    public float m_ScreenEdgeBuffer = 4f;  //distance between the tanks and the edge of the screen.
    public float m_MinSize = 6.5f;    //minimum amount of zoom.              
    [HideInInspector] public Transform[] m_Targets; 


    private Camera m_Camera;                   //reference to the camera                 
    private float m_ZoomSpeed;                 // Reference speed for the smooth damping of the orthographic size.               
    private Vector3 m_MoveVelocity;            // Reference velocity for the smooth damping of the position.     
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>(); //select the childobject.
    }


    private void FixedUpdate() 
        // Move the camera towards a desired position.
       // Change the size of the camera based.
    {
        Move();
        Zoom();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)    //list or tanks (which are the targets). It's used as a loop.
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue; //If the Tank isn't active (!), then continue

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos; //the camera will not move up or down.
    }


    private void Zoom()
    {           // Find the required size based on the desired position and smoothly transition to that size.
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize= Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);//finding the desired position from the X/Y axis

        float size = 0f; //saize variable which starts at zero.

        for (int i = 0; i < m_Targets.Length; i++) //loop ing through the targets. Same as previous.
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            // Otherwise, find the position of the target in the camera's local space.
            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            // Find the position of the target from the desired position of the camera's local space.
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            // This allows you to choose the largest size and the distance of the tank 'up' or 'down'.
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

            //same, but on the X axis, instead of y.
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
        size += m_ScreenEdgeBuffer; //extra distance so the tanks fit in the zoom.

        size = Mathf.Max(size, m_MinSize); //We don't want the camera to zoom too much.

        return size;
    }


    public void SetStartPositionAndSize() 
    {   //find the desired position.
        FindAveragePosition();

        //Set the camera's position to the desired position.
        transform.position = m_DesiredPosition;
        
        //Find and set the required size of the camera.
        m_Camera.orthographicSize = FindRequiredSize();
    }
}