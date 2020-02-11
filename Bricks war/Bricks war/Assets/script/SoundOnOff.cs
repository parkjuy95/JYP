using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnOff : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            AudioListener.volume = 1;
        }
        else
            AudioListener.volume = 0;
	}
}
