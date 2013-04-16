using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	public GameObject startObject;
	Vector3 startPos;
	Vector3 endPos;
	public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 end = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50));
			startPos = startObject.transform.position;
			GameObject proj = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
			proj.GetComponent<ProjectileMovementScript>().setDirection(startPos, end);
			
		}
		
		//Camera.main.ScreenPointToRay(Input.mousePosition)
	
	}
}
