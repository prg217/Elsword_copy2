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
    Vector3 playerTransSave;
    public int direction; //캐릭터 방향

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
            //Invoke(skillName.ToString(), 0); //앞은 호출할 함수 이름, 뒤는 지연 시간
            //다른 방법 없나 살펴봐야겠다.
            StartCoroutine(skillName.ToString()); //코루틴 호출
            //보이드 함수랑 코루틴 함수랑 호출이 달라서 좀 바꿔야할듯
            //일단 다 코루틴으로 해보자(시간 많이 사용해야할 것 같으니)
        }
    }

    IEnumerator Skill1()
    {
        Debug.Log("Skill1");
        //헤븐즈 피스트?
        //미리 위치값과 방향값을 저장해서 도중에 플레이어가 움직여도 스킬 위치에는 영향 안가게 하기
        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;
        //플레이어의 방향값을 불러와 +인지 -인지 해주기

        for (int i = 0; i < 5; i++)
        {
            Instantiate(Resources.Load("Prefab/SkillObj/Skill1Obj"), playerTransSave + new Vector3(direction * (3 + (i * 3.5f)), 8, 0), Quaternion.Euler(1, -4, 15));
            yield return new WaitForSeconds(0.3f); //0.3초 동안 기다림
        }
        //맵 따라가는 스킬은 로테이션을... 받아와서 바꿔줘야할 것 같다

        //쿨타임 주기
        //쿨타임 줄 때 UI도 쿨타임 표시되게 하기
    }

    IEnumerator Skill2()
    {
        Debug.Log("Skill2");
        //젠즈
        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;

        yield return new WaitForSeconds(0.3f);
        Instantiate(Resources.Load("Prefab/SkillObj/Skill2Obj"), playerTransSave + new Vector3(0, 1, 0), Quaternion.identity);
        //플레이어 공중에 좀 떠서 1.5초 정도 못움직이게 하기
    }
    void Skill3()
    {
        Debug.Log("Skill3");
        //밀키웨이
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
