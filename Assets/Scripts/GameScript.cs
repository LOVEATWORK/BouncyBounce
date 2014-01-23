using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public Rect labelPosition;
	string labelText;
	public GUIStyle labelStyle;
	int score = 0;
	GameObject player;
	HealthScript health;

	//Set labelPosition public so it can be changed in inspector (editor). 

	void Start() {

		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent<HealthScript> ();

	}

	void Update()
	{
		score+=1;
		labelText = "Health: " + health.HP.ToString ();
	}
	
	void OnGUI()
	{
		GUI.Label(labelPosition, labelText, labelStyle);
	}
}
