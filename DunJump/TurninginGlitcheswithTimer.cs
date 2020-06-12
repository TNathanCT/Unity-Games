using UnityEngine;
using System.Collections;

public class TurninginGlitcheswithTimer : MonoBehaviour
{

    public GameObject glitch;
    public float switchblock = 0;
    public GameObject[] OriginalBlock;
    public bool start;
    public float timer;
    public int indic;

    void Start()
    {
        glitch.SetActive(false);
        start = false;
    }

    void Update()
    {
        if (switchblock > 0)
        {
            switchblock -= Time.deltaTime;
            start = false;
            OriginalBlock[indic].GetComponent<Change>().change = false;
            /*  foreach (GameObject ground in OriginalBlock)
              {
                  ground.GetComponent<SpriteRenderer>().sprite = ground.GetComponent<Change>().StartTexture;
              }*/
        }

        if (switchblock <= 0)
        {
            start = true;
            //  OriginalBlock[indic].GetComponent<SpriteRenderer>().sprite = OriginalBlock[indic].GetComponent<Change>().Glitch;
            //Instantiate(glitch, OriginalBlock[indic].transform.position, OriginalBlock[indic].transform.rotation);
            OriginalBlock[indic].GetComponent<Change>().change = true;
        }

        if (start)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 0.2f)
        {
            indic += 1;
            timer = 0;
        }

        if (!start)
        {
            timer = 0;
        }
    }
}