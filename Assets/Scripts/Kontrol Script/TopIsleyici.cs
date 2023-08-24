using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TopIsleyici : MonoBehaviour
{

    public static float donusHizi = 130f;
    public static float donusZamani = 3f;

    public static Color renk = Color.blue;
    public GameObject top;

    public float hiz = 100f;

    public int topSayisi;
    private int daireNo;

    private Color[] renkDegistir;
    private void Start()
    {
        //Oyun ba��nda ilk dairenin olu�turulams� laz�m onun i�in bu i�lemi ya
        ResetGame();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TopAt();
        }
    }
    void ResetGame()
    {
        renkDegistir = Renk.renkDizisi;
        renk = renkDegistir[0];

        GameObject daireler = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        daireler.transform.position = new Vector3(0, 20, 23);
        daireler.name = "Circle" + daireNo;
        topSayisi = LevelIsleyici.topSayisi;
    }
    private void TopAt()
    {
        if (topSayisi <= 1)
        {
            this.Invoke("DaireYarat", 0.4f); //0,4 saniye i�inde daire yarat fonksiyonunu �a��r�r.
        }
        topSayisi--;
        GameObject toplar = Instantiate<GameObject>(top, new Vector3(0, 0, -8), Quaternion.identity); //T�kland�k�a top �retilecek.
        toplar.GetComponent<MeshRenderer>().material.color = renk; //Top rengi de�i�tirdik.
        toplar.GetComponent<Rigidbody>().AddForce(Vector3.forward * hiz, ForceMode.Impulse); //Topa yukar� y�nl� kuvvet uygulad�k.

    }
    private void DaireYarat()
    {
        GameObject[] dizi = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + daireNo); //BU adl� game objeyi bul.
        for (int i = 0; i < 24; i++) //Kendi i�inde 24 par�a olugundan d�ng� 24 defa �al��mal�.
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false); //Hepsini kapatt�k.
        }
        gameObject.transform.GetChild(24).GetComponent<MeshRenderer>().material.color = renk; //Altta kalan dairenin renginin tamam�n� de�i�tirdik.
        if (gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
        foreach (GameObject d in dizi)
        {
            iTween.MoveBy(d, iTween.Hash(new object[]
            {
                "y",
                -2.98,
                "easetype",
                iTween.EaseType.spring,
                "time",
                0.5
            }));


        }
        daireNo++;


        GameObject daireler = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        //Yeni daire yarattik anacak yarat�lacak nesneyi metot �a��r�l�nca kaynaklardan kendisi bulucak ve
        //Random olarak getirecektir. sondaki as gameObject ifadesi de bir �e�it t�r d�n���m�.
        daireler.transform.position = new Vector3(0, 20, 23);
        daireler.name = "Circle" + daireNo;
        renk = renkDegistir[daireNo];
        topSayisi = LevelIsleyici.topSayisi;
    }
}
