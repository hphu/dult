using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//rate at which player grows
	private float growthRate;
	private Vector3 playerSize;
	//maybe change this to get floor's position dynamically from gameobject later
	private float floorposition = 0.4f;
	private bool isGrounded = true;
	public float fattening;
	public float speedDecrease;
	public float speed;
	public float moveY = 0;
	public float jumpHeight;
	//Dimensions of bounding box
	public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0,-1122,0);
		this.growthRate = .1f;
		this.playerSize = new Vector3 (1f, 1f, 1f);

		//set Xmin/Xmax based on camera view
		/*float cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
		xMin = Camera.main.ViewportToWorldPoint(new Vector3(0,0, cameraDistance)).x;
		xMax = Camera.main.ViewportToWorldPoint(new Vector3(1,1, cameraDistance)).x; */
	}


	void FixedUpdate () {

		this.transform.localScale = playerSize;

		playerSize.x += (float)(growthRate * Time.deltaTime);
		playerSize.y += (float)(growthRate * Time.deltaTime);

		//if player grew below floor, push up
		//if player's center - half player's height is lower than the floor position
		if (this.transform.localPosition.y - playerSize.y/2 < floorposition) {
			this.transform.position += new Vector3(0, floorposition - (this.transform.localPosition.y - playerSize.y/2), 0);
		}

		//Jump Movement
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
			Mathf.Clamp (rigidbody.position.x, xMin + playerSize.x/2, xMax - playerSize.x/2),
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
		playerSize.x += fattening;
		this.speed -= speedDecrease;
	}


}
