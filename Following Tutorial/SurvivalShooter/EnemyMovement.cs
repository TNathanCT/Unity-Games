using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform Player;
   PlayerHealth m_playerHealth;
    EnemyHealth m_enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag ("Player").transform;
        m_playerHealth = Player.GetComponent <PlayerHealth> ();
        m_enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> (); 
    }


    void Update ()
    {
        if(m_enemyHealth.currentHealth > 0 && m_playerHealth.currentHealth > 0)
        {
            nav.SetDestination (Player.position);
        }
       else
       {
         nav.enabled = false;
        }
    }
}