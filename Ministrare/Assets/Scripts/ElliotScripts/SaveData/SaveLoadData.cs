using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "Save/Load Data", menuName = "Ministrare/SingletonVars/SaveLoadData", order = 3)]
public class SaveLoadData : ScriptableObject
{

    public List<TechTree> techTrees;
    public List<StructureManager> structures;
    public TimerTime timer;
    public ResourceManager playerResources;
    public LeaderStatsObject playerStats;

    string dataPath;

    public void OnEnable()
    {
        //    if (!(Directory.Exists(Application.persistentDataPath + "/SaveData")))
        //        Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
        //    LoadData();
       
        if (!(Directory.Exists(Application.persistentDataPath + "/SaveData")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
            dataPath = Application.persistentDataPath + "/SaveData";
        }
        else
            dataPath = Application.persistentDataPath + "/SaveData";
    }

    //public void OnDisable()
    //{
    //    SaveData();
    //}

    public void SaveData()
    {
        SaveTechTrees();
        SaveStructures();
        SaveTimer();
        SaveResources();
        SavePlayer();
    }

    void SaveTechTrees()
    {
        for (int x = 0; x < techTrees.Count; x++)
        {
            BinaryFormatter myFormatter = new BinaryFormatter();
            //FileStream file = File.Create(
            //        Application.persistentDataPath +
            //        string.Format("/SaveData/{0}.pso", techTrees[x].name)
            //        );

            FileStream file = File.Create(dataPath + string.Format("/{0}.pso", techTrees[x].name));

            var json = JsonUtility.ToJson(techTrees[x]);
            myFormatter.Serialize(file, json);
            file.Close();
        }
    }
    void SaveStructures()
    {
        for (int x = 0; x < structures.Count; x++)
        {
            BinaryFormatter myFormatter = new BinaryFormatter();
            //FileStream file = File.Create(
            //        Application.persistentDataPath +
            //        string.Format("/SaveData/{0}.pso", structures[x].name)
            //        );

            FileStream file = File.Create(dataPath + string.Format("/{0}.pso", structures[x].name));

            var json = JsonUtility.ToJson(structures[x]);
            myFormatter.Serialize(file, json);
            file.Close();
        }
    }
    void SaveTimer()
    {
        BinaryFormatter myFormatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/SaveData/Timer.pso");
        FileStream file = File.Create(dataPath + "/Timer.pso");
        var json = JsonUtility.ToJson(timer);
        myFormatter.Serialize(file, json);
        file.Close();
    }
    void SaveResources()
    {
        BinaryFormatter myFormatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/SaveData/PlayerResources.pso");
        FileStream file = File.Create(dataPath + "/PlayerResources.pso");
        var json = JsonUtility.ToJson(file, playerResources);
        myFormatter.Serialize(file, json);
        file.Close();
    }
    void SavePlayer()
    {
        BinaryFormatter myFormatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/SaveData/PlayerStats.pso");
        FileStream file = File.Create(dataPath + "/PlayerStats.pso");
        var json = JsonUtility.ToJson(file, playerStats);
        myFormatter.Serialize(file, json);
        file.Close();
    }


    public void LoadData()
    {
        LoadTechTrees();
        LoadStructures();
        LoadTimer();
        LoadResources();
        LoadPlayer();
    }

    void LoadTechTrees()
    {
        for (int x = 0; x < techTrees.Count; x++)
        {
            if (File.Exists(dataPath + string.Format("/{0}.pso", techTrees[x].name)))
            {
                BinaryFormatter myFormatter = new BinaryFormatter();
                FileStream file = File.Open(
                    dataPath + string.Format("/{0}.pso", techTrees[x].name),
                    FileMode.Open
                    );
                JsonUtility.FromJsonOverwrite((string)myFormatter.Deserialize(file), techTrees[x]);
                file.Close();
            }
        }
    }
    void LoadStructures()
    {
        for (int x = 0; x < structures.Count; x++)
        {
            if (File.Exists(dataPath + string.Format("/{0}.pso", structures[x].name)))
            {
                BinaryFormatter myFormatter = new BinaryFormatter();
                FileStream file = File.Open(
                    dataPath + string.Format("/{0}.pso", structures[x].name),
                    FileMode.Open
                    );
                JsonUtility.FromJsonOverwrite((string)myFormatter.Deserialize(file), structures[x]);
                file.Close();
            }
        }
    }
    void LoadTimer()
    {
        if (File.Exists(dataPath + "/Timer.pso"))
        {
            BinaryFormatter myFormatter = new BinaryFormatter();
            FileStream file = File.Open(dataPath + "/Timer.pso", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)myFormatter.Deserialize(file), timer);
            file.Close();
        }
    }
    void LoadResources()
    {
        if (File.Exists(dataPath + "/PlayerResources.pso"))
        {
            BinaryFormatter myFormatter = new BinaryFormatter();
            FileStream file = File.Open(dataPath + "/PlayerResources.pso", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)myFormatter.Deserialize(file), playerResources);
            file.Close();
        }
    }
    void LoadPlayer()
    {
        if (File.Exists(dataPath + "/PlayerStats.pso"))
        {
            BinaryFormatter myFormatter = new BinaryFormatter();
            FileStream file = File.Open(dataPath + "/PlayerStats.pso", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)myFormatter.Deserialize(file), playerStats);
            file.Close();
        }
    }

    public void ClearSave()
    {
        for (int x = 0; x < 5; x++)
        {
            File.Delete(dataPath + string.Format("/{0}.pso", techTrees[x].name));

            File.Delete(dataPath + string.Format("/{0}.pso", structures[x].name));
        }

        File.Delete(dataPath + "/Timer.pso");
        File.Delete(dataPath + "/PlayerResources.pso");
        File.Delete(dataPath + "/PlayerStats.pso");
    }
}