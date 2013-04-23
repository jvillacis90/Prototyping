using UnityEngine;
using System.Collections;

public class TimerDestroySelf : MonoBehaviour {
	float timer;
	public float secsOfSurvival;
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > secsOfSurvival)
		{
			Destroy(this.gameObject);	
		}
	}
}
