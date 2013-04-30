using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class healthBar : MonoBehaviour
{
	
	PlayerAttributes playerA;
	
	public List<Texture2D> healthTextures = new List<Texture2D>();
	public List<Texture2D> energyTextures = new List<Texture2D>();	
	
	public float currentEnergy = 0.0f;
	private float maxEnergy = 8.0f;
	
	public float currentHealth = 0.0f;
	private float maxHealth = 8.0f;
	
	public Texture2D healthTex;
	public Texture2D energyTex;
		
	public float barWidth;
	public float barHeight;
	
	Collision hit;
	
	CharacterMovement charMove;
	GameObject charTest;
	
	//movement state variable
	bool hover;

	// Use this for initialization
	void Start ()
	{
		
		healthTex = healthTextures[4];
		energyTex = energyTextures[4];
		playerA = PlayerAttributes.GetInstance();
		charTest = GameObject.FindGameObjectWithTag("Player");
		charMove = charTest.GetComponent<CharacterMovement>();
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
	
		if(charMove.jumping)
		{
			
			if(currentEnergy >= 0.0f)
			{
				currentEnergy = playerA._energy-=Time.deltaTime;
				ChangeEnergyTexture(playerA._energy);
			}
			if(currentEnergy <= 1.0f)
			{
				charMove.jumping = false;	
			}

			
		}
		else if(!hover)
		{
			
			maxEnergy = 5.0f;

			
			if(currentEnergy < maxEnergy && charMove.controller.isGrounded)
			{
				
				currentEnergy = playerA._energy+=Time.deltaTime * 0.5f;
				ChangeEnergyTexture(playerA._energy);
				currentEnergy++;
			}

			
		}

		if(Input.GetKeyDown("b"))
		{
			currentHealth = playerA._health -=1.0f;
			ChangeHealthTexture(playerA._health);
		}

	}
	
	void OnGUI()
	{
		//Draw the energy and health bar
		Rect rect = new Rect(0,0,470/barWidth, 70/barWidth);
		GUI.Label(rect, healthTex);	
		rect.y += barHeight;
		GUI.Label (rect, energyTex);
	}

}