using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public int scoreValue;
	public GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
				}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {

		Destroy (gameObject);
		gameController.AddScore (scoreValue);
	}
}
