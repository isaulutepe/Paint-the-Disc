using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelIsleyici : MonoBehaviour
{
    public static int currentLevel;
    public static int ballCount;
    public static int totalCircle;
    public static Color currentColor;

    private void Awake()
    {

        if (PlayerPrefs.GetInt("firstTime1", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);

        }
        UpgradeLevel();
    }

    public void UpgradeLevel()
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

    public void CreateObstacle1()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);
        //Oluþturulan engelin boyalý olarak gelecek Child objelerini random olarak verdik.
        //Bu alanlara top atarsak zaten boyalý oldugu için gaöeOver olacak.
        int index = Random.Range(1, 3);
        gameObject.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
        gameObject.transform.GetChild(index).gameObject.tag = "kýrmýzý";
    }
    public void CreateObstacle2()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1, 3),
            Random.Range(15, 17)
        };
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag = "kýrmýzý";
        }
    }
    public void CreateObstacle3()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1, 3),
            Random.Range(4, 6),
            Random.Range(18, 20)
        };
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag = "kýrmýzý";
        }
    }
    public void CreateObstacle4()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1, 3),
            Random.Range(4, 6),
            Random.Range(15, 17),
            Random.Range(22,24)
        };
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag = "kýrmýzý";
        }
    }
    public void CreateObstacle5()
    {
        GameObject gameObject = GameObject.Find("Circle" + TopIsleyici.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1, 3),
            Random.Range(4, 6),
            Random.Range(11, 13),
            Random.Range(8, 10),
            Random.Range(15, 17)
        };
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag = "kýrmýzý";
        }
    }
 
}
