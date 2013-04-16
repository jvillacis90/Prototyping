using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MainGUIHUD : MonoBehaviour 
{
	
	PlayerAttributes playerA;
	
public healthBar healthObj;
public powerBar power;
	
public Texture texture; //useful: texture.width, texture.height
public Vector2 offset;
	
public Texture2D healthTex;

	// Use this for initialization
	void Start () 
	{
		playerA = PlayerAttributes.GetInstance();
		if(!healthObj)
		{
			healthObj = GameObject.FindGameObjectWithTag("Player").GetComponent<healthBar>();
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		healthBar.texture(healthObj.currentHealth());
		
	
	}
	
	void OnGUI()
	{
		/*
		//Draw the health bar
		GUI.Box (Rect(healthObj.offset.x,
				healthObj.offset.y,
				healthObj.texture.width,
				healthObj.texture.height),
				healthObj.texture, noGuiStyle);
		
		//Draw the power bar
		GUI.Box ();
		*/
		Rect rect = new Rect(0,0,Screen.width/3, Screen.height/10);
		GUI.Button(rect, playerA._health.ToString());	
		rect.y += rect.height;
		GUI.Button (rect, "Power Bar");
		
	}
}
