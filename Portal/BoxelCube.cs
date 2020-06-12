using UnityEngine;
using System.Collections;

public class BoxelCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                for (int k = 0; k < 8; k++)
                    VoxelTools.MakeCube(i, j, k); 
	}

      void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            VoxelTools.MakeAllCubesFall();
        }
        }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Companion Cube"))
        {
            VoxelTools.MakeAllCubesFall();
        }
    }
    
}
