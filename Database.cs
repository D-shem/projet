using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement; 


public class Database : MonoBehaviour {
	public string host;
	public string database;
	public string username;
	public string password;
	public Text TxtState;
	MySqlConnection con;
	public InputField IFLogin;
	public InputField IFPassword;
	public Text TxtLogin;




	struct _Player
	{
		public int ID;
		public string Pseudo;
		public string Password;
		public int Point;
	}

	_Player Player;


	void ConnectBDD () {
		string constr = "Server=" + host +";DATABASE="+database+";User ID="+ username + ";Password=" + password + ";Pooling=true;Charset=utf8;";
		try 
		{
			con=new MySqlConnection (constr);
			con.Open();
			TxtState.text = con.State.ToString ();
		}
		catch(IOException Ex)
		{
			TxtState.text = Ex.ToString ();
		}
		
	}
	

	void Update () {
		
	}

	void OnApplicationQuit()
	{
		Debug.Log("Shutdown Connexion");

		if(con !=null && con.State.ToString()!="Closed")
		{
			con.Close();
		}
	}

	public void Register()
	{
		ConnectBDD ();
		bool Exist = false;


		//Verification existance pseudo
		MySqlCommand commandsql = new MySqlCommand ("SELECT pseudo FROM users WHERE pseudo = '" + IFLogin.text +"'",con);
		MySqlDataReader MyReader = commandsql.ExecuteReader ();

		while (MyReader.Read ()) 
		{
			if (MyReader ["pseudo"].ToString () != "") 
			{
				TxtLogin.text = "Pseudo Exist!";
				Exist = true;

			}
		}
		MyReader.Close ();

		if(!Exist)
		{
			string command = "INSERT INTO users VALUES (default,'" + IFLogin.text + "','" + IFPassword.text + "','')";
			MySqlCommand cmd = new MySqlCommand (command, con);

			try
			{
				cmd.ExecuteReader();
				TxtLogin.text = "Register succesfull";
			}
			catch(IOException Ex) {
				TxtState.text = Ex.ToString ();}

				cmd.Dispose ();
				con.Close ();	
		   }
		}

	  public void Login()
	{
		ConnectBDD ();
		string pass = null;

		try {
			MySqlCommand commandesql = new MySqlCommand ("SELECT * FROM users WHERE pseudo = '" + IFLogin.text + "'", con);
			MySqlDataReader MyReader = commandesql.ExecuteReader ();

			while (MyReader.Read ()) {
				pass = MyReader ["password"].ToString ();

				if (pass == IFPassword.text)
				{
					Player.ID=(int)MyReader["ID"];
					Player.Pseudo = MyReader["pseudo"].ToString();
					Player.Password = MyReader["password"].ToString();
					Player.Point = (int)MyReader["point"];
					TxtLogin.text = "Your ID " + Player.ID + System.Environment.NewLine + "Point " + Player.Point ;
					SceneManager.LoadScene("Menu");

				} 
				else {
					TxtLogin.text = "Invalid Pseudo/password";
				}

			}
			if(pass==null)
			{
				TxtLogin.text = "No Exist account";	
			}

			MyReader.Close ();
		} catch (IOException Ex) {
			TxtState.text = Ex.ToString ();
		}

		con.Close ();




	}
}

