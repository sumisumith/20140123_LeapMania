using UnityEngine;
using System.Collections;
using Leap;

public class LeapBehaviourScript : MonoBehaviour {

  Controller controller = new Controller();

  public int FingerCount;
  public GameObject[] FingerObjects;
  public GameObject sphere1;
	public GameObject sphere2;
	public GameObject sphere3;
	public NodeGenerator nodeGenerator;
	private bool collisionFlag = false;
	private const int maxCollisionCounter = 30;
	private int collisionCounter = maxCollisionCounter;
	
  public GameObject count; // sumi

  void Start()
  {
		//nodeGenerator = new NodeGenerator();
  }

  void Update()
  {
		if (collisionFlag && collisionCounter > 0) {
			collisionCounter--;
		}
    Frame frame = controller.Frame();
    FingerCount = frame.Fingers.Count;

    InteractionBox interactionBox = frame.InteractionBox;

    for ( int i = 0; i < FingerObjects.Length; i++ ) {
      var leapFinger = frame.Fingers[i];
      var unityFinger = FingerObjects[i];
      SetVisible( unityFinger, leapFinger.IsValid );
      if ( leapFinger.IsValid ) {
        Vector normalizedPosition = interactionBox.NormalizePoint(leapFinger.TipPosition );
        normalizedPosition *= 10;
        //normalizedPosition.z = -normalizedPosition.z;

	    //オキュラス合体用座標変換

        float theta = 2 * Mathf.PI/8;
        normalizedPosition.y = -normalizedPosition.y;
        float Y = Mathf.Cos(theta) * normalizedPosition.y - Mathf.Sin(theta) * normalizedPosition.z;
        float Z = Mathf.Sin(theta) * normalizedPosition.y + Mathf.Cos(theta) * normalizedPosition.z;
        normalizedPosition.x = -normalizedPosition.x;
normalizedPosition.z = Z;

   
GameObject v = GameObject.Find("OVRCameraController");

   float beta =  2 * Mathf.PI*(v.transform.eulerAngles.y+70)/360 ;

float X = Mathf.Cos(beta) * normalizedPosition.x - Mathf.Sin(beta) * normalizedPosition.z;
        Z = Mathf.Sin(beta) * normalizedPosition.x + Mathf.Cos(beta) * normalizedPosition.z;
         
normalizedPosition.x = X;
        normalizedPosition.y = Y + 8;
        normalizedPosition.z = -Z;
        //合体用終了
        unityFinger.transform.position = ToVector3( normalizedPosition );
      }
    }
  }

  void SetVisible( GameObject obj, bool visible )
  {
    foreach( Renderer component in obj.GetComponents<Renderer>() ) {
      component.enabled = visible;
    }
  }

  Vector3 ToVector3( Vector v )
  {
    return new UnityEngine.Vector3( v.x, v.y, v.z );
  }
	
  void OnCollisionEnter(Collision other)
  {
		Color color;
		Debug.Log("Leap COLLISION!!" + other.gameObject.tag);
        if (other.gameObject.tag == "taiko1" || other.gameObject.tag == "taiko2" || other.gameObject.tag == "taiko3")
        {
			if (collisionFlag && collisionCounter > 0) {
				return;
			} else if (collisionCounter == 0) {
				collisionFlag = false;
				collisionCounter = maxCollisionCounter;
			}
			Debug.Log("Leap Script TAIKO!!");
			color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
			other.gameObject.renderer.material.SetColor("_Color", color);
		} else {
	Debug.Log("other COLLISION!!");
		//DestroyObject(other.gameObject.GetComponent("Sphere1"));
		//nodeGenerator.deleteNode();
	    //var sphere = (Object)GameObject.FindGameObjectWithTag ("Sphere1");
		//var sphere = GameObject.Find ("Sphere");
		//Destroy(sphere);
	    //Singleton<SoundPlayer>.instance.playSE( "se001" );
		}
  }
	
	void OnCollisionExit(Collision other)
	{
		Color color;
		if (other.gameObject.tag == "taiko1") {
			Debug.Log("TAIKO1 Exit!!");
			color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			other.gameObject.renderer.material.SetColor("_Color", color);
			collisionFlag = true;
			
			// sumi
			//Debug.Log("S IN!!");
			//count.GetComponent<Counter>().countUpScore();
			//Debug.Log("S OUT!!");
			
			if (other.gameObject.GetComponent<Taiko1Behavior>().taiko1Flag == true)
			{
				Singleton<SoundPlayer>.instance.playSE( "se001" );
				
				// sumi
				Debug.Log("S IN!!");
				count.GetComponent<Counter>().countUpScore();
				Debug.Log("S OUT!!");
			}
		} else if (other.gameObject.tag == "taiko2") {
			Debug.Log("TAIKO2 Exit!!");
			color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			other.gameObject.renderer.material.SetColor("_Color", color);
			collisionFlag = true;
			
			// sumi
			Debug.Log("S IN!!");
			count.GetComponent<Counter>().countUpScore();
			Debug.Log("S OUT!!");
						
			if (other.gameObject.GetComponent<Taiko2Behavior>().taiko2Flag == true)
			{
				Singleton<SoundPlayer>.instance.playSE( "se001" );
				
				/*// sumi
				Debug.Log("S IN!!");
				count.GetComponent<Counter>().countUpScore();
				Debug.Log("S OUT!!");*/
			}
		} else if (other.gameObject.tag == "taiko3") {
			Debug.Log("TAIKO3 Exit!!");
			color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			other.gameObject.renderer.material.SetColor("_Color", color);
			collisionFlag = true;

			// sumi
			Debug.Log("S IN!!");
			count.GetComponent<Counter>().countUpScore();
			Debug.Log("S OUT!!");			
			
			if (other.gameObject.GetComponent<Taiko3Behavior>().taiko3Flag == true)
			{
				Singleton<SoundPlayer>.instance.playSE( "se001" );

				/*// sumi
				Debug.Log("S IN!!");
				count.GetComponent<Counter>().countUpScore();
				Debug.Log("S OUT!!");*/				
			}
        } else {
	Debug.Log("COLLISION!!");
		}
	}
}
