
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TopIsleyici : MonoBehaviour
{

    public static float rotateSpeed = 100f;
    public static float rotateTime = 3f;
    public static float currentCircleNo;

    public static Color color;
    public GameObject ball;

    public float speed = 100f;

    public int ballCount;
    private int circleNo;

    private Color[] ChangingColor;

    private void Start()
    {
        //Oyun baþýnda ilk dairenin oluþturulamsý lazým onun için bu iþlemi ya
        ResetGame();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }
    void ResetGame()
    {
        ChangingColor = Renk.colorArray;
        color = ChangingColor[0]; //Baþlangýç rengi

        GameObject gameObject2 = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelIsleyici.ballCount;
    }
    private void HitBall()
    {
        if (ballCount <= 1)
        {
            this.Invoke("MakeNewCircle", 0.4f); //0,4 saniye içinde daire yarat fonksiyonunu çaðýrýr.
        }
        ballCount--;
        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity); //Týklandýkça top üretilecek.
        gameObject.GetComponent<MeshRenderer>().material.color = color; //Top rengi deðiþtirdik.
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse); //Topa yukarý yönlü kuvvet uyguladýk.

    }
    void MakeNewCircle()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
            //Bütün parçalarýn aktifliðini kapatýyoruz.
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = color; //En son da bulunan bütün halinin rengini deðiþtirdik.

        if (gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
        foreach (GameObject target in array)
        {
            iTween.MoveBy(target, iTween.Hash(new object[]
            {
                "y",
                -2.98f,
                "easetype",
                iTween.EaseType.spring,
                "time",
                0.5
            }));
        }
        circleNo++;

        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;
        ballCount = LevelIsleyici.ballCount;

        color = ChangingColor[circleNo];

    }
}
