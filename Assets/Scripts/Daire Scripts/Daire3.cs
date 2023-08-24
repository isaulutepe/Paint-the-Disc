using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daire3 : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
       {
           "y",
           0,
           "easetype",
           iTween.EaseType.easeInOutQuad,
           "time",
           0.6,
           "OnComplete",
           "RotateCircle"
       }));
    }

    void Update()
    {
        transform.Rotate(Vector3.down* Time.deltaTime * (TopIsleyici.donusHizi +20));
    }
}
