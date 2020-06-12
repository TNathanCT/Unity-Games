using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS WAS REMOVED FROM THE PROJECT FOR NOW
public class AttackSystem : MonoBehaviour
{
    AttackProperties attackprop;

    public int PP(int startingPP)
    {
        AttackProperties attackprop = new AttackProperties();
        attackprop.AttackPP = startingPP; //This is will be used for the permanent max
        //currentPP for the attack's pp left
        return attackprop.AttackPP;

    }

    public string ATKType(string type)
    {
        attackprop.AttackType = type;
        return attackprop.AttackType;
    }

    public int ATKDamage(int damage)
    {
        attackprop.attackdamage = damage;
        return attackprop.attackdamage;

    }

    public string ATKName(string name)
    {
        attackprop.attackname = name;
        return attackprop.attackname;
    }

    public void AquaJet(int ppstats, string atkType, int atkDamage, string atkName)
    {
       // ppstats = 20;
       // atkType = "Water";
       // atkDamage = 40;
       // atkName = "Aqua Jet";
        PP(ppstats);
        ATKType(atkType);
        ATKDamage(atkDamage);
        ATKName(atkName);
    }

    void Start()
    {
        AquaJet(20, "Water", 40, "Aqua Jet");    
    }


}
