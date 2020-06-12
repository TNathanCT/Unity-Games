using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

    public GameObject[] Weapons;
    public Canvas SniperReticle;

    public Animator SniperMovement;
    public bool IstheGunOutorIn = true;

    SniperShooting SniperScripts;
    Shooting GunFired;

    PickupObject PickupScript;
    ThrowPortal PortalCreator;

   public Animator PortalGunMovement;
    public bool IsthePortalGunAway = false;

    void Awake()
    {
        SniperReticle.GetComponent<Canvas>().enabled = false;
        SniperScripts = FindObjectOfType<SniperShooting>();
        GunFired = FindObjectOfType<Shooting>();

        PortalCreator = FindObjectOfType<ThrowPortal>();
        PickupScript = FindObjectOfType<PickupObject>();
        PortalCreator.enabled = false;
        PickupScript.enabled = false;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            
                IstheGunOutorIn = true;
                SniperScripts.enabled = false;
                GunFired.enabled = false;
                //ChangeWeapon(0);

                IsthePortalGunAway = false;
            PortalCreator.enabled = true;
            PickupScript.enabled = true;

            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //ChangeWeapon(1);

                IstheGunOutorIn = false;
                SniperScripts.enabled = true;
                GunFired.enabled = true;


                IsthePortalGunAway = true;
            PortalCreator.enabled = false;
            PickupScript.enabled = false;

          
        }
        SniperMovement.SetBool("IsitOut", IstheGunOutorIn);
        PortalGunMovement.SetBool("Porty", IsthePortalGunAway);

    }

    public void ChangeWeapon(int seq)
    {
        disableAll();
        Weapons[seq].SetActive(true);
        


    }

    public void disableAll()
    {
        foreach (GameObject Weapon in Weapons)
        {
            Weapon.SetActive(false);
        }

    }
}
