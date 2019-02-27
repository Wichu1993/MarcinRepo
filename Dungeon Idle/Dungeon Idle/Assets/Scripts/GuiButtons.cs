using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiButtons : MonoBehaviour {
    public bool City = false;
    public GameObject _cityGui;

    public float BankCost;
    public float BaseBankCost = 200;

    public float BarracksCost;
    public float BaseBarracksCost = 150;

    public float WallCost;
    public float BaseWallCost = 100;

    public float WatchTowerCost;
    public float BaseWatchTowerCost = 5000;

    public TextMeshProUGUI BankLVL;
    public TextMeshProUGUI BarracksLVL;
    public TextMeshProUGUI WallLVL;
    public TextMeshProUGUI watchTowerLVL;
    public TextMeshProUGUI _BankCost;
    public TextMeshProUGUI _BarracksCost;
    public TextMeshProUGUI _WallCost;
    public TextMeshProUGUI _watchTowerCost;

    public TextMeshProUGUI _gold;


    public TMP_Dropdown dropdown;

    private void Start() {
        City = false;
        dropdown.value = 0;
        BaseSet();
        UpdateText();
        CityGUI();
        
    }
    private void BaseSet() {
        BaseBankCost = 200;
        BaseBarracksCost = 150;
        BaseWallCost = 100;
        BaseWatchTowerCost = 5000;
        PlayerStats.baseHp = 100f;
        PlayerStats.hp = PlayerStats.baseHp;
    }


    public void CityGUI() {
        if (!City) {
            City = true;
            _cityGui.SetActive(City);
        }
        else if (City) {
            City = false;
            _cityGui.SetActive(City);
        }
        UpdateText();
    }

    private void Update() {
        
        
        BarracksCost = BaseBarracksCost * PlayerStats.Day;
        WallCost = BaseWallCost * PlayerStats.Day;
        WatchTowerCost = BaseWatchTowerCost * PlayerStats.WatchTowerLVL * 2;
        UpdateText();
        HpUpdate();



    }
    void HpUpdate() {
        PlayerStats.maxHp = PlayerStats.baseHp * PlayerStats.cityHP * PlayerStats.perkHp * PlayerStats.rebirthHp;
    }

    private void UpdateText() {
        BankLVL.text =        PlayerStats.BankLVL.ToString("G3");
        BarracksLVL.text =  PlayerStats.BarracksLVL.ToString("G3");
        WallLVL.text =      PlayerStats.WallLVL.ToString("G3");
        watchTowerLVL.text =   PlayerStats.WatchTowerLVL.ToString("G3");

        _gold.text = "Gold: " + Mathf.Round(PlayerStats.gold).ToString();

        _BankCost.text =   "Cost: " + BankCost.ToString("G3");
        _BarracksCost.text = "Cost: " + BarracksCost.ToString("G3");
        _WallCost.text = "Cost: " + WallCost.ToString("G3");
        _watchTowerCost.text = "Cost: " + WatchTowerCost.ToString("G3");
        BankCost = BaseBankCost * PlayerStats.BankLVL * 2;
        Debug.Log(BankCost);
    }

    public void UpgradeBank() {
        float Bankcostx10 = BankCost * 10;
        float Bankcostx100 = BankCost * 100;
        
        
        

        if (PlayerStats.gold >= BankCost && dropdown.value == 0) {
            PlayerStats.BankLVL++;
            PlayerStats.gold -= BankCost;
            PlayerStats.cityGold = 1 + PlayerStats.BankLVL / 1000;
            UpdateText();
        }
        else if (PlayerStats.gold >= BankCost * 10 && dropdown.value == 1) {
            PlayerStats.BankLVL += 10;
            PlayerStats.gold -= BankCost *= 10;
            _BankCost.text = "Cost: " + Bankcostx10.ToString();
            PlayerStats.cityGold = 1 + PlayerStats.BankLVL / 1000;
            UpdateText();
        }
        else if (PlayerStats.gold >= BankCost * 100 && dropdown.value == 2) {
            PlayerStats.BankLVL += 100;
            PlayerStats.gold -= BankCost *= 100;
            _BankCost.text = "Cost: " + Bankcostx100.ToString();
            PlayerStats.cityGold = 1 + PlayerStats.BankLVL / 1000;
            UpdateText();
        }
        else {
            return;
        }

    }
    public void UpgradeBarracks() {
        float BarracksCostx10 = BarracksCost * 10;
        float BarracksCostx100 = BarracksCost * 100;

        if (PlayerStats.gold >= BarracksCost && dropdown.value == 0) {
            PlayerStats.BarracksLVL++;
            PlayerStats.gold -= BarracksCost;
            UpdateText();
        }
        else if (PlayerStats.gold >= BarracksCost * 10 && dropdown.value == 1) {
            PlayerStats.BarracksLVL += 10;
            _BarracksCost.text = "Cost: " + BarracksCostx10.ToString();
            PlayerStats.gold -= BarracksCost *= 10;
            UpdateText();
        }
        else if (PlayerStats.gold >= BarracksCost * 100 && dropdown.value == 2) {
            PlayerStats.BarracksLVL += 100;
            _BarracksCost.text = "Cost: " + BarracksCostx100.ToString();
            PlayerStats.gold -= BarracksCost *= 100;
            UpdateText();
        }
        else {
            return;
        }
    }
    public void UpgradeWall() {
        float WallCostx10 = WallCost * 10;
        float Wallcostx100 = WallCost * 100;

        if (PlayerStats.gold >= WallCost && dropdown.value == 0) {
            PlayerStats.WallLVL++;
            PlayerStats.gold -= WallCost;
            PlayerStats.cityHP = 1 * PlayerStats.WallLVL;
            Debug.Log(PlayerStats.hp);
            UpdateText();
        }
        else if (PlayerStats.gold >= WallCost * 10 && dropdown.value == 1) {
            PlayerStats.WallLVL += 10;
            _WallCost.text = "Cost: " + WallCostx10.ToString();
            PlayerStats.gold -= WallCost *= 10;
            UpdateText();
        }
        else if (PlayerStats.gold >= WallCost * 100 && dropdown.value == 2) {
            PlayerStats.WallLVL += 100;
            _WallCost.text = "Cost: " + Wallcostx100.ToString();
            PlayerStats.gold -= WallCost *= 100;
            UpdateText();
        }
        else {
            return;
        }
    }
    public void UpgradeWatchTower() {
        float WatchTowerCostx10 = WatchTowerCost * 10;
        float WatchTowerCostx100 = WatchTowerCost * 100;

        if (PlayerStats.gold >= WatchTowerCost && dropdown.value == 0) {
            PlayerStats.WatchTowerLVL++;
            PlayerStats.gold -= WatchTowerCost;
            UpdateText();
        }
        else if (PlayerStats.gold >= WatchTowerCost * 10 && dropdown.value == 1) {
            _watchTowerCost.text = "Cost: " + WatchTowerCostx10.ToString();
            PlayerStats.WatchTowerLVL += 10;
            PlayerStats.gold -= WatchTowerCost *= 10;
            UpdateText();
        }
        else if (PlayerStats.gold >= WatchTowerCost * 100 && dropdown.value == 2) {
            _watchTowerCost.text = "Cost: " + WatchTowerCostx100.ToString();
            PlayerStats.WatchTowerLVL += 100;
            PlayerStats.gold -= WatchTowerCost *= 100;
            UpdateText();
        }
        else {
            return;
        }
    }


}
