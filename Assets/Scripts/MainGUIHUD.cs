using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MainGUIHUD : MonoBehaviour 
{
	
PlayerAttributes playerA;
	
healthBar healthObj;
powerBar powerObj;
	
public Texture2D healthTex;
public Texture2D powerTex;

	// Use this for initialization
	void Start () 
	{
		playerA = PlayerAttributes.GetInstance();
		if(!healthObj)
		{
			healthObj = GameObject.FindGameObjectWithTag("Player").GetComponent<healthBar>();
		}
		
		playerA = PlayerAttributes.GetInstance();
		if(!powerObj)
		{
			powerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<powerBar>();
		}
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
	}
	
	void OnGUI()
	{

		
		//Draw the power bar
		Rect rect = new Rect(0,0,Screen.width/3, Screen.height/10);
		GUI.Button(rect, healthTex);	
		rect.y += rect.height;
		GUI.Button (rect, powerTex);
		rect.y += rect.height;
		
	}
}
