using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daire4 : MonoBehaviour
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

   void RotateCircle()
    {
        iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
      {
           "y",
           0.75f,
           "time",
           TopIsleyici.rotateTime,
           "easetype",
           iTween.EaseType.easeInOutQuad,
           "looptype",
           iTween.LoopType.pingPong,
           "delay",
           0.5
      }));
    }
}
