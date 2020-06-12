using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProperties : MonoBehaviour
{
    public int attackPP;
    public string attacktype;
    public int attackdamage;
    public string attackname;

    public int AttackPP
    {
        get { return attackPP; }
        set { attackPP = value; }
    }

    public string AttackType
    {
        get { return attacktype; }
        set { attacktype = value; }
    }

    public int AttackDamage
    {
        get { return attackdamage; }
        set { attackdamage = value; }
    }

    public string AttackName
    {
        get { return attackname; }
        set { attackname = value; }
    }
}
