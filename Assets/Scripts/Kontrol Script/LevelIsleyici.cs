using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelIsleyici : MonoBehaviour
{
    public static int currentLevel;
    public static int ballCount;
    public static int totalCircle;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("firstTime1", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);

        }
        UpgradeLevel();
    }

    private void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("C_Level", 1);

        if (currentLevel == 1)
        {
            ballCount = 3;
            totalCircle = 2;
        }
        if (currentLevel == 2)
        {
            ballCount = 3;
            totalCircle = 3;
        }
        if (currentLevel == 3)
        {
            ballCount = 3;
            totalCircle = 4;
        }
        if (currentLevel == 4)
        {
            ballCount = 3;
            totalCircle = 5;
        }
        if (currentLevel == 5)
        {
            ballCount = 3;
            totalCircle = 5;
        }
        if (currentLevel == 6)
        {
            ballCount = 3;
            totalCircle = 5;
        }
        if (currentLevel == 7)
        {
            ballCount = 3;
            totalCircle = 5;
        }
        if (currentLevel == 1)
        {
            ballCount = 3;
            totalCircle = 2;
        }
        if (currentLevel >= 8 && currentLevel <= 12)
        {
            ballCount = 4;
            totalCircle = 5;
        }
        if (currentLevel > 12 && currentLevel <= 20)
        {
            ballCount = 4;
            totalCircle = 6;
            TopIsleyici.rotateSpeed = 120;
            TopIsleyici.rotateTime = 2;
        }
        if (currentLevel >= 21)
        {
            ballCount = 4;
            totalCircle = 7;
            TopIsleyici.rotateSpeed = 140;
            TopIsleyici.rotateTime = 2;
        }
    }

    void CreateObstacle()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);
    }
}
