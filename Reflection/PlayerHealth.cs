using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float StartingHealth = 100f;
	public Slider Slider;
	public Image FillImage;

	public float CurrentHealth;


	void Start () {
		CurrentHealth = StartingHealth;
		SetHealthUI ();

	}

	void Update(){
		SetHealthUI ();

		if (CurrentHealth <= 0) {
			EditorSceneManager.LoadScene ("Level");
		
		}
	}

	void TakeDamage(float amount){
		CurrentHealth -= amount;
		SetHealthUI ();
	
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            CurrentHealth -= 10;
            SetHealthUI();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            CurrentHealth -= 10;
            SetHealthUI();
        }

    }

  


    public void SetHealthUI(){
		Slider.value = CurrentHealth;
		
	}
}
