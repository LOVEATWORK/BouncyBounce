using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	
	bool facingLeft = true;

	
	public bool grounded = false;
	public bool enemycontact = false;
	public Transform groundCheck;
	float groundRadius = 1f;
	public LayerMask whatIsGround;
	public LayerMask whatIsEnemy;
	public float jumpForce = 700f;
	public bool moveWhileJumping = false;
	
	bool doubleJump = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {

			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			
			if (!doubleJump && !grounded)
				doubleJump = true;
			
		}
		
	}
	
	void FixedUpdate() {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		enemycontact = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsEnemy);

		if (grounded)
			doubleJump = false;

		if (!grounded && !moveWhileJumping)
			return;
		
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
}
