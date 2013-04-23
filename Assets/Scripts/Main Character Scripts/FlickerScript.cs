using UnityEngine;
using System.Collections;

public class FlickerScript : MonoBehaviour {
	PlayerAttributes player;
	// Update is called once per frame
	
	void Start()
	{
		player = PlayerAttributes.GetInstance();	
	}
	
	void Update () {
		if(player.damageState)
		{
			if(!animation["flickAnim"].enabled)
			{
				animation.Play("flickAnim");	
			}
		}
	
	}
}
