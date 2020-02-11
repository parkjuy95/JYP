using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundonoffbtn: MonoBehaviour {

    public GameObject Panel;
    public GameObject onbtn;
    public GameObject offbtn;
    

    void Start () {
		onbtn.SetActive (false);
        offbtn.SetActive(true);
    }
	// Use this for initialization
	
	void Update()
	{
		if (PlayerPrefs.GetInt("sound") == 0) 
		{
			showhideonbtn ();
		} 
		else 
		{
			showhideoffbtn ();
		}
	}
			
		
	public void showhideonbtn()
	{	
		PlayerPrefs.SetInt ("sound", 0);
        onbtn.SetActive(false);
        offbtn.SetActive(true);
    }

	public void showhideoffbtn()
	{
		PlayerPrefs.SetInt ("sound", 1);
        offbtn.SetActive(false);
        onbtn.SetActive(true);
	}

    public void SoundPanelOn()
    {
        Panel.SetActive(true);
    }

    public void SoundPanelOff()
    {
        Panel.SetActive(false);
    }
}
