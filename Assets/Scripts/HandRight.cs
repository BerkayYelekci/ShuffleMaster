using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRight : MonoBehaviour
{
    private HandManager handManager;

    private void Start()
    {
        GateManager.Instance.onNewGate += GateSystem;

        handManager = HandManager.Instance;
    }

    public void GateSystem(int value, GateType gateType, Vector3 pos,bool isLeft)
    {
        if (!isLeft)
        {
            switch (gateType)
            {
                case GateType.ADD:
                    for (int i = 0; i < value; i++)
                    {
                        SpawnCard(value);
                    }
                    break;
                case GateType.SUBTRACT:
                    if (HandManager.Instance.RightHandCards.Count - value > 0)
                    {
                        for (int i = 0; i < value; i++)
                        {
                            DeleteCard(handManager.RightHandCards[handManager.RightHandCards.Count - 1]);
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void SpawnCard(int value)
    {
        for (int i = 0; i < handManager.rightPositionList.Count; i++)
        {
            if (handManager.rightPositionList[i].childCount == 0)
            {
                GameObject InstantiatedCard = Instantiate(handManager.cardPrefab, Vector3.zero, Quaternion.identity, handManager.rightPositionList[i].transform);

                InstantiatedCard.transform.localPosition = Vector3.zero;

                handManager.RightHandCards.Add(InstantiatedCard);

                return;
            }
        }
    }

    private void DeleteCard(GameObject index)
    {
        Destroy(index);

        handManager.RightHandCards.Remove(index);
    }
}
