using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float movePace;
	public float jumpHeight;

	private Rigidbody2D rigidBody;

	public bool ground;
	public LayerMask whatIsGround;

	private Collider2D collider;

	private Animator animator;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();

		collider = GetComponent<Collider2D> ();

		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// to see if collider(box around objects) is touching any other collider on a particular layer t/f

		ground = Physics2D.IsTouchingLayers(collider, whatIsGround);

		rigidBody.velocity = new Vector2 (movePace, rigidBody.velocity.y);
		// buttons used to make alien jump
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{
			// wont allow jump until this becomes true. vector2 has 2 values, xy.
			if (ground) 
			{
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpHeight);
			}
		}
		//sets speed so animation can happen when speed is more than 0.
		animator.SetFloat ("speed", rigidBody.velocity.x);
		animator.SetBool ("ground", ground);

	}
}