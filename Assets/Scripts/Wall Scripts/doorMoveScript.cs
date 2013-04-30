using UnityEngine;
using System.Collections;

public class doorMoveScript : MonoBehaviour {
	bool move = false;
	bool goBack = false;
	Vector3 original;
	public Vector3 target;
	public float speed;
	// Use this for initialization
	void Start () {
		original = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(move)
		{
			transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, target.x, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.y, target.y, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.z, target.z, speed * Time.deltaTime));	
		}
		else if(goBack)
		{
			transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, original.x, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.y, original.y, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.z, original.z, speed * Time.deltaTime));	
			if(transform.position == original)
			{
				goBack = false;	
			}
		}
	
	}
	
	public void open()
	{
		move = true;	
	}
	
	public void close()
	{
		if(move)
		{
			move = false;
			goBack = true;	
		}
	}
}
