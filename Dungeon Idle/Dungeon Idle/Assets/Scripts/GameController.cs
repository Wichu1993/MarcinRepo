﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    public Image playerHPbar;
    [SerializeField]
    public float PlayerHP;
    public static float start_PlayerHP = 100f;
    public static GameController instance = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerHP = start_PlayerHP;
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPbar.fillAmount = PlayerHP / start_PlayerHP;
        if (PlayerHP <= 0f)
            GameOver();
    }

    void GameOver() {
        Time.timeScale = 0;
        // dodać wiadomość że zostałeś pokonany
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath.ToString());

        PlayerData data = new PlayerData();
        data.PlayerHP = PlayerHP;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            PlayerHP = data.PlayerHP;

        }
    }
}

[Serializable]
class PlayerData {
    public float PlayerHP;
    public float experience;
}