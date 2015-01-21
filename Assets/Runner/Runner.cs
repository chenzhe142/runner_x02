using UnityEngine;
using System.Collections; 

public class Runner : MonoBehaviour {
	
	public static float distanceTraveled;
	public static float score;

	private static int boosts;
	private static int jumper;
	private static int upper;

	
	public float acceleration;
	public Vector3 boostVelocity, jumpVelocity;
	public float gameOverY;

	public Vector3 JumperVelocity;
	public Vector3 UpperOffset;
	
	private bool touchingPlatform;
	private Vector3 startPosition;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}
	
	void Update () {
		if(Input.GetButtonDown("Jump")){
			if(touchingPlatform){
				rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
				touchingPlatform = false;
			}
			else {
				if(boosts > 0){
					rigidbody.AddForce(boostVelocity, ForceMode.VelocityChange);
					boosts -= 1;
					GUIManager.SetBoosts(boosts);
				}


			}
				
		}
		if(jumper > 0){
			rigidbody.AddForce(JumperVelocity, ForceMode.VelocityChange);
			jumper -= 1;
		}

		distanceTraveled = transform.localPosition.x;

		GUIManager.SetDistance(distanceTraveled + upper * 20);
		
		if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}
	
	void FixedUpdate () {
		if(touchingPlatform){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}
	
	void OnCollisionEnter () {
		touchingPlatform = true;
	}
	
	void OnCollisionExit () {
		touchingPlatform = false;
	}


	
	private void GameStart () {
		boosts = 0;
		jumper = 0;
		upper = 0;
		GUIManager.SetBoosts(boosts);

		distanceTraveled = 0f;
		score = 0f;

		GUIManager.SetDistance(score);
		transform.localPosition = startPosition;
		renderer.enabled = true;
		rigidbody.isKinematic = false;
		enabled = true;
	}
	
	private void GameOver () {
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}


	
	public static void AddBoost(){
		boosts += 1;
		GUIManager.SetBoosts(boosts);
	}

	public static void AddJumper(){
		jumper += 1;
//		GUIManager.SetBoosts(boosts);
	}

	public static void AddUpper(){
		upper += 1;
	}

}