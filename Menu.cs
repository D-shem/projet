using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jouer()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void Create()
	{
		SceneManager.LoadScene ("creation de personnage1");
	}


	public void Option()
	{
		
		GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Option").GetComponent<Canvas>().enabled = true;

	}


	public void Deconnection()
	{
		SceneManager.LoadScene ("essaie 5");
	}
		

	public void Quitter()
	{
		Application.Quit();
	}
}
