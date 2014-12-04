using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public int scoreValue;
	private GameController gameController;
	private PlayerController playerController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
				}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController>();
		}
		if (playerController == null) {
			Debug.Log ("Cannot find 'playerController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other);
		Debug.Log (this.gameObject);
		Destroy (gameObject);	
		if (other.tag == "Player") {
			gameController.AddScore (scoreValue);
			if (this.tag == "BadFood") {playerController.IncreaseWidth();}
		}


	}
}
