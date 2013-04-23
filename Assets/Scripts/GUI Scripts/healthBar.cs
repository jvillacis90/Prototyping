using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class healthBar : MonoBehaviour
{
	
	PlayerAttributes playerA;
	
	public List<Texture2D> healthTextures = new List<Texture2D>();
	public List<Texture2D> energyTextures = new List<Texture2D>();	
	public int currentTexture = 0;
	
	public Texture2D healthTex;
	public Texture2D energyTex;
		
	public float barWidth;
	public float barHeight;

	// Use this for initialization
	void Start ()
	{
		healthTex = healthTextures[4];
		energyTex = energyTextures[4];
		playerA = PlayerAttributes.GetInstance();
	
	}
	
		
	public void ChangeHealthTexture(float switchTo) 
	{
		int switchInt = (int)switchTo;
		if (switchTo < healthTextures.Count && switchInt >= 0) 
		{
			healthTex = healthTextures[switchInt];
		} 

	}
	public void ChangeEnergyTexture(float switchTo) 
	{
		int switchInt = (int)switchTo;
		if (switchTo < energyTextures.Count && switchInt >= 0) 
		{
			energyTex = energyTextures[switchInt];
		} 

	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("b"))
		{
			playerA._health +=1;
			playerA._energy -=1;
			ChangeHealthTexture(playerA._health);
			ChangeEnergyTexture(playerA._energy);
		}

	}
	void OnGUI()
	{
		//Draw the power bar
		Rect rect = new Rect(0,0,470/barWidth, 70/barWidth);
		GUI.Label(rect, healthTex);	
		rect.y += barHeight;
		GUI.Label (rect, energyTex);
	}

}