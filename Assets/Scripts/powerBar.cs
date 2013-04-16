using UnityEngine;
using System.Collections;

public class powerBar : MonoBehaviour 
{
	
public int beginPower;
public int maxPower;
public bool dead = false;
	
private Texture texture; //useful: texture.width, texture.height
private Vector2 offset;


	// Use this for initialization
	void Start () 
	{
		
		maxPower = beginPower;
	
	}
	
	void StartGame()
	{
		
		dead = false;
		beginPower = maxPower;
		
	}
	
	/*void currentPower()
	{
		
		return beginPower;
		
	}*/
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
