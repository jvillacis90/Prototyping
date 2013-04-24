using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour{

	public float _health;
	public float _energy;
	
	static PlayerAttributes instance = null;
	
	healthBar hb;
	
	public bool damageState = false;
	float damageStateTimer = 0;
	
	void Start()
	{
		hb = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<healthBar>();
	}
	
	void Update()
	{
		if (damageState)
		{
			damageStateTimer += Time.deltaTime;
			if(damageStateTimer > 1)
			{
				damageState = false;
				damageStateTimer = 0;
			}	
		}
	}
	
	public static PlayerAttributes GetInstance()
	{
		if(instance == null)
		{
			instance = FindObjectOfType(typeof (PlayerAttributes))as PlayerAttributes;
		}
		return instance;
	}
	
	public void takeDamage()
	{
		if(!damageState)
		{
			_health-=1;
			hb.ChangeHealthTexture(_health);
			damageState = true;
		}
	}
}
