using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    HandManager handF;

    Vector3 firstPos, lastPos;
    float timer;
    public bool isTransferedX = false;

    [SerializeField] float movementSpeed;

    private void Start()
    {
        timer = 5f;

        handF = GetComponentInChildren<HandManager>();       
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
        
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Movement();
            timer = 0;
        }
        else
        {
            return;
        }
    }


    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;
            float distance = lastPos.x - firstPos.x;
           
            if (distance > .1)
            {
               handF.RemoveLeftCard();                
                
            }
            if (distance < -.1)
            {
               handF.RemoveRightCard();                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTransferedX = false;

            firstPos = Vector3.zero;

            lastPos = Vector3.zero;
        }
    }
}
