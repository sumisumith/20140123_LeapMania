using UnityEngine;
using System.Collections;

public class Taiko2Behavior : MonoBehaviour {
	
	public bool taiko2Flag;
	private const int maxCollisionCounter = 10;
	private int collisionCounter;
	
	// Use this for initialization
	void Start () {
		taiko2Flag = false;
		collisionCounter = maxCollisionCounter;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("taiko2 flag:" + taiko2Flag);
		if (taiko2Flag && collisionCounter > 0) {
			collisionCounter--;
		}
		if (collisionCounter == 0)
		{
			taiko2Flag = false;
			collisionCounter = maxCollisionCounter;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Sphere2")
		{
			Debug.Log("TAIKO2 behavior Collision!!");
			taiko2Flag = true;
		}
	}
}

