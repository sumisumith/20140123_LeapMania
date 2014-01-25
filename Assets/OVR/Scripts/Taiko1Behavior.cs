using UnityEngine;
using System.Collections;

public class Taiko1Behavior : MonoBehaviour {
	
	public bool taiko1Flag;
	private const int maxCollisionCounter = 10;
	private int collisionCounter;
	
	// Use this for initialization
	void Start () {
		taiko1Flag = false;
		collisionCounter = maxCollisionCounter;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("taiko1 flag:" + taiko1Flag);
		if (taiko1Flag && collisionCounter > 0) {
			collisionCounter--;
		}
		if (collisionCounter == 0)
		{
			taiko1Flag = false;
			collisionCounter = maxCollisionCounter;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Sphere1")
		{
			Debug.Log("TAIKO1 behavior Collision!!");
			taiko1Flag = true;
		}
	}
}

