using UnityEngine;
using System.Collections;

public class CharacterFacingVector : MonoBehaviour {
	public float distance;
	void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * distance));
    }
}
