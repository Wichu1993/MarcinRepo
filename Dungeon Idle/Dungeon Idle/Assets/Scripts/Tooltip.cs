using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour {

    private float updatePerSec;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI atkSpeedText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI DPSText;
    public TextMeshProUGUI cityGoldBonus;

    private void Start() {
        PlayerStats.damage = PlayerStats.baseDamage + (PlayerStats.cityDamage * PlayerStats.heroDamage * PlayerStats.rebirthDamage * PlayerStats.perkDamage);
        damageText.text = PlayerStats.damage.ToString();
        atkSpeedText.text = "AtkSpeed: 0";
        rangeText.text = "Range: 0";
        DPSText.text = "DPS: 0";
        TooltipUpdate();
        updatePerSec = 1f;
    }


    private void Update()
    {

        TooltipUpdate();
        Debug.Log(PlayerStats.cityGold);
        
    }

    void TooltipUpdate() {

        float DPStooltip = Mathf.Round(PlayerStats.damage * Towers.instance.fireRate);

        if (updatePerSec <= 0f) {
           // damageText.text = "Damage: " + PlayerStats.damage.ToString();
            //atkSpeedText.text = "AtkSpeed: " + Towers.instance.fireRate.ToString();
           // rangeText.text = "Range: " + Towers.instance.range.ToString();
           // DPSText.text = "DPS: " + DPStooltip.ToString("G3");
            cityGoldBonus.text = "City Gold Bonus: " + PlayerStats.cityGold.ToString("P");


            updatePerSec = 1f;
        }
        else {
            updatePerSec -= Time.deltaTime;
        }
    }
}
