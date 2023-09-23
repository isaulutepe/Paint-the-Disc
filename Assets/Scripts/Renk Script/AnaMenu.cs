using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    public Sprite[] images;
    public Image currentImage;
    public GameObject pauseScreen;
  
    private void Start()
    {
       currentImage.sprite = images[Random.Range(0,4)];
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
