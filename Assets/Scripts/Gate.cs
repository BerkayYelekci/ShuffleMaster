using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public Action<int, GateType, Vector3, bool> onTakeHolder;

    public GateType gateType;

    public int value;

    private Vector3 pos;

    private Text text;

    private void Start()
    {
        pos = transform.position;

        text = GetComponentInChildren<Text>();

        text.text = value.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            onTakeHolder?.Invoke(value, gateType, pos,true);
        }

        if (other.CompareTag("RightHand"))
        {
            onTakeHolder?.Invoke(value, gateType, pos,false);
        }
    }
}
public enum GateType
{
    ADD,
    SUBTRACT
}
