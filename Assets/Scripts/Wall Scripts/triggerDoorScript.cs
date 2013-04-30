using UnityEngine;
using System.Collections;

public class triggerDoorScript : MonoBehaviour {
	doorMoveScript[] doorMove;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(this.transform.position, player.transform.position) < 10)
		{
			doorMove = gameObject.GetComponentsInChildren<doorMoveScript>();
			if(Vector3.Distance(this.transform.position, player.transform.position) < 8)
			{
			    foreach (doorMoveScript door in doorMove) 
				{
			        door.open();
			    }
			}
			
			else if (Vector3.Distance(this.transform.position, player.transform.position) > 9)
			{
				foreach (doorMoveScript door in doorMove) 
				{
			        door.close();
			    }
			}
		}
	
	}
}
