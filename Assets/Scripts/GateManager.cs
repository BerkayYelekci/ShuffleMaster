using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class GateManager : MonoBehaviour
{
    public static GateManager Instance;

    public List<Gate> gates;

    public Action<int, GateType, Vector3, bool> onNewGate;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gates = GetComponentsInChildren<Gate>().ToList();

        for (int i = 0; i < gates.Count; i++)
        {
            int value = i;

            gates[value].onTakeHolder += OnNewGate;
        }
    }

    public void OnNewGate(int value, GateType gateType,Vector3 pos,bool isLeft)
    {
        onNewGate?.Invoke(value, gateType, pos, isLeft);
    }
}
