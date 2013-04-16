using UnityEngine;
using System.Collections;

public class TargetingScript : MonoBehaviour {
	public Texture2D reticleImage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		//Rect moveField = new Rect(left,right, Screen.width - paddingWidth, Screen.height - paddingHeight);
		GUI.Label(new Rect(Input.mousePosition.x - 50, (Screen.height - Input.mousePosition.y)-50, 100,100), reticleImage);
	}
}
