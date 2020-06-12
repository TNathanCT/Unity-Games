using System.Collections;
using UnityEngine;

public class MoveDatabase
{
    //we toss in a bunch of different effects for each move. I chose to use an Enum to try and keep my code clean.
    public enum BonusEffect
    {
        DeBuff,
        Confusion,
        Burn
    }

    //While there are more than two types of attacks in pokemon, in this first case, I'm just going to focus on the physical and special types of attacks.
    public enum Category
    {
        Physical,
        Special
    }

    //The attribute of the attacks that will be first addded to the game.
    public enum AttackType
    {
        Water,
        Steel,
        Earth,
        Fighting,
        Ghost,
        Normal
    }

    string attackName;
    Category moveCategory;
    AttackType moveType;
    int attackPower;
    float attackAccuracy;
    int moveMaxPP;
    bool hasPrority;
    BonusEffect[] addedEffects;
    string attackDescription;
    public int moveid;

    //We store the different collections
    public MoveDatabase(string name, AttackType type, Category category, int movepower, float accuracy, int maxpp,  string description, bool prority, BonusEffect[] effect)
    {
        this.attackName = name;
        this.moveType = type;
        this.moveCategory = category;
        this.attackPower = movepower;
        this.moveMaxPP = maxpp;
        this.attackAccuracy = accuracy;
        this.hasPrority = prority;
        this.addedEffects = new BonusEffect[0];
        this.addedEffects = effect;
        this.attackDescription = description;
        //this.moveid = id;
    }
    public string GetName()
    {
        return attackName;
    }

    public AttackType GetmoveType()
    {
        return moveType;
    }

    public Category GetCategory()
    {
        return moveCategory;
    }

    public int GetPower()
    {
        return attackPower;
    }

    public float GetAccuracy()
    {
        return attackAccuracy;
    }



    public int GetMaxPP()
    {
        return moveMaxPP;
    }

    public bool GetPrority()
    {
        return hasPrority;
    }

    public BonusEffect[] GetbonusEffect()
    {
        return addedEffects;
    }

    public string GetDescription()
    {
        return attackDescription;
    }



    public class ListofAllMoves
    {
        


    }

   

}
