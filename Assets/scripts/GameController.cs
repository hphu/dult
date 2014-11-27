using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject food;
	public Vector3 spawnValues;
	public int foodCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public int score;
	
	void Start()
	{
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new  WaitForSeconds (startWait);
		
		while (true) 
		{
			for (int i = 0; i <= foodCount; i++) 
			{	
				//Sets x random range(play field), and set values.
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				//Sets no rotation
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (food, spawnPosition, spawnRotation);
				yield return new  WaitForSeconds (spawnWait);
			}
			yield return new  WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
}
