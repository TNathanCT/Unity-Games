using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public float StartingHealth = 100f;
    public Slider Slider;
    public Image FillImage;

    public Color FullHealthColor = Color.green;
    public Color ZeroHealthColor = Color.red;

   public Slider HP2;
    public Image FillImage2;

    public float CurrentHealth;

	void Start () {
        CurrentHealth = StartingHealth;
        SetHealthUI();
	}
	
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        SetHealthUI();

        if (CurrentHealth <= 0f)
        {
            OnDeath();
        }
    }

    public void SetHealthUI()
    {
        Slider.value = CurrentHealth;
        FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, CurrentHealth / StartingHealth);
        HP2.value = CurrentHealth;
        FillImage2.color = Color.Lerp(ZeroHealthColor, FullHealthColor, CurrentHealth / StartingHealth);
        
    }

    private void OnDeath()
    {

    }

}
