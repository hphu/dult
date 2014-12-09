using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject food;
	public GameObject badFood;
	public Vector3 spawnValues;
	public int foodCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public Light mainLight;
	private int score;
	private Color[] mainLightColors;
	private int colorCounter = 0;

	void Start()
	{
		score = 0;
		mainLightColors = new Color[5];
		mainLightColors [0] = new Color (.8f, .3f, .3f, 1f);//red
		mainLightColors [1] = new Color (.55f, .94f, .97f, 1f); //cyan
		mainLightColors [2] = new Color (.27f, .41f, .92f, 1f);//blue
		mainLightColors [3] = new Color (.32f, .96f, .56f, 1f);//green
		mainLightColors [4] = new Color (1f, .68f, 0f, 1f);//orange

		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		this.mainLight.color = Color.Lerp (this.mainLight.color, mainLightColors[(colorCounter+1) % mainLightColors.Length], .015f);
		if (this.mainLight.color == mainLightColors [(colorCounter + 1) % mainLightColors.Length]) {
			colorCounter = (colorCounter + 1) % mainLightColors.Length;
		}
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
				if(Random.value >= .2){
					Instantiate (food, spawnPosition, spawnRotation);
				}
				else{
					Instantiate (badFood, spawnPosition, spawnRotation);
				}
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
