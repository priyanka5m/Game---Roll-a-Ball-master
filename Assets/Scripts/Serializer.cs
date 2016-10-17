using UnityEngine;
using System.IO;

public class Serializer : MonoBehaviour
{
    public GameObject player;
    static readonly string SAVE_FILE = "saveplayer.json";
    public GameObject collectable;
    void Start()
    {
        SaveData data = new SaveData() { name = "John", armour = 5, items = new System.Collections.Generic.List<string>(),
            position = player.transform.position,
            rotation = player.transform.rotation
        };
        data.items.Add("Sword");
        data.items.Add("Gun");
        data.items.Add("Map");

        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

        if (File.Exists(filename))
        {
            File.Delete(filename);
        }

        File.WriteAllText(filename, json);
        Debug.Log("Player saved to" + filename);

        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        Debug.Log(copy.name);

        player.transform.position = copy.position;
        player.transform.rotation = copy.rotation;
    }


}