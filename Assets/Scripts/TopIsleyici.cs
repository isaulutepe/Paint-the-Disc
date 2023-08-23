using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TopIsleyici : MonoBehaviour
{

    public static Color renk = Color.blue;
    public GameObject top;

    public float hiz = 100f;

    private void Start()
    {
        DaireYarat(); //Oyun ba�lad��� anda bir daire yarat�lacak.
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TopaVur();
        }
    }

    private void TopaVur()
    {
        GameObject toplar = Instantiate<GameObject>(top, new Vector3(0, 0, -8), Quaternion.identity); //T�kland�k�a top �retilecek.
        toplar.GetComponent<MeshRenderer>().material.color = renk; //Top rengi de�i�tirdik.
        toplar.GetComponent<Rigidbody>().AddForce(Vector3.forward * hiz, ForceMode.Impulse); //Topa yukar� y�nl� kuvvet uygulad�k.

    }
    private void DaireYarat()
    {
        GameObject daireler = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        //Yeni daire yarattik anacak yarat�lacak nesneyi metot �a��r�l�nca kaynaklardan kendisi bulucak ve
        //Random olarak getirecektir. sondaki as gameObject ifadesi de bir �e�it t�r d�n���m�.
        daireler.transform.position = new Vector3(0, 0, 23);
        daireler.name = "Daire";
    }
}
