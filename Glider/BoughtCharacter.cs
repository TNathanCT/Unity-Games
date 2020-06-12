using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoughtCharacter : MonoBehaviour
{
    public bool hasbeenBought;


    public IEnumerator SetCondition(int selected)
    {
        PlayerPrefs.SetInt("hasbeenbought:"+selected, hasbeenBought ? 0 : 1);
        yield return null;
    }

    public bool GetCondition(int selected)
    {
        return PlayerPrefs.GetInt("hasbeenbought:"+selected) == 1? true : false;
    }


    


}
