using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDetails : MonoBehaviour
{

    // List<MoveDatabase> movedata = new List<MoveDatabase>();
    public MoveDatabase[] moves = new MoveDatabase[] {
            new MoveDatabase("Aqua Jet", MoveDatabase.AttackType.Water, MoveDatabase.Category.Physical, 40, 1f, 20, "The user lunges at the target at a speed that makes it almost invisible. This move always goes first.", true, null),



            new MoveDatabase("Flash Cannon", MoveDatabase.AttackType.Steel, MoveDatabase.Category.Special, 80, 1f, 10, "The user gathers all its light energy and releases it all at once. This may also lower the target's Sp. Def stat.", false, new MoveDatabase.BonusEffect[]{ MoveDatabase.BonusEffect.DeBuff}),


            new MoveDatabase("Scald", MoveDatabase.AttackType.Water, MoveDatabase.Category.Special, 80, 1f, 15, "The user shoots boiling hot water at its target. This may also leave the target with a burn.", false, new MoveDatabase.BonusEffect[]{ MoveDatabase.BonusEffect.Burn}),


            new MoveDatabase("Earthquake", MoveDatabase.AttackType.Earth, MoveDatabase.Category.Physical, 100, 1f, 10, "The user sets off an earthquake that strikes every Pokémon around it.", false, null),


            new MoveDatabase("Aura Sphere", MoveDatabase.AttackType.Fighting, MoveDatabase.Category.Special, 80, 1f, 20, "he user lets loose a blast of aura power from deep within its body at the target. This attack never misses.", false, null),


            new MoveDatabase("Shadow Ball", MoveDatabase.AttackType.Ghost, MoveDatabase.Category.Special, 80, 1f, 15, "The user hurls a shadowy blob at the target. This may also lower the target's Sp. Def stat.", false, new MoveDatabase.BonusEffect[]{ MoveDatabase.BonusEffect.DeBuff}),


             new MoveDatabase("Bullet Punch", MoveDatabase.AttackType.Steel, MoveDatabase.Category.Physical, 40, 1f, 30, "The user lunges at the target at a speed that makes it almost invisible. This move always goes first.", true, null),

             new MoveDatabase("Rock Climb", MoveDatabase.AttackType.Normal, MoveDatabase.Category.Physical, 90, 0.85f, 20, "A charging attack that may also leave the foe confused. It can also be used to scale rocky walls.", true, new MoveDatabase.BonusEffect[]{ MoveDatabase.BonusEffect.Confusion})
        };




    public MoveDatabase GetMove(int nameID)
    {
        MoveDatabase result = null;
        int movenumber = nameID;
        for (int i = 0; i < moves.Length; i++)
        {
            if (i == movenumber)
            {
                moves[i].GetName();
                result = moves[i];
            }
        }
        return result;


    }


    void Start()
    {
            /*
        
        movedata.Add(new MoveDatabase(0, "Aqua Jet", MoveDatabase.AttackType.Water, MoveDatabase.Category.Physical, 40, 1f, 20, "The user lunges at the target at a speed that makes it almost invisible. This move always goes first.", true, null));

        movedata.Add(new MoveDatabase(1, "Flash Cannon", MoveDatabase.AttackType.Steel, MoveDatabase.Category.Special, 80, 1f, 10, "The user gathers all its light energy and releases it all at once. This may also lower the target's Sp. Def stat.", false, new MoveDatabase.BonusEffect[] { MoveDatabase.BonusEffect.DeBuff }));


        movedata.Add(new MoveDatabase(2, "Scald", MoveDatabase.AttackType.Water, MoveDatabase.Category.Special, 80, 1f, 15, "The user shoots boiling hot water at its target. This may also leave the target with a burn.", false, new MoveDatabase.BonusEffect[] { MoveDatabase.BonusEffect.Burn }));


        movedata.Add(new MoveDatabase(3, "Earthquake", MoveDatabase.AttackType.Earth, MoveDatabase.Category.Physical, 100, 1f, 10, "The user sets off an earthquake that strikes every Pokémon around it.", false, null));


        movedata.Add(new MoveDatabase(4, "Aura Sphere", MoveDatabase.AttackType.Fighting, MoveDatabase.Category.Special, 80, 1f, 20, "he user lets loose a blast of aura power from deep within its body at the target. This attack never misses.", false, null));


        movedata.Add(new MoveDatabase(5, "Shadow Ball", MoveDatabase.AttackType.Ghost, MoveDatabase.Category.Special, 80, 1f, 15, "The user hurls a shadowy blob at the target. This may also lower the target's Sp. Def stat.", false, new MoveDatabase.BonusEffect[] { MoveDatabase.BonusEffect.DeBuff }));


        movedata.Add(new MoveDatabase(6, "Bullet Punch", MoveDatabase.AttackType.Steel, MoveDatabase.Category.Physical, 40, 1f, 30, "The user lunges at the target at a speed that makes it almost invisible. This move always goes first.", true, null));

        movedata.Add(new MoveDatabase(7, "Rock Climb", MoveDatabase.AttackType.Normal, MoveDatabase.Category.Physical, 90, 0.85f, 20, "A charging attack that may also leave the foe confused. It can also be used to scale rocky walls.", true, new MoveDatabase.BonusEffect[] { MoveDatabase.BonusEffect.Confusion }));

    */





    }


}