using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stopscript : MonoBehaviour {
	
	public GameObject Panel;
	int counter;

	void Start () {
		Panel.gameObject.SetActive (false);
	}
	// Use this for initialization

	public void showhidePanel()
	{
		counter++;
		if (counter % 2 ==1) {
			Panel.gameObject.SetActive (true);	
		} else 	{
			Panel.gameObject.SetActive (false);
				}
	}
}
