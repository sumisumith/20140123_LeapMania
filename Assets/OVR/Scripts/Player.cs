using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    void Update () {
        if ( Input.GetKeyDown(KeyCode.A) == true ) {
            // Torigger
            Singleton<SoundPlayer>.instance.playSE( "se001" );
			Debug.Log("A");
        }
    }
}