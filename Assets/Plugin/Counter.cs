using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

	private int c;
	//public GameObject count;
	
	void Start()
  	{
		
 	}

	/*void Update()
	{
		c++;
		//Debug.Log(c+"!!");
		
		GameObject count = GameObject.Find("SCount"); 
		TextMesh tm = (TextMesh)count.GetComponent("TextMesh"); 
		tm.text = "score " + c;
	}*/
	
	public void countUpScore()
	{
		c++;
		Debug.Log("score" + c + "!!");
		
		GameObject count = GameObject.Find("SCount"); 
		TextMesh tm = (TextMesh)count.GetComponent("TextMesh"); 
		tm.text = "score " + c;
	}
	
}

