using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float movePace;
	public float jumpHeight;

	private Rigidbody2D rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rigidBody.velocity = new Vector2 (movePace, rigidBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))
		{
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpHeight);
		}
	}
}