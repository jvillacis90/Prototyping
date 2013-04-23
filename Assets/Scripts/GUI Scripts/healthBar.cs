using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class healthBar : MonoBehaviour
{
	
PlayerAttributes playerA;
	
healthBar healthObj;
powerBar powerObj;
	
public int startHealth = 4;
public int maxHealth = 8;
public bool destroyOnDeath = false;
public bool onHitDie = false;
private float lastHit = 0.0f;
public bool dead = false;
	
public Collider hit;
	
public List<Texture> switchableTextures = new List<Texture>();
public int currentTexture = 0;
	
//public Texture healthTex;
private Texture texture;
	
public Texture2D healthTex;
public Texture2D powerTex;
	


	// Use this for initialization
	void Start ()
	{
		
		if (switchableTextures.Count > 0) 
		{
			texture = switchableTextures[currentTexture];
		}
		
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

		
		maxHealth = startHealth;
	
	}
	
		
	public void changeTexture(int switchTo) 
	{
		if (switchTo < switchableTextures.Count && switchTo >= 0) 
		{
			texture = switchableTextures[switchTo];
			currentTexture = switchTo;
		} 

	}
	
		void up() 
	{
		if ((currentTexture+1) < switchableTextures.Count) 
		{
			++currentTexture;
			texture = switchableTextures[currentTexture];
		} 

	}
	
	void nextTexture() 
	{
		if ((currentTexture+1) < switchableTextures.Count) 
		{ // if we are at the end of the array
			++currentTexture;
			texture = switchableTextures[currentTexture];
		} 
		else 
		{// loop to the beginning
			currentTexture = 0;
			texture = switchableTextures[currentTexture];
		}
	}
	
	void down() 
	{
		if ((currentTexture-1) >= 0) 
		{
			--currentTexture;
			texture = switchableTextures[currentTexture];
		} 

	}
	
	
	void StartGame() 
	{
		
		dead = false;
		startHealth = maxHealth;
		
	}
	
	public int currentHealth()
	{
	
		return startHealth;
		
	}


	void PlayerHit() 
	{
		/*if(onHitDie) 
		{
			Dies();
		}*/
		
		int damage = startHealth-1;
		
		startHealth -= damage;
		startHealth = Mathf.Clamp(startHealth,0,maxHealth);
		float lastHit = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey("b"))
		{
			//healthBar.changeTexture(healthObj.currentHealth);
		}

		/*if (startHealth == 0)
		{
			//int startHealth = -1;
			Dies();
		}*/

	}

	/*void Dies() 
	{
		
		dead = true;
	
		if (destroyOnDeath) 
		{
			Destroy(this.gameObject);
		}
	}*/
	
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