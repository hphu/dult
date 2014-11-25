using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//rate at which player grows
	private float growthRate;
	private Vector3 playerSize;
	//maybe change this to get floor's position dynamically from gameobject later
	private float floorposition = .5f;

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color(0.5f,0.5f,1); //blue for testing
		this.growthRate = .1f;
		this.playerSize = new Vector3 (1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (this.renderer.bounds.size);
		Debug.Log (this.transform.localPosition.y);

		this.transform.localScale = playerSize;

		playerSize.x += (float)(growthRate * Time.deltaTime);
		playerSize.y += (float)(growthRate * Time.deltaTime);

		//if player grew below floor, push up
		if (this.transform.localPosition.y - (this.renderer.bounds.size.y / 2) < floorposition) {
			this.transform.position += new Vector3(0, growthRate* Time.deltaTime, 0);
		}

	}
}
