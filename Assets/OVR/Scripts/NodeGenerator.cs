using UnityEngine;
using System.Collections;

public class NodeGenerator : MonoBehaviour {
	static int fireCount = 10;
	int fire = fireCount;
	NodeManager nodeManager = new NodeManager();
	public GameObject sphere;
	int number = 0;
	public GameObject redPrefab;
	public GameObject bluePrefab;
	public GameObject greenPrefab;
	
	void Start () {
		//redPrefab = new GameObject();
	}
	void Update () {
		//redPrefab = new GameObject();
	//bluePrefab = new GameObject();
	//greenPrefab = new GameObject();
		GameObject leapScene = GameObject.Find("LeapScene");
	Vector3 position1 = new Vector3(45.0f + leapScene.transform.position.x, 58.0f + leapScene.transform.position.y, 65.97943f + leapScene.transform.position.z);
	Vector3 position2 = new Vector3(55.0f + leapScene.transform.position.x, 58.0f + leapScene.transform.position.y, 74.87003f + leapScene.transform.position.z);
	Vector3 position3 = new Vector3(35.0f + leapScene.transform.position.x, 58.0f + leapScene.transform.position.y, 74.87003f + leapScene.transform.position.z);
		if (fire == 0) {
			int nodeNumber = nodeManager.getNode();
			if (nodeNumber == 0) {
			} else if (nodeNumber == 1) {
				sphere = (GameObject)Instantiate(redPrefab, position1, Quaternion.identity);
				sphere.name = "Sphere";
			}  else if (nodeNumber == 2) {
				sphere = (GameObject)Instantiate(bluePrefab, position2, Quaternion.identity);
				sphere.name = "Sphere";
			}  else if (nodeNumber == 3) {
				sphere = (GameObject)Instantiate(greenPrefab, position3, Quaternion.identity);
				sphere.name = "Sphere";
			}
			fire = fireCount;
		} else {
			fire--;
		}
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
	    //Singleton<SoundPlayer>.instance.playSE( "se001" );
  	}
}