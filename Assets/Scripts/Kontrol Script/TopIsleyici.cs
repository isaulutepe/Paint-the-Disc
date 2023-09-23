
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TopIsleyici : MonoBehaviour
{

    public static float rotateSpeed = 100f;
    public static float rotateTime = 3f;

    public static float currentCircleNo;
    private static int CircleCount;

    public static Color color;

    public GameObject ball;
    public GameObject dummyBall; //Kukla top
    public GameObject btn;
    public GameObject levelComplate;
    public GameObject failScreen;
    public GameObject startGameScreen;
    //public GameObject circleEffect;
    //public GameObject complateEffect;

    public float speed = 100f;

    public int ballCount;
    private int circleNo;
    private int heartNo;

    private Color[] ChangingColor;

    private bool gameFail = false;

    public Image[] balls; //Top resimleri -> Her top atýldýgýnda bi tanesi azalacak.
    //Her oyun baþý top sayýsý kadar yeniden oluþacak.
    public GameObject[] hearts;


    public Text totalBallText;
    public Text countBallText;
    public Text levelComplateText;

    public AudioSource complateSound;
    public AudioSource gameFailSound;


    private void Start()
    {
        //Oyun baþýnda ilk dairenin oluþturulamsý lazým onun için bu iþlemi ya
        ResetGame();
    }

    void ResetGame()
    {
        CircleCount = 1;
        ChangingColor = Renk.colorArray;
        color = ChangingColor[0]; //Baþlangýç rengi
        ChangeBallCount();

        GameObject gameObject2 = Instantiate(Resources.Load("round" + UnityEngine.Random.Range(1, 12))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelIsleyici.ballCount;

        currentCircleNo = circleNo;
        LevelIsleyici.currentColor = color;

        if (heartNo == 0) // 0 ise 1 yap
            PlayerPrefs.SetInt("hearts", 1);

        heartNo = PlayerPrefs.GetInt("hearts");
        for (int i = 0; i < heartNo; i++)
        {
            hearts[i].SetActive(true);
        }
        MakeObstacle();
    }
    public void HeartsLow()
    {
        heartNo--;
        PlayerPrefs.SetInt("hearts", heartNo);
        hearts[heartNo].SetActive(false);
    }
    public void HitBall()
    {
        if (ballCount <= 1)
        {
            StartCoroutine(HideBtn());
            this.Invoke("MakeNewCircle", 0.4f); //0,4 saniye içinde daire yarat fonksiyonunu çaðýrýr.
        }
        ballCount--;

        if (ballCount >= 0)
            balls[ballCount].enabled = false;


        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity); //Týklandýkça top üretilecek.
        gameObject.GetComponent<MeshRenderer>().material.color = color; //Top rengi deðiþtirdik.
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse); //Topa yukarý yönlü kuvvet uyguladýk.

    }
    void ChangeBallCount()
    {
        ballCount = LevelIsleyici.ballCount;
        dummyBall.GetComponent<MeshRenderer>().material.color = color; //Kukla topun rengini de oyun rengine göre deðiþtirmek için.

        totalBallText.text = string.Empty + LevelIsleyici.totalCircle;
        countBallText.text = "" + CircleCount;

        //Bütün toplarý kapat
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }
        //Top sayýsý kadar olanlarý aç.
        for (int j = 0; j < ballCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = color;
        }
    }
    void MakeNewCircle()
    {

        if (CircleCount >= LevelIsleyici.totalCircle && !gameFail)
        {
            StartCoroutine(LevelCompleteScreen());
        }
        else
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
            currentCircleNo = circleNo;


            GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
            gameObject2.transform.position = new Vector3(0, 20, 23);
            gameObject2.name = "Circle" + circleNo;

            ballCount = LevelIsleyici.ballCount;

            //Renk dizilerinde 8 eleman oldugundan dizi dýþýna çýkmasýný engellemk için bu iþlemi yaptým.
            int maxIndex = 7;
            if (circleNo > maxIndex)
            {
                //Var olan renklerden random çaðýrmaya devam edecek.
                int rnd = Random.Range(0, maxIndex + 1);
                color = ChangingColor[rnd];
            }
            else
                color = ChangingColor[circleNo];

            LevelIsleyici.currentColor = color;

            MakeObstacle();
            CircleCount++;
            ChangeBallCount();
        }

    }

    public void FailGame()
    {
        gameFail = true;
        Invoke("FailScreen", 1);
        btn.SetActive(false);
        StopCircle();
    }
    void FailScreen()
    {
        failScreen.SetActive(true);
    }
    public void DeleteAllCircle()
    {
        GameObject[] circles=GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject circle in circles)
        {
            Destroy(circle); //Oluþturulan bütün daireleri bul ve sil.
        }
        gameFail= false;
        FindObjectOfType<LevelIsleyici>().UpgradeLevel();
        circleNo= 0;
        ResetGame();
    }

    private void StopCircle()
    {
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        gameObject.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (gameObject.GetComponent<iTween>())
            gameObject.GetComponent<iTween>().enabled = false;
    }
   

    //Yeni circle oluþturulurken arka arkaya top atma iþlemi gerçekleþmemesi için yaptýk.
    IEnumerator HideBtn()
    {
        if (!gameFail)
        {
            btn.SetActive(false);
            yield return new WaitForSeconds(1);
            btn.SetActive(true);
        }
    }
    IEnumerator LevelCompleteScreen()
    {
        gameFail = true; //Oyunu durdurduk.
        GameObject oldCircle = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            oldCircle.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
        oldCircle.transform.GetChild(24).GetComponent<MeshRenderer>().material.color = color; //En son child objesi dairenin bütün hali oldugundan 24. olaný tamamen boyadk.
        oldCircle.transform.GetComponent<MonoBehaviour>().enabled = false;
        //Dönüþ hareketini durdur.
        if (oldCircle.GetComponent<iTween>())
        {
            oldCircle.GetComponent<iTween>().enabled = false;
        }
        btn.SetActive(false); //Top fýrlatma butonunu kapat.
        yield return new WaitForSeconds(2);
        levelComplate.SetActive(true); // Tamamlandý ekranýný aktif et.
        levelComplateText.text = string.Empty + LevelIsleyici.currentLevel;
        yield return new WaitForSeconds(1);
        GameObject[] oldCircles = GameObject.FindGameObjectsWithTag("circle");//Oluþturulan dairelerin hepsini bul.
        //Oluþturulmuþ bütün daireleri sil.
        foreach (GameObject gameObject in oldCircles)
        {
            Destroy(gameObject.gameObject);
        }
        yield return new WaitForSeconds(1);
        //Kayýtlý leveli al ve bir bir arttýrýp güncelle.
        int currentLevel = PlayerPrefs.GetInt("C_Level");
        currentLevel++;
        PlayerPrefs.SetInt("C_Level", currentLevel);
        GameObject.FindObjectOfType<LevelIsleyici>().UpgradeLevel();
        ResetGame();
        levelComplate.SetActive(false);
        startGameScreen.SetActive(true);
        gameFail = false;

    }
    //Boyalý alanlar yaratmak için.
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
        if (circleNo > 5) //Circle no 5 den büyükse iþlem sonlanmamasý için artýk random engeller oluþturacak.
        {
            int rnd = Random.Range(1, 6); // 1 ile 5 arasýnda rastgele bir sayý üretir
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
