using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform layout;
    public static Dictionary<int, Key> keyDic = new Dictionary<int, Key>();

    private void Start()
    {
        var newKey = Instantiate(Resources.Load<Key>("Q"), layout);
        keyDic.Add(0, newKey);
        newKey = Instantiate(Resources.Load<Key>("W"), layout);
        keyDic.Add(1, newKey);
        newKey = Instantiate(Resources.Load<Key>("E"), layout);
        keyDic.Add(2, newKey);
        newKey = Instantiate(Resources.Load<Key>("R"), layout);
        keyDic.Add(3, newKey);
        newKey = Instantiate(Resources.Load<Key>("T"), layout);
        keyDic.Add(4, newKey);
        newKey = Instantiate(Resources.Load<Key>("A"), layout);
        keyDic.Add(5, newKey);
        newKey = Instantiate(Resources.Load<Key>("S"), layout);
        keyDic.Add(6, newKey);
        newKey = Instantiate(Resources.Load<Key>("D"), layout);
        keyDic.Add(7, newKey);
        newKey = Instantiate(Resources.Load<Key>("C"), layout);
        keyDic.Add(8, newKey);
        newKey = Instantiate(Resources.Load<Key>("F"), layout);
        keyDic.Add(9, newKey);

        var skillKey = keyDic[0];
        var skill = Instantiate(Resources.Load<Skill>("Skill1"), keyDic[0].transform);
        skill.key = skillKey;
        skillKey.mySkill = skill;
        skill.GetComponent<Canvas>().overrideSorting = true;

        for (int i = 1; i < 10; i++)
        {
            skillKey = keyDic[i];
            skill = Instantiate(Resources.Load<Skill>("Skill" + (i + 1)), keyDic[i].transform);
            skill.key = skillKey;
            skillKey.mySkill = skill;
            skill.GetComponent<Canvas>().overrideSorting = true;
        }
    }
}
