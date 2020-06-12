using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public float object_release_before_hit;
    public List<Beat> player_beats;
    public float bpm = 90;
    public float player_beat_delay;


    public static Level CreatefromJSON(string jsonSTRING){
        return JsonUtility.FromJson<Level>(jsonSTRING);
    }
}
