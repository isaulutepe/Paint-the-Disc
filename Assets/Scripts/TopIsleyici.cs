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
        DaireYarat(); //Oyun baþladýðý anda bir daire yaratýlacak.
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
        GameObject toplar = Instantiate<GameObject>(top, new Vector3(0, 0, -8), Quaternion.identity); //Týklandýkça top üretilecek.
        toplar.GetComponent<MeshRenderer>().material.color = renk; //Top rengi deðiþtirdik.
        toplar.GetComponent<Rigidbody>().AddForce(Vector3.forward * hiz, ForceMode.Impulse); //Topa yukarý yönlü kuvvet uyguladýk.

    }
    private void DaireYarat()
    {
        GameObject daireler = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        //Yeni daire yarattik anacak yaratýlacak nesneyi metot çaðýrýlýnca kaynaklardan kendisi bulucak ve
        //Random olarak getirecektir. sondaki as gameObject ifadesi de bir çeþit tür dönüþümü.
        daireler.transform.position = new Vector3(0, 0, 23);
        daireler.name = "Daire";
    }
}
