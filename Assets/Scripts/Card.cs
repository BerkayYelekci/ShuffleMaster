using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Card : MonoBehaviour
{  
    private Transform leftEndPosition;

    private Transform rightEndPosition;

    public float jumpPower;

    public int jumpCount;

    public float duration;

    private void Start()
    {
        leftEndPosition = HandManager.Instance.leftTargetPos;

        rightEndPosition = HandManager.Instance.rightTargetPos;
    }

   
   
}
