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

        //스킬 옮겼으면 그 자리에 있던 스킬도 있었던 자리에 옮겨야함

        //여기서 키 타입을 바꾸게 하고 스킬쪽에서 키 타입에 따라 그 버튼을 누르면 그 스킬쓰게 하면 안돼?
        mySkill = skill;
        skill.key = this;
        Debug.Log("!");
        skill.transform.SetParent(this.transform);
    }
}
