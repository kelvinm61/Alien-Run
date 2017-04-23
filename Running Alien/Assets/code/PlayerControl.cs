 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float movePace;
	public float jumpHeight;
	public float jumpTime;
	private float jumpTimeCount;

	public float speedmultipier;

	public float speedIncreaser;
	private float speedMilestoneCount;


	private Rigidbody2D rigidBody;

	public bool ground;
	public LayerMask whatIsGround;
	public Transform GroundCheck;
	public float groundcheckCircle;

	//private Collider2D collider;

	private Animator animator;
	public Manager theAppManger;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();

		//collider = GetComponent<Collider2D> ();

		animator = GetComponent<Animator> ();

		jumpTimeCount = jumpTime;

		speedMilestoneCount = speedIncreaser;
	}

	// Update is called once per frame
	void Update () 
	{
		// to see if collider(box around objects) is touching any other collider on a particular layer t/f

		//ground = Physics2D.IsTouchingLayers(collider, whatIsGround);
		ground = Physics2D.OverlapCircle(GroundCheck.position, groundcheckCircle, whatIsGround);  

		//milestones making the player got a bit faster everytime he hits a milestone 
		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaser;

			speedIncreaser = speedIncreaser * speedmultipier;
			movePace = movePace + speedmultipier;
		}

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
		//so when any button is held dow it will pro long the jump to the specified time limit.
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
			{
				if (jumpTimeCount > 0)
				{
					rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpHeight); 
					jumpTimeCount -= Time.deltaTime;
				}
			 }
		//stop player holding button down
		if (Input.GetKeyUp (KeyCode.Space) || (Input.GetMouseButtonUp(0)))
			{
				jumpTimeCount=0;
			}
			//reset jump time counter
			if (ground)
			{
				jumpTimeCount = jumpTime;
			}


		//sets speed so animation can happen when speed is more than 0.
		animator.SetFloat ("speed", rigidBody.velocity.x);
		animator.SetBool ("ground", ground);

	}
	// when box colliders touch (player and bottom box)
	void onCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "murder") 
		{
			theAppManger.RestartGame ();
		}
	}

}