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
        MyKeyCall(skill);
        SkillCall(skill);

    }
    
    void MyKeyCall(Skill skill)
    {
        var parent = GameObject.Find(skill.keyType.ToString()); //열거형에 부모 이름을 저장해뒀으니 그걸로찾아줌
        mySkill.transform.SetParent(parent.transform);
        mySkill.transform.position = parent.transform.position;
        mySkill.key = parent.GetComponent<Key>(); //키 바꿔주기
        mySkill.EnumChange();
        //Debug.Log(mySkill);
        //Debug.Log(mySkill.key);
        Debug.Log(mySkill.name + "을 " + parent.name + "으로 넘겨줌");
    }

    void SkillCall(Skill skill)
    {
        mySkill = skill; //기존꺼 처리 끝내고 이제 mySkill의 자리를 차지함
        skill.key = this;
        skill.transform.SetParent(this.transform);
        skill.transform.position = this.transform.position;
        skill.EnumChange();
        //Debug.Log(skill);
        //Debug.Log(skill.key);
        Debug.Log(mySkill.name + "으로 " + gameObject.name + "에 등록");
        //처음에는 직접 부모의 이름으로 하려고 했지만, (참고 자료 : https://magicmon.tistory.com/102)
        //Enum.Parse가 왜인지 안돼 일단, Skill쪽에서 if문으로 관리하게 해줬다.
        //나중에 어떤게 더 효율적인지 한 번 시도해볼 것.
    }
}
