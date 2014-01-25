using UnityEngine;
using System.Collections;

public class Taiko3Behavior : MonoBehaviour {
	
	public bool taiko3Flag;
	private const int maxCollisionCounter = 10;
	private int collisionCounter;
	
	// Use this for initialization
	void Start () {
		taiko3Flag = false;
		collisionCounter = maxCollisionCounter;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("taiko3 flag:" + taiko3Flag);
		if (taiko3Flag && collisionCounter > 0) {
			collisionCounter--;
		}
		if (collisionCounter == 0)
		{
			taiko3Flag = false;
			collisionCounter = maxCollisionCounter;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Sphere3")
		{
			Debug.Log("TAIKO3 behavior Collision!!");
			taiko3Flag = true;
		}
	}
}

