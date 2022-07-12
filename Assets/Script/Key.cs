using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Key : MonoBehaviour, IDropHandler
{
    public Skill mySkill;

    public void OnDrop(PointerEventData eventData)
    {
        var skill = eventData.pointerDrag.GetComponent<Skill>();

        //여기서 키 타입을 바꾸게 하고 스킬쪽에서 키 타입에 따라 그 버튼을 누르면 그 스킬쓰게 하면 안돼?
        var parent = GameObject.Find(skill.keyType.ToString()); //열거형에 부모 이름을 저장해뒀으니 그걸로찾아줌
        mySkill.transform.SetParent(parent.transform);
        mySkill.transform.position = parent.transform.position;
        mySkill.key = parent.GetComponent<Key>(); //키 바꿔주기
                                                  //Skill에서 열거형도 바꿔줘야함 : 부모 이름을 받아서 열거형 바꾸기?

        mySkill = skill; //기존꺼 처리 끝내고 이제 mySkill의 자리를 차지함
        skill.key = this;
        skill.transform.SetParent(this.transform);
        skill.transform.position = this.transform.position;
        //Skill에서 열거형도 바꿔줘야함 : 부모 이름을 받아서 열거형 바꾸기?
    }
}
