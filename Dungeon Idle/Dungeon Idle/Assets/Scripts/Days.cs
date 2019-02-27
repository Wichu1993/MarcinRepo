using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Days : MonoBehaviour
{
    public TextMeshProUGUI _daysText;
    public Image dayBar;
    private float _dayBar;

    private void Update() {
        _dayBar = Time.deltaTime / 10;
        UpdateDays();
        UpdateBar();
    }
    void UpdateDays() {
        PlayerStats.Day = Mathf.Round(Time.time) / 10;
        _daysText.text = "Days: " + PlayerStats.Day.ToString("F0");
    }
    void UpdateBar() {

        dayBar.fillAmount = _dayBar;
        if (_dayBar >= 1f)
            _dayBar = 0f;
        Debug.Log(_dayBar);
    }
}

