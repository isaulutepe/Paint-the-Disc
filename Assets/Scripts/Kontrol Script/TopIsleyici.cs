
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
        //Oyun ba��nda ilk dairenin olu�turulams� laz�m onun i�in bu i�lemi ya
        ResetGame();
    }
  
    void ResetGame()
    {
        ChangingColor = Renk.colorArray;
        color = ChangingColor[0]; //Ba�lang�� rengi

        GameObject gameObject2 = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 12))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelIsleyici.ballCount;

        currentCircleNo = circleNo;
        LevelIsleyici.currentColor = color;

        MakeObstacle();
    }
    public void HitBall()
    {
        if (ballCount <= 1)
        {
            this.Invoke("MakeNewCircle", 0.4f); //0,4 saniye i�inde daire yarat fonksiyonunu �a��r�r.
        }
        ballCount--;
        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity); //T�kland�k�a top �retilecek.
        gameObject.GetComponent<MeshRenderer>().material.color = color; //Top rengi de�i�tirdik.
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse); //Topa yukar� y�nl� kuvvet uygulad�k.

    }
    void MakeNewCircle()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
            //B�t�n par�alar�n aktifli�ini kapat�yoruz.
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = color; //En son da bulunan b�t�n halinin rengini de�i�tirdik.

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
        currentCircleNo = circleNo;


        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelIsleyici.ballCount;

        //Renk dizilerinde 8 eleman oldugundan dizi d���na ��kmas�n� engellemk i�in bu i�lemi yapt�m.
        int maxIndex = 7;
        if (circleNo > maxIndex)
        {
            //Var olan renklerden random �a��rmaya devam edecek.
            int rnd = Random.Range(0, maxIndex + 1);
            color = ChangingColor[rnd];
        }
        else
            color = ChangingColor[circleNo];

        LevelIsleyici.currentColor = color;

        MakeObstacle();
    }
    //Boyal� alanlar yaratmak i�in.
    void MakeObstacle()
    {
        if (circleNo == 1)
        {
            FindObjectOfType<LevelIsleyici>().CreateObstacle1();
        }
        if (circleNo == 2)
        {
            FindObjectOfType<LevelIsleyici>().CreateObstacle2();
        }
        if (circleNo == 3)
        {
            FindObjectOfType<LevelIsleyici>().CreateObstacle3();
        }
        if (circleNo == 4)
        {
            FindObjectOfType<LevelIsleyici>().CreateObstacle4();
        }
        if (circleNo == 5)
        {
            FindObjectOfType<LevelIsleyici>().CreateObstacle5();
        }
        if (circleNo > 5) //Circle no 5 den b�y�kse i�lem sonlanmamas� i�in art�k random engeller olu�turacak.
        {
            int rnd = Random.Range(1, 6); // 1 ile 5 aras�nda rastgele bir say� �retir
            switch (rnd)
            {
                case 1:
                    FindObjectOfType<LevelIsleyici>().CreateObstacle1();
                    break;
                case 2:
                    FindObjectOfType<LevelIsleyici>().CreateObstacle2();
                    break;
                case 3:
                    FindObjectOfType<LevelIsleyici>().CreateObstacle3();
                    break;
                case 4:
                    FindObjectOfType<LevelIsleyici>().CreateObstacle4();
                    break;
                case 5:
                    FindObjectOfType<LevelIsleyici>().CreateObstacle5();
                    break;
            }

        }
    }
}
