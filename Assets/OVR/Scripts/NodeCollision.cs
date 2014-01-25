using UnityEngine;
using System.Collections;

public class NodeCollision : MonoBehaviour {
	
	void Start () {
		//redPrefab = new GameObject();
	}
	void Update () {
	}

	void OnCollisionEnter(Collision other)
  	{
		Debug.Log("Sphere Collosion");
		
		//DestroyObject(other.gameObject.GetComponent("Sphere1"));
		//nodeGenerator.deleteNode();
	    //var sphere = (Object)GameObject.FindGameObjectWithTag ("Sphere1");
		var sphere = GameObject.Find ("Sphere");
		//var bgmPlayer = GameObject.Find ("BGMPlayer");
		//Component component = bgmPlayer.GetComponent("NodeGenerator");
		//component.gameObject
		//var nodeGenerator = GameObject.Find("");
		Destroy(sphere);
	    Singleton<SoundPlayer>.instance.playSE( "se001" );
  	}
}
