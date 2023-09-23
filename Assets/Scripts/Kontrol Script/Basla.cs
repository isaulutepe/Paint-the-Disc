using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basla : MonoBehaviour
{
    public Text levelNo;
    public Text targetText;

    private void OnEnable()
    {
        levelNo.text = LevelIsleyici.currentLevel + "";
        targetText.text = LevelIsleyici.totalCircle + "";
        StartCoroutine(DeleyedRemoval());
    }

    //Baþlangýç ekranýný yani kendisinin aktifliðini kapatacak.
    IEnumerator DeleyedRemoval()
    {
        yield return new WaitForSeconds(1);
        base.gameObject.SetActive(false);
    }
}
