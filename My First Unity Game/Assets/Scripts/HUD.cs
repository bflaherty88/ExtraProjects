using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture crosshairs;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void OnGUI () 
    {
        GUI.DrawTexture(new Rect(Screen.width/2 -16f, Screen.height/2 - 16f, 32f, 32f), crosshairs);
	}
}
