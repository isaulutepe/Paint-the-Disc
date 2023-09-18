using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    public Sprite[] images;
    public Image currentImage;
  
    private void Start()
    {
       currentImage.sprite = images[Random.Range(0,4)];
    }

}
