using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ElectricGunScript : MonoBehaviour {

    public GameObject ChargedEffects;
    public bool ischarged;
    GameObject maincamera;
    GameObject Electricity;
    public GameObject ElectricityintheCylinder;

	
	void Start () {
        ischarged = false;
        maincamera = GameObject.FindWithTag("MainCamera");
        ChargedEffects.SetActive(false);
	}



    private void Update()
    {
        DrainEnergy();
        ReleaseEnergy();
    }


    void DrainEnergy()
    {
        if (Input.GetMouseButton(1) && ischarged == false)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                DrainableEnergy p = hit.collider.GetComponent<DrainableEnergy>();
                if (p != null)
                {
                    ischarged = true;
                    ChargedEffects.SetActive(true);
                    ElectricityintheCylinder.SetActive(false);
                }
            }
        }

    }

    void ReleaseEnergy()
    {
        if(Input.GetMouseButton(1) && ischarged == true)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                PutElecIn p = hit.collider.GetComponent<PutElecIn>();
                if (p != null)
                {
                    ischarged = false;
                    ChargedEffects.SetActive(false);
                    ElectricityintheCylinder.SetActive(true);
                    EditorSceneManager.LoadScene("Victory");
                }
            }
        }
    }
}
	


