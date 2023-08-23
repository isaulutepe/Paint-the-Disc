using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Daire1 : MonoBehaviour
{

    private void Start()
    {

        iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
        {
           "y",
           0,
           "easetype",
           iTween.EaseType.easeInCirc,
           "time",
           0.2,
           "OnComplete",
           "rotatecircle"
        }));


    }
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * TopIsleyici.donusHizi);
    }
    void rotatecircle()
    {
        Debug.Log("iTween anim çalýþtý");


    }
}
