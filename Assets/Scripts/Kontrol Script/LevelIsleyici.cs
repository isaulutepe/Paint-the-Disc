using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelIsleyici : MonoBehaviour
{
    public static int aktifSeviye;
    public static int topSayisi;
    public static int toplamDaire;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("BirinciDeneme", 0) == 0)
        {
            PlayerPrefs.SetInt("BirinciDeneme", 1);
            PlayerPrefs.SetInt("C_Seviye", 1);

        }
        LevelGuncelle();
    }

    private void LevelGuncelle()
    {
        aktifSeviye = PlayerPrefs.GetInt("C_Seviye", 1);

        if (aktifSeviye == 1)
        {
            topSayisi = 3;
            toplamDaire = 2;
        }
        if (aktifSeviye == 2)
        {
            topSayisi = 3;
            toplamDaire = 3;
        }
        if (aktifSeviye == 3)
        {
            topSayisi = 3;
            toplamDaire = 4;
        }
        if (aktifSeviye == 4)
        {
            topSayisi = 3;
            toplamDaire = 5;
        }
        if (aktifSeviye == 5)
        {
            topSayisi = 3;
            toplamDaire = 5;
        }
        if (aktifSeviye == 6)
        {
            topSayisi = 3;
            toplamDaire = 5;
        }
        if (aktifSeviye == 7)
        {
            topSayisi = 3;
            toplamDaire = 5;
        }
        if (aktifSeviye == 1)
        {
            topSayisi = 3;
            toplamDaire = 2;
        }
        if (aktifSeviye >= 8 && aktifSeviye <= 12)
        {
            topSayisi = 4;
            toplamDaire = 5;
        }
        if (aktifSeviye > 12 && aktifSeviye <= 20)
        {
            topSayisi = 4;
            toplamDaire = 6;
            TopIsleyici.donusHizi = 120;
            TopIsleyici.donusZamani = 2;
        }
        if (aktifSeviye >= 21)
        {
            topSayisi = 4;
            toplamDaire = 7;
            TopIsleyici.donusHizi = 140;
            TopIsleyici.donusZamani = 2;
        }
    }
}
