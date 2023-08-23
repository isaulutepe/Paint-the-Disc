using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TopIsleyici : MonoBehaviour
{

    public static float donusHizi = 130f;

    public static Color renk = Color.blue;
    public GameObject top;

    public float hiz = 100f;

    private int topSayisi;
    private int daireNo;
    private void Start()
    {
        GameObject daireler = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        daireler.transform.position = new Vector3(0, 20, 23);
        daireler.name = "Circle" + daireNo;
        DaireYarat(); //Oyun ba�lad��� anda bir daire yarat�lacak.

        topSayisi = 4;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TopAt();
        }
    }

    private void TopAt()
    {
        if (topSayisi <= 1)
        {
            base.Invoke("DaireYarat", 0.4f); //0,4 saniye sonra DaireYarat methodunu �a��r�r.
            //Invoke methot �a��rmak i�in kullan�l�r.
        }
        topSayisi--;
        GameObject toplar = Instantiate<GameObject>(top, new Vector3(0, 0, -8), Quaternion.identity); //T�kland�k�a top �retilecek.
        toplar.GetComponent<MeshRenderer>().material.color = renk; //Top rengi de�i�tirdik.
        toplar.GetComponent<Rigidbody>().AddForce(Vector3.forward * hiz, ForceMode.Impulse); //Topa yukar� y�nl� kuvvet uygulad�k.

    }
    private void DaireYarat()
    {
        GameObject[] dizi = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + daireNo);
        for (int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
            //Dairenin i�indeki objelere eri�tik.
        }

        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = TopIsleyici.renk;
        if (gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
        foreach (GameObject target in dizi)
        {
            iTween.MoveBy(target, iTween.Hash(new object[]
            {
                "y",
                -2,98f,
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
    }
}
