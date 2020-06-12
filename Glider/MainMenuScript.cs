using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
//using UnityEditor.Advertisements;

public class MainMenuScript : MonoBehaviour
{
    
    public void Quit()
    {
        Application.Quit();
    }

   public void Play()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Market");

    }


    /*
    private void Start()
    {
        PluginInterface.GoogleAdsInstance.Create();

        if (PluginInterface.GoogleAdsInstance.Interstitial.IsReady())
        {
            PluginInterface.GoogleAdsInstance.Interstitial.Show();
        }

        if (PluginInterface.GoogleAdsInstance.Banner.IsLoaded == true)
        {
            PluginInterface.GoogleAdsInstance.Banner.Show();
        }

    }*/
}
