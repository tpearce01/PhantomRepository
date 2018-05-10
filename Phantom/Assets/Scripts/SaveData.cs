using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using System.Security.Cryptography;

public static class SaveData {
    public static List<string> oneTimeEventsCompleted = new List<string>();

    /// <summary>
    /// Creates a data file if one does not already exist
    /// </summary>
    static void CreateFile() {
        if (!File.Exists(Application.persistentDataPath + "/SaveData.txt")) {
            StreamWriter sr = File.CreateText(Application.persistentDataPath + "/SaveData.txt");
            sr.WriteLine(GetData());
            sr.Close();
        }
    }

    /// <summary>
    /// Receives all important data to be saved
    /// </summary>
    /// <returns>The data.</returns>
    public static string GetData() {
        return JsonUtility.ToJson(new PlayerData());
    }

    /// <summary>
    /// Save data to file
    /// </summary>
    public static void AutoSave() {
        if (Config.AutoSave) {
            Save();
        }
    }

    public static void Save() {
        CreateFile();
        StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/SaveData.txt");
        sr.WriteLine(GetData());
        sr.Close();
        Debug.Log("Save Data Successful");
    }

    /// <summary>
    /// Load data from file
    /// </summary>
    public static void Load() {
        CreateFile();
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/SaveData.txt", Encoding.Default);
        string rawData = reader.ReadToEnd();
        reader.Close();

        PlayerData data = JsonUtility.FromJson<PlayerData>(rawData);
        data.Load();
        Debug.Log("Load Data Successful");
    }
}

// As new data needs to be added to the save file, add it to this class so it may easily be converted to json format and saved
// JsonUtility only gathers the public fields, so make sure members are all public
[System.Serializable]
public class PlayerData {
    public string[] inventory;
    public List<string> oneTimeEventsCompleted;

    // This constructor is used to gather the save data
    // When adding a new piece of data to save, make sure to get the data in this constructor
    public PlayerData() {
        inventory = Inventory.GetInventoryString();
        oneTimeEventsCompleted = SaveData.oneTimeEventsCompleted;
    }

    // Used when loading from save data. Make sure to assign all members of PlayerData
    public void Load() {
        Inventory.SetInventory(inventory);
        SaveData.oneTimeEventsCompleted = oneTimeEventsCompleted;
    }
}