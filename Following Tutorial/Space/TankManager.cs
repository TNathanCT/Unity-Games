using System;
using UnityEngine;

[Serializable] //it's own thing. When you have an instance of this, you can show it in the inspector
public class TankManager 
{
    public Color m_PlayerColor;  //color          
    public Transform m_SpawnPoint;    //spawn point. These are completed by the array in the Unity.   
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText; //The Hide prevents the players not only from seeing them, but also from interacting with those variables.
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;    //the amount of wins.                 


    private TankMovement m_Movement;       
    private TankShooting m_Shooting;
    private GameObject m_CanvasGameObject;


    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>(); //set the instances, and get the gameobjects then.
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";
        //string. Adding a color the text after the code. In this case it's 'Player'

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();
        //show up 3D objects in the scene. 

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;//taking all the renderers and putting the same color.
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }


    public void Reset() //sets the instance back to the spawn point, turns it off, and turns it back on.
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
