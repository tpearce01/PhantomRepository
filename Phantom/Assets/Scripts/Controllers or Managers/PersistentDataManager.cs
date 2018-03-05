using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public static class PersistentDataManager {
	/// <summary>
	/// Creates a data file if one does not already exist
	/// </summary>
	static void CreateFile(){
		if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
		{
			StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
			sr.WriteLine(GetData());
			sr.Close();
		}
	}

	/// <summary>
	/// Writes data to a file
	/// </summary>
	public static void SaveData(){
		CreateFile ();
		StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerData.txt");
		sr.WriteLine(GetData());
		sr.Close();
	}

	/// <summary>
	/// Loads data from a file
	/// </summary>
	public static void LoadData(){
		CreateFile ();
		StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerData.txt", Encoding.Default);
		string rawData = reader.ReadLine();
		string[] splitData = rawData.Split(',');
		reader.Close();

		//!! Save data to game manager here !!
	}

	/// <summary>
	/// Receives all important data from game manager to be saved
	/// </summary>
	/// <returns>The data.</returns>
	public static string GetData(){

		string toReturn = "";

		//!! Append data here !!

		Debug.Log ("GetData(): " + toReturn);

		return toReturn;
	}
}

public enum Data{
	DefaultData = 0,
}
