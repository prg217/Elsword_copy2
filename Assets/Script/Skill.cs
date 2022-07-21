using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public enum KeyType //키에 따라 다르게 설정함
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
        keyType = (KeyType)Enum.Parse(typeof(KeyType), key.name);
        //참고 자료: https://magicmon.tistory.com/102
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        GetComponent<Image>().raycastTarget = false;
        gameObject.GetComponent<Canvas>().sortingOrder = 3; //맨 앞에 나오게 해주기
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        gameObject.GetComponent<Canvas>().sortingOrder = 1; //다시 원래대로

        if (Key.isDrop == false) //키쪽에서 드롭을 안받았을 시에 다시 원래 자리로 돌아가게 해줌
        {
            var parent = GameObject.Find(keyType.ToString()); //열거형에 부모 이름을 저장해뒀으니 그걸로찾아줌
            transform.position = parent.transform.position;
        }
        else
        {
            Key.isDrop = false;
        }
    }
}
