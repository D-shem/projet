using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCreate : MonoBehaviour {

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

	public void Retour()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void NomPersonnage()
	{
		string NomPersonnage = "";
	}
		
	public void saveData()
	{
		Debug.Log ("On sauve les donnée " + Application.persistentDataPath);
	}

}