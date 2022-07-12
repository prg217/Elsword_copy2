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
