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
	
private Texture texture; //useful: texture.width, texture.height
private Vector2 offset;

	// Use this for initialization
	void Start ()
	{
		
		maxHealth = startHealth;
	
	}
	
	void StartGame() 
	{
		
		dead = false;
		startHealth = maxHealth;
		
	}
	
	void currentHealth()
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
