using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public int scoreValue;
	public GameObject textObject;
	public string text;
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
		Destroy (gameObject);	
		if (other.tag == "Player") {
			var obj = (GameObject)Instantiate(textObject, transform.position, transform.rotation);
			obj.GetComponent<TextFader>().initialize(this.text);

			gameController.AddScore (scoreValue);
			if (this.tag == "BadFood") {
				playerController.IncreaseWidth();
			}
		}


	}
}
