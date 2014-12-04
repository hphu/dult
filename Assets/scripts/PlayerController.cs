using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//rate at which player grows
	private float growthRate;
	private Vector3 playerSize;
	//maybe change this to get floor's position dynamically from gameobject later
	private float floorposition = 0.4f;
	private bool isGrounded = true;
	public float speed;
	public float moveY = 0;
	public float jumpHeight;
	//Dimensions of bounding box
	public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
		/*
		renderer.material.color = new Color(0.5f,0.5f,1); //blue for testing
		*/
		Physics.gravity = new Vector3(0,-1122,0);
		this.growthRate = .1f;
		this.playerSize = new Vector3 (1f, 1f, 1f);
	}


	void FixedUpdate () {

		this.transform.localScale = playerSize;

		playerSize.x += (float)(growthRate * Time.deltaTime);
		playerSize.y += (float)(growthRate * Time.deltaTime);

		//if player grew below floor, push up
		//if player's center - half player's height is lower than the floor position
		if (this.transform.localPosition.y - (this.renderer.bounds.size.y / 2) < floorposition) {
			this.transform.position += new Vector3(0, floorposition - (this.transform.localPosition.y - (this.renderer.bounds.size.y / 2)), 0);
		}

		//Movement
		if ((Input.GetKey ("space") || Input.GetKey ("up")) && this.isGrounded) {
			this.moveY += jumpHeight;
		}
		//deaccelerate
		if (this.moveY > 0) {
			this.moveY *= .75f;
		}

		//Retrieves the directional vector and stores in moveHorizontal (-,+)
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//Sets player directional vector from directional input, and 0 for y,z.
		Vector3 movement = new Vector3 (moveHorizontal, moveY, 0.0f);
		//Gives player object's rigid body velocity
		rigidbody.velocity = movement * speed;

		//Bounding
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, xMin, xMax),
			Mathf.Clamp(rigidbody.position.y, yMin, yMax),
			0.0f
		);
	}

	void OnTriggerEnter(Collider a){
		if (a.gameObject.tag == "Floor") {
			this.isGrounded = true;
		}
	}

	void OnTriggerExit(Collider a){
		if (a.gameObject.tag == "Floor") {
			this.isGrounded = false;
		}
	}

	public void IncreaseWidth () 
	{

	}


}
