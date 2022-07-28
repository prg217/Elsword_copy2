using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform layout;
    public static Dictionary<int, Key> keyDic = new Dictionary<int, Key>();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        var newKey = Instantiate(Resources.Load<Key>("Prefab/Key/Q"), layout);
        keyDic.Add(0, newKey);
        newKey.gameObject.name = "Q";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/W"), layout);
        keyDic.Add(1, newKey);
        newKey.gameObject.name = "W";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/E"), layout);
        keyDic.Add(2, newKey);
        newKey.gameObject.name = "E";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/R"), layout);
        keyDic.Add(3, newKey);
        newKey.gameObject.name = "R";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/T"), layout);
        keyDic.Add(4, newKey);
        newKey.gameObject.name = "T";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/A"), layout);
        keyDic.Add(5, newKey);
        newKey.gameObject.name = "A";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/S"), layout);
        keyDic.Add(6, newKey);
        newKey.gameObject.name = "S";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/D"), layout);
        keyDic.Add(7, newKey);
        newKey.gameObject.name = "D";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/C"), layout);
        keyDic.Add(8, newKey);
        newKey.gameObject.name = "C";
        newKey = Instantiate(Resources.Load<Key>("Prefab/Key/F"), layout);
        keyDic.Add(9, newKey);
        newKey.gameObject.name = "F";

        var skillKey = keyDic[0];
        var skill = Instantiate(Resources.Load<Skill>("Prefab/Skill/Skill1"), keyDic[0].transform);
        skill.key = skillKey;
        skillKey.mySkill = skill;
        skill.GetComponent<Canvas>().overrideSorting = true;

        for (int i = 1; i < 10; i++)
        {
            skillKey = keyDic[i];
            skill = Instantiate(Resources.Load<Skill>("Prefab/Skill/Skill" + (i + 1)), keyDic[i].transform);
            skill.key = skillKey;
            skillKey.mySkill = skill;
            skill.GetComponent<Canvas>().overrideSorting = true;
        }
    }
}
