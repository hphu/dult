using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//rate at which player grows
	private float growthRate;
	private Vector3 playerSize;
	//maybe change this to get floor's position dynamically from gameobject later
	private float floorposition = .5f;
	public float speed;
	//Dimensions of bounding box
	public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color(0.5f,0.5f,1); //blue for testing
		this.growthRate = .1f;
		this.playerSize = new Vector3 (1f, 1f, 1f);
	}


	void FixedUpdate () {
		Debug.Log (this.renderer.bounds.size);
		Debug.Log (this.transform.localPosition.y);

		this.transform.localScale = playerSize;

		playerSize.x += (float)(growthRate * Time.deltaTime);
		playerSize.y += (float)(growthRate * Time.deltaTime);

		//if player grew below floor, push up
		//This causes the box to float in the air
		if (this.transform.localPosition.y - (this.renderer.bounds.size.y / 2) < floorposition) {
			this.transform.position += new Vector3(0, growthRate* Time.deltaTime, 0);
		}

		//Movement
		//Retrieves the directional vector and stores in moveHorizontal (-,+)
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//Sets player directional vector from directional input, and 0 for y,z.
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
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


		

		
	

}
