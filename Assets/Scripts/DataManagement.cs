﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour
{
    public static DataManagement datamanagement;

    public int highScore = 0;

    private void Awake()
    {
        if(datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        } else if(datamanagement != this){
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //creates a binary formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //creates file
        gameData data = new gameData(); //creates container for data
        data.highscore = highScore;
        BinForm.Serialize(file, data); //serializes
        file.Close(); //closes file
    }

    public void LoadData()
    {
        if(File.Exists (Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            highScore = data.highscore;
        }
    }

}

[Serializable]
class gameData
{
    public int highscore;

}
