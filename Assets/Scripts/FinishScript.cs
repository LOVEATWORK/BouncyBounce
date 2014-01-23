using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {

	public bool collisionDetected = false;

	void OnCollisionEnter2D(Collision2D collision) {
		collisionDetected = true;
	}

	void OnCollisionExit2D(Collision2D collision) {
		collisionDetected = false;
	}

}
