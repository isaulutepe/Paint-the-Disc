
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renk : MonoBehaviour
{
    public Color[] color1;
    public Color[] color2;
    public Color[] color3;

    public static Color[] colorArray;

    private void OnEnable()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        int randomColor = Random.Range(0, 2);
        //0 - 1 - 2 olacak þekilde
        PlayerPrefs.SetInt("ColorSelect", randomColor);
        PlayerPrefs.GetInt("ColorSelect");

        if (PlayerPrefs.GetInt("ColorSelect") == 0)
        {
            colorArray = color1;
        }
        if (PlayerPrefs.GetInt("ColorSelect") == 1)
        {
            colorArray = color2;
        }
        if (PlayerPrefs.GetInt("ColorSelect") == 2)
        {
            colorArray = color3;
        }
    }
}
