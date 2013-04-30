using UnityEngine;
using System.Collections;

public class eventDoorScript : MonoBehaviour {
	doorMoveScript[] doorMove;
	GameObject player;
	public GameObject[]enemyGroup;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float enemyAliveCount = enemyGroup.Length;
		foreach (GameObject enemy in enemyGroup)
		{
			if(enemy == null)
			{
				enemyAliveCount--;	
			}
		}
		if(enemyAliveCount == 0)
		{
			doorMove = gameObject.GetComponentsInChildren<doorMoveScript>();
		    foreach (doorMoveScript door in doorMove) 
			{
		        door.open();
		    }
		}	
	}
}
