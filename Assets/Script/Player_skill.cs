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
    public static int direction; //캐릭터 방향

    public void Start()
    {
        player = GameObject.Find("Player"); //플레이어 찾아서 등록해준다.
    }

    private void Update()
    {
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
            //미처 스킬이 다 발동되기전에 방향 바꾸어서 또 쓰면 direction이 바뀌어 기존에 진행되고 있던 스킬도 방향이 바뀐다
            var instance = Instantiate(Resources.Load<GameObject>("Prefab/SkillObj/Skill1Obj"), new Vector3(0, 0, 0)/*playerTransSave + new Vector3(direction * (3 + (i * 3.5f)), 8, 0)*/, Quaternion.identity);
            //instance.transform.localPosition = playerTransSave + new Vector3(direction * (3 + (i * 3.5f)), 8, 0);
            //instance.transform.Translate(playerTransSave + new Vector3(direction * (3 + (i * 3.5f)), 8, 0));
            //단순히 로컬 좌표를 이렇게 해준다고 해도 안될듯... 회전값이 있는 로컬 좌표에 이만큼 더해주고 싶다!로 해야할듯
            //여기서 x를 더해줄 때 문제가 생기는 것 같다. 이건 연속으로 소환하는 거니까... 
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
        player.GetComponent<Rigidbody>().useGravity = false; //true는 스킬 오브젝트가 삭제될 때 같이 true되게 해줬음
        player.transform.position += new Vector3(0, 1.5f, 0);
        Player_ctl.skillAct = true; //이것도 스킬 오브젝트가 삭제될 때

        playerTransSave = player.transform.position;

        Instantiate(Resources.Load("Prefab/SkillObj/Skill2Obj"), playerTransSave + new Vector3(0, 1, 0), Quaternion.identity);

        yield return null;
    }
    IEnumerator Skill3()
    {
        Debug.Log("Skill3");
        //밀키웨이
        player.GetComponent<Rigidbody>().useGravity = false; //true는 스킬 오브젝트가 삭제될 때 같이 true되게 해줬음
        Player_ctl.skillAct = true; //이것도 스킬 오브젝트가 삭제될 때

        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;

        Instantiate(Resources.Load("Prefab/SkillObj/Skill3Obj"), playerTransSave + new Vector3(direction * 8, 0, 0), Quaternion.identity);

        yield return null;
    }
    IEnumerator Skill4()
    {
        Debug.Log("Skill4");
        //카르마
        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;

        Instantiate(Resources.Load("Prefab/SkillObj/Skill4Obj"), playerTransSave + new Vector3(direction * 3.5f, 0, 0), Quaternion.identity);

        yield return null;
    }
    void Skill5()
    {
        Debug.Log("Skill5");
        //창 튀어나오기
    }
    void Skill6()
    {
        Debug.Log("Skill6");
        //레트리뷰션?
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
