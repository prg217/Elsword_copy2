using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Key : MonoBehaviour, IDropHandler
{
    public Skill mySkill;
    public static bool isDrop = false;

    public void OnDrop(PointerEventData eventData)
    {
        var skill = eventData.pointerDrag.GetComponent<Skill>();

        MyKeyCall(skill);
        SkillCall(skill);
        //스킬을 바꾸고 스킬키 누르면 스킬키에 따라 그 스킬이 나오게 하기

        isDrop = true;
    }
    
    void MyKeyCall(Skill skill)
    {
        var parent = GameObject.Find(skill.keyType.ToString()); //열거형에 부모 이름을 저장해뒀으니 그걸로찾아줌
        mySkill.transform.SetParent(parent.transform);
        mySkill.transform.position = parent.transform.position;
        mySkill.key = parent.GetComponent<Key>(); //키 바꿔주기
        mySkill.EnumChange();
        parent.GetComponent<Key>().mySkill = mySkill; //옮겨주는 부모의 mySkill도 바꿔야 정상 작동
    }

    void SkillCall(Skill skill)
    {
        mySkill = skill; //기존꺼 처리 끝내고 이제 mySkill의 자리를 차지함
        skill.key = this;
        skill.transform.SetParent(this.transform);
        skill.transform.position = this.transform.position;
        skill.EnumChange();
    }
}
