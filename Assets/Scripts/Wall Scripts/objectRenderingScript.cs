using UnityEngine;
using System.Collections;

public class objectRenderingScript : MonoBehaviour {
	float renderEnableTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!renderer.enabled)
		{
			renderEnableTimer += Time.deltaTime;
			if(renderEnableTimer > 1.5)
			{
				renderer.enabled = true;
				renderEnableTimer = 0;
			}
		}
	
	}
}
