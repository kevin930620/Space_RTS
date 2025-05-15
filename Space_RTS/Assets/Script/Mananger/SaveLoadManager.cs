using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveLoadManager : MonoBehaviour
{
	public List<GameObject> objectPrefab = new List<GameObject>();
    public void Save()
	{
		ShipBase[] shipBases = FindObjectsByType<ShipBase>(FindObjectsSortMode.None);
		SaveDataWrapper saveDataWrapper = new SaveDataWrapper();
		foreach (ShipBase shipBase in shipBases)
		{
			saveDataWrapper.objects.Add(shipBase.GetData());
		}
		string json = JsonUtility.ToJson(saveDataWrapper);
		File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Saved to: " + Application.persistentDataPath + "/save.json");
	}
	public void LoadAll()
	{
		string path = Application.persistentDataPath + "/save.json";
		if (!File.Exists(path))
		{
			Debug.LogWarning("Save file not found!");
			return;
		}

		string json = File.ReadAllText(path);
		SaveDataWrapper saveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(json);


		foreach (ObjectSaveData data in saveDataWrapper.objects)
		{
			if(data.type == "Destroyer")
			{
				GameObject gameObject = Instantiate(objectPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
				gameObject.GetComponent<ShipBase>().ApplyData(data);
			}
			else if (data.type == "ConstructionShip")
			{
				GameObject gameObject = Instantiate(objectPrefab[1], new Vector3(0, 0, 0), Quaternion.identity);
				gameObject.GetComponent<ShipBase>().ApplyData(data);
			}
		}
	}
}
