using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class PlayerInventory {

    public static List<Item> items = new List<Item>();

    public static void AddItem(Item i) {
        items.Add(i);
        //Update UI
    }

    public static Item GetItem(int i) {
        return items[i];
    }

    public static void UseItem(int i) {
        items.RemoveAt(i);
        //Trigger Event
    }

    public static void LoadInventory() {
        CreateFile();
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/PlayerInventory.txt", Encoding.Default);
        string rawData = reader.ReadLine();
        string[] splitData = rawData.Split(',');
        reader.Close();

        //!! Save data to game manager here !!
        List<Item> tempList = new List<Item>();
        for (int i = 0; i < splitData.Length; i++) {
            tempList.Add(ItemInfo.instance.GetItem(splitData[i]));
        }
        items = tempList;
        Debug.Log("Load Successful.");
    }

    public static void SaveInventory() {
        CreateFile();
        StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/PlayerInventory.txt");
        sr.WriteLine(GetData());
        sr.Close();
        Debug.Log("Save Successful.");
    }

    /// <summary>
	/// Creates a data file if one does not already exist
	/// </summary>
	static void CreateFile() {
        if (!File.Exists(Application.persistentDataPath + "/PlayerInventory.txt")) {
            StreamWriter sr = File.CreateText(Application.persistentDataPath + "/PlayerInventory.txt");
            //sr.WriteLine(GetData());
			sr.WriteLine("Sample Item");
            sr.Close();
        }
    }

    /// <summary>
    /// Receives all important data from game manager to be saved
    /// </summary>
    /// <returns>The data.</returns>
    public static string GetData() {

        string toReturn = "";

        //!! Append data here !!
        for (int i = 0; i < items.Count; i++) {
            toReturn += items[i].name;
            if (i < items.Count - 1) {
                toReturn += ',';
            }
        }
        Debug.Log("GetData(): " + toReturn);

		//TESTING ONLY - IF FILE IS EMPTY, RETURN 'SAMPLE ITEM' TO ENSURE ITEM IS AVAILABLE
		if (items.Count == 0) {
			toReturn = "Sample Item";
		}
		//END TESTING

        return toReturn;
    }
}
