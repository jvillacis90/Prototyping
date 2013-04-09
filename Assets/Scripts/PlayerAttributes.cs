using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour{

	public float _health;
	public float _energy;
	
	static PlayerAttributes instance = null;
	
	public static PlayerAttributes GetInstance()
	{
		if(instance == null)
		{
			instance = FindObjectOfType(typeof (PlayerAttributes))as PlayerAttributes;
		}
		return instance;
	}
}
