using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	// Designer variables
	public float maxSpeed = 10f;
	public Transform sightStart;
	public Transform sightEnd;
	public int HP = 100;
	
	public LayerMask platformLayer;
	
	RaycastHit2D raycastHit;
	
	bool facingLeft = true;
	
	// Use this for initialization
	void Start () {
		
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
	}
	
	// Update is called once per frame
	void Update () {
		Behaviours ();
	}
	
	void FixedUpdate() {
		
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		if (move < 0 && !facingLeft)
			Flip ();
		else if (move > 0 && facingLeft)
			Flip ();
	}
	
	void Flip ()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		PlatformScript platform = coll.gameObject.transform.GetComponent<PlatformScript> ();
		
		Debug.Log (platform.platformType);

		if (platform.damage > 0)
			HP -= platform.damage;
		
	}
	
	void Behaviours ()
	{
		// throw new System.NotImplementedException ();
		
		
	}
}
