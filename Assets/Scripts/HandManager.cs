using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    [SerializeField] public Transform prevObject;

    public GameObject cardPrefab;

    public List<GameObject> RightHandCards = new List<GameObject>();

    public List<GameObject> LeftHandCards = new List<GameObject>();

    public List<Transform> leftPositionList = new List<Transform>(); 

    public List<Transform> rightPositionList = new List<Transform>();

    public Transform leftTargetPos;

    public Transform rightTargetPos;

    Card cardJ;

    public Vector3 temp = new Vector3(0f, 0.15f, 0f);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cardJ = GetComponentInChildren<Card>();
    }

    public void RemoveRightCard()
    {
        if (RightHandCards.Count < 1)
        {
            return;
        }

        GameObject lastCard = RightHandCards[RightHandCards.Count - 1];

        for (int i = 0; i < leftPositionList.Count; i++)
        {
            if(leftPositionList[i].childCount == 0)
            {
                lastCard.transform.parent = leftPositionList[i].transform;
            }
        }

        LeftHandCards.Add(lastCard);

        if (RightHandCards.Contains(lastCard))
        {
            RightHandCards.Remove(lastCard);
        }

        JumpLeftA(lastCard.GetComponent<Card>());
    }
    public void RemoveLeftCard()
    {
        if (LeftHandCards.Count < 1)
        {
            return;
        }

        GameObject lastCard = LeftHandCards[LeftHandCards.Count - 1];

        for (int i = 0; i < rightPositionList.Count; i++)
        {
            if (rightPositionList[i].childCount == 0)
            {
                lastCard.transform.parent = rightPositionList[i].transform;
            }
        }

        RightHandCards.Add(lastCard);
       
        if (LeftHandCards.Contains(lastCard))
        {
            LeftHandCards.Remove(lastCard);
        }

        JumpRightA(lastCard.GetComponent<Card>());
    }

    public void JumpRightA(Card card)
    {
        int temp = 0;

        for (int i = 0; i < rightPositionList.Count - 1; i++)
        {
            if(rightPositionList[i].childCount == 0)
            {
                temp = i;

                i = 99;

            }
        }

        Vector3 targetPos = rightPositionList[temp].transform.localPosition;

        card.transform.DOLocalJump(targetPos, 10, 1, 1f);
    }
    public void JumpLeftA(Card card)
    {
        int temp = 0;

        for (int i = 0; i < leftPositionList.Count - 1; i++)
        {
            if (leftPositionList[i].childCount == 0)
            {
                temp = i;

                i = 99;
            }
        }

        Vector3 targetPos = leftPositionList[temp].transform.localPosition;

        card.transform.DOLocalJump(targetPos, 10, 1, 1f);
    }
}
