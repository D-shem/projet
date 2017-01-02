using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Retour()
	{
		{

			GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Menu").GetComponent<Canvas>().enabled = true;

		}
	}
}
