using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//https://www.youtube.com/watch?v=ODB3IOFqmrE

public class Player_skill : MonoBehaviour
{
    public enum SkillName //스킬들 들어갈 곳
    {
        Skill1, //임시 작명, 스킬 이름 정해지면 넣어주자
        Skill2,
        Skill3,
        Skill4,
        Skill5,
        Skill6,
        Skill7,
        Skill8,
        Skill9,
        Skill10,
        KeyCount, //for문을 사용하기 위해 SkillName이 몇 개 있는지 알려주기 위함
    }
    public SkillName skillName;
    public Skill skill;
    public GameObject player;

    float time = 0;
    float timeSave = 0;

    public void Start()
    {
        player = GameObject.Find("Player"); //플레이어 찾아서 등록해준다.
    }

    private void Update()
    {
        time = Time.deltaTime;

        KeyCode key = (KeyCode)Enum.Parse(typeof(KeyCode), skill.keyType.ToString()); //Skill쪽에서 등록된 keyType에 따라 KeyCode에 입력
        if (Input.GetKeyDown(key))
        {
            //열거형 이름에 따라 함수 호출하게 하기
            Invoke(skillName.ToString(), 0); //앞은 호출할 함수 이름, 뒤는 지연 시간
            //다른 방법 없나 살펴봐야겠다.
        }
    }

    void Skill1()
    {
        Debug.Log("Skill1");
        Instantiate(Resources.Load("Prefab/SkillObj/Skill1Obj"), player.transform.position + new Vector3(3, 3, 0), Quaternion.Euler(1, -4, 15));
        timeSave = time;
        //연속해서 4번 더 나오게 하고 싶음
        /*for (int i = 0; i < 5;)
        {
            if (time >= timeSave + 0.3f)
            {
                Instantiate(Resources.Load("Prefab/SkillObj/Skill1Obj"), player.transform.position + new Vector3(3, 3, 0), Quaternion.Euler(1 + i, -4, 15));
                timeSave = time;
                i++;
            }
        }*/
        //무한로딩 걸리니까 개선 필요

        //쿨타임 주기
        //쿨타임 줄 때 UI도 쿨타임 표시되게 하기
    }

    void Skill2()
    {
        Debug.Log("Skill2");
    }
    void Skill3()
    {
        Debug.Log("Skill3");
    }
    void Skill4()
    {
        Debug.Log("Skill4");
    }
    void Skill5()
    {
        Debug.Log("Skill5");
    }
    void Skill6()
    {
        Debug.Log("Skill6");
    }
    void Skill7()
    {
        Debug.Log("Skill7");
    }
    void Skill8()
    {
        Debug.Log("Skill8");
    }
    void Skill9()
    {
        Debug.Log("Skill9");
    }
    void Skill10()
    {
        Debug.Log("Skill10");
    }
}
