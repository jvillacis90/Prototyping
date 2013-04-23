using UnityEngine;
using System.Collections;

public class powerBar : MonoBehaviour 
{
	
public int beginPower;
public int maxPower;
public bool dead = false;
	
private Texture powerTex; //useful: texture.width, texture.height


	// Use this for initialization
	void Start () 
	{
		
		Texture2D powerTex = new Texture2D(128,128);
		renderer.material.mainTexture = powerTex;
		
		maxPower = beginPower;
	
	}
	
	void StartGame()
	{
		
		dead = false;
		beginPower = maxPower;
		
	}
	
	public int currentPower()
	{
		
		return beginPower;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
