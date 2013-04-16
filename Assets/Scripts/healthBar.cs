using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour
{
	
public int startHealth = 100;
public int maxHealth = 100;
public bool destroyOnDeath = false;
public bool onHitDie = false;
private float lastHit = 0.0f;
public bool dead = false;
	
public Texture healthTex; //useful: texture.width, texture.height
//private Vector2 offset;
	


	// Use this for initialization
	void Start ()
	{
		
		Texture2D healthTex = new Texture2D(128,128);
		renderer.material.mainTexture = healthTex;
		
		maxHealth = startHealth;
	
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
		if(onHitDie) 
		{
			Dies();
		}
		
		//startHealth -= damage;
		startHealth = Mathf.Clamp(startHealth,0,maxHealth);
		float lastHit = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startHealth == 0)
		{
			//int startHealth = -1;
			Dies();
		}

	}

	void Dies() 
	{
		
		dead = true;
	
		if (destroyOnDeath) 
		{
			Destroy(this.gameObject);
		}
	}

}
