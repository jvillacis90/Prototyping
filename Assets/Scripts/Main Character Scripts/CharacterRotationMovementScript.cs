using UnityEngine;
using System.Collections;

public class CharacterRotationMovementScript : MonoBehaviour {
	
	public bool viewMoveField;
	public float left;
	public float right;
	public float paddingWidth;
	public float paddingHeight;
	public Rect moveField;
	
	public float turnSpeed;
	
	float mousePosX;
	float mousePosY;
	
	void Start()
	{
		moveField = new Rect(left,right, Screen.width - paddingWidth, Screen.height - paddingHeight);
	}
	
	void Update()
	{
		mousePosX = Input.mousePosition.x - 50; 
		mousePosY = (Screen.height - Input.mousePosition.y)-50;
		
		if(!moveField.Contains(new Vector2(mousePosX, mousePosY)))
		{
			if(mousePosX < Screen.width/2)
				this.transform.Rotate(new Vector3(0,-turnSpeed,0));
			else if(mousePosX> Screen.width/2)
				this.transform.Rotate(new Vector3(0,turnSpeed,0));
		}
	}
	
	void OnGUI()
	{
		if(viewMoveField)
		{
			moveField = new Rect(left,right, Screen.width - paddingWidth, Screen.height - paddingHeight);
			GUI.Button(moveField, "moveField");
		}
	}
}
