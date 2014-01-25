using UnityEngine;
using System.Collections;

public class GameBGMPlayer : MonoBehaviour {
	bool start = false;
	//static int fireCount = 20;
	//static int fireCount = 40;
	//int fire = fireCount;
	//NodeManager nodeManager = new NodeManager();
	
    void Update () {
		if (!start) {
        	Singleton<SoundPlayer>.instance.playBGM( "bgm001" );
			start = true;
		}
		
		//if (fire == 0) {
		//	Debug.Log(nodeManager.getNode().ToString());
		//	fire = fireCount;
		//} else {
		//	fire--;
		//}
    }
}