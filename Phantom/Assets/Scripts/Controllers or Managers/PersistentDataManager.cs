using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public static class PersistentDataManager {
	public static string dialogue;

	/// <summary>
	/// Creates a data file if one does not already exist
	/// </summary>
	static void CreateFile(){
		if (!File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
		{
			StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerData.txt");
			sr.WriteLine("00000000000000000000");
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

		//!! Save data to game variables here !!
		dialogue = splitData[0];

	}

	/// <summary>
	/// Receives all important data from game manager to be saved
	/// </summary>
	/// <returns>The data.</returns>
	public static string GetData(){

		string toReturn = "";

		//SAVE DIALOGUE CHOICES
		toReturn += dialogue;
		Debug.Log ("GetData(): " + toReturn);

		return toReturn;
	}

	public static void SetData(int index, char data){
		char[] temp = dialogue.ToCharArray();
		temp [index] = data;
		dialogue = CtoS(temp);
		SaveData ();
	}

	public static string CtoS(char[] ca){
		string data = "";
		foreach (char c in ca) {
			data += c;
		}

		return data;
	}
}

public enum Data{
	DefaultData = 0,
}
