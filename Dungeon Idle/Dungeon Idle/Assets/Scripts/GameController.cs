using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
   // public Image Dead_Message;
    public Image playerHPbar;
    public GameController instance;
    public TextMeshProUGUI hpText;

    void Start()
    {
        instance = this;
       // Dead_Message.enabled = false;
        
        PlayerStats.hp = PlayerStats.maxHp;
        Save();

        
    }

    void Update() {
        HealthBar();
    }

    void HealthBar() {
        playerHPbar.fillAmount = PlayerStats.hp / PlayerStats.maxHp;
        hpText.text = PlayerStats.hp + " / " + PlayerStats.maxHp;
        if (PlayerStats.hp <= 0f)
            GameOver();
    }
    void GameOver() {
        Time.timeScale = 0;
        //Dead_Message.enabled = true;
    }
    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
        Debug.Log(Application.persistentDataPath.ToString());

        PlayerData data = new PlayerData();

        bf.Serialize(file, data);
        file.Close();
    }
    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();


        }
    }
}

[Serializable]
class PlayerData {
    // data to save and load
    public float PlayerHP;
    public float experience;
    public int _time, _day, _cash, _exp;
}
