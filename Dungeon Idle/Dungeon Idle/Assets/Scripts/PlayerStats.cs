using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{

    public static float hp;
    public static float maxHp;
    public static float baseHp = 100f;
    public static float cityHP = 1f;
    public static float rebirthHp = 1f;
    public static float perkHp = 1f;

    public static float damage;
    public static float baseDamage = 1f;
    public static float cityDamage = 1.5f; //150%
    public static float heroDamage = 2.2f; //220%
    public static float rebirthDamage = 1f; //100% no bonus
    public static float perkDamage = 1f;

    public static float gold;
    public static float startGold = 100f;
    public static float baseGold = 1f; //100% 
    public static float cityGold = 1f;
    public static float rebirthGold = 1f;
    public static float perkGold = 1f;
    public static float mutatorGold = 1f;
    public static float dayGold = 1f;

    public static float exp;
    public static float expGain;
    public static float baseExpGain = 1f;
    public static float heroExpGain = 1f;
    public static float rebirthExpGain = 1f;
    public static float perkExpGain = 1f;
    public static float mutatorExpGain = 1f;
    public static float dayExpGain = 1f;

    public static float achievementMultiplier = 1f;

    public static float range;
    public static float baseRange = 5f;
    public static float heroRange = 0f;

    public static float atkSpeed;
    public static float baseAtkSpeed = 1f;
    public static float heroAtkSpeed = 0f;

    public static float BankLVL = 1;
    public static int BarracksLVL = 1;
    public static int WallLVL = 1;
    public static int WatchTowerLVL = 1;

    public static float Day = 1;
    
}
