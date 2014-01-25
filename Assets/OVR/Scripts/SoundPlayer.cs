using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer {

    GameObject soundPlayerObj;
    AudioSource audioSource;
	BGMPlayer gameBGMPlayer;
    Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();

    // AudioClip information
    class AudioClipInfo {
        public string resourceName;
        public string name;
        public AudioClip clip;

        public AudioClipInfo( string resourceName, string name ) {
            this.resourceName = resourceName;
            this.name = name;
        }
    }

    public SoundPlayer() {
        audioClips.Add( "se001", new AudioClipInfo( "se_maoudamashii_onepoint15", "se001" ) );
        audioClips.Add( "bgm001", new AudioClipInfo( "Final-Battle01_loop", "bgm001" ) );
    }

    public bool playSE( string seName ) {
        if ( audioClips.ContainsKey( seName ) == false )
            return false; // not register

        AudioClipInfo info = audioClips[ seName ];

        // Load
        if ( info.clip == null )
            info.clip = (AudioClip)Resources.Load( info.resourceName );

        if ( soundPlayerObj == null ) {
            soundPlayerObj = new GameObject( "SoundPlayer" );
            audioSource = soundPlayerObj.AddComponent<AudioSource>();
        }

        // Play SE
        audioSource.PlayOneShot( info.clip );

        return true;
    }
	
	public void playBGM( string bgmName ) {
    // play new BGM
    if ( audioClips.ContainsKey( bgmName ) == false ) {
        // null BGM
        gameBGMPlayer = new BGMPlayer();
    } else {
        gameBGMPlayer = new BGMPlayer( audioClips[ bgmName ].resourceName );
        gameBGMPlayer.playBGM(  );
		
    }
}
}