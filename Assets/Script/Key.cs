using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Key : MonoBehaviour, IDropHandler
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

    public void OnDrop(PointerEventData eventData)
    {
        //안착됐을 때 키에 맞게... 해주기
        //여기도 enum으로 키 정해주고 부여해줘야할듯
    }
}
