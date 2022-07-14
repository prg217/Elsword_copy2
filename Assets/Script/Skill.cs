using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public enum KeyType //키에 따라 다르게 설정해주기
    {
        Q,
        W,
        E,
        R,
        T,
        A,
        S,
        D,
        C,
        F
    }
    public KeyType keyType;
    public Key key;

    public void EnumChange() //Key쪽에서 스킬을 움직일때마다 호출, 여기서 enum KeyType을 바꿔준다. 
    {
        if (key.name == "Q")
        {
            keyType = KeyType.Q;
        }
        else if (key.name == "W")
        {
            keyType = KeyType.W;
        }
        else if (key.name == "E")
        {
            keyType = KeyType.E;
        }
        else if (key.name == "R")
        {
            keyType = KeyType.R;
        }
        else if (key.name == "T")
        {
            keyType = KeyType.T;
        }
        else if (key.name == "A")
        {
            keyType = KeyType.A;
        }
        else if (key.name == "S")
        {
            keyType = KeyType.S;
        }
        else if (key.name == "D")
        {
            keyType = KeyType.D;
        }
        else if (key.name == "C")
        {
            keyType = KeyType.C;
        }
        else if (key.name == "F")
        {
            keyType = KeyType.F;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
