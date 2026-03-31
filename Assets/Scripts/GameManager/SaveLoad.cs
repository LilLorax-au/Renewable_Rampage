using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    public static void SaveData(GameManager data)//GameManager is the GameManager.cs script, GameManager data script
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Gamesave";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData sedata = new GameData(data);

        formatter.Serialize(stream, sedata);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/Gamesave";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        } else
        {
            Debug.Log("Error: Save file not found in " + path);
            return null;
        }
    }
}
