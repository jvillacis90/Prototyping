using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {
	
	GameObject deathParticle;
	
	
	public virtual void ShowDeath()
	{
		DestroyObject(this.gameObject);
		if(deathParticle != null)
			Instantiate(deathParticle, this.transform.position, Quaternion.identity);
	}
	
	public void SetDeathParticle(GameObject p)
	{
		deathParticle = p;
	}
}
