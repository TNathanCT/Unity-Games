using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ReplayGame : MonoBehaviour {


	public void Replay () {
        EditorSceneManager.LoadScene("Level");
    }
}
