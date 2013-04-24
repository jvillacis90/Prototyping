using UnityEngine;
using System.Collections;

public class TargetingScript : MonoBehaviour {
	public Texture2D[] reticleImages;
	int reticleIndex;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			if(reticleIndex < 4)
				reticleIndex += 1;	
		}
		else if(Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			if(reticleIndex > 0)
				reticleIndex -= 1;	
		}
	
	}
	
	void OnGUI()
	{
		//Rect moveField = new Rect(left,right, Screen.width - paddingWidth, Screen.height - paddingHeight);
		GUI.Label(new Rect(Input.mousePosition.x - 50, (Screen.height - Input.mousePosition.y)-50, 100,100), reticleImages[reticleIndex]);
	}
}
