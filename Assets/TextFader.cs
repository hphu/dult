using UnityEngine;
using System.Collections;

public class TextFader : MonoBehaviour {

	private Color color;
	private float fadeSpeed = .01f;
	// Use this for initialization
	void Start () {
		this.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = this.color;
		this.color.a -= fadeSpeed;
	}

	public void initialize(string text){
		GetComponent<TextMesh> ().text = text;
		this.transform.position -= new Vector3 (this.renderer.bounds.size.x/2, -2, 0);

	}
}
