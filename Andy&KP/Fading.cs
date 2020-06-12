using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture; // la texture du fade
	public float fadeSpeed = 0.8f; // la vitesse du fade 

	private int drawDepth = -1000; // dans l'ordre que va se dessiner la texture dans la hiérarchie, plus il est bas, le plus important il est.
	private float alpha = 1.0f;
	private int fadeDir = -1; // la direction du fade : -1 = in et 1 = out

	void OnGUI ()
	{
		// le fade utilise une direction -> je vais utiliser la vitesse + Time.deltatime pour convertir l'opération en secondes
		alpha += fadeDir * fadeSpeed * Time.deltaTime; 
		// je force la valeur alpha entre 0 et 1 en utilisant Mathf.Clamp01
		alpha = Mathf.Clamp01(alpha);
		// mettre en place la couleur du GUI 
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // on n'y rajoute l'alpha à la fin 
		GUI.depth = drawDepth; // la texture noir se dessine en 1er
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); // dessine la texture sur l'écran de jeu 
	}

	// la fonction qui s'occupe du fade
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return(1 / fadeSpeed); // recupère le fadeSpeed pour qu'il soit facile à régler dans Application.LoadLevel();
	}

	void OnLevelWasLoaded()
	{
		alpha = 1;// utiliser ça si le alpha n'est pas 1 par defaut 
		BeginFade(-1); // appel la fonction fade in 
	}
}
