using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renk : MonoBehaviour
{
    public Color[] renk1;
    public Color[] renk2;
    public Color[] renk3;

    public static Color[] renkDizisi;

    private void Start()
    {
        RenkDegis();
    }

    private void RenkDegis()
    {
        int randomRenk = UnityEngine.Random.Range(0, 2);
        //0 - 1 - 2 olacak þekilde
        PlayerPrefs.SetInt("AktifRenk", randomRenk);
        PlayerPrefs.GetInt("AktifRenk");

        if (PlayerPrefs.GetInt("AktifRenk") == 0)
        {
            renkDizisi = renk1;
        }
        if (PlayerPrefs.GetInt("AktifRenk") == 1)
        {
            renkDizisi = renk2;
        }
        if (PlayerPrefs.GetInt("AktifRenk") == 2)
        {
            renkDizisi = renk3;
        }
    }
}
