using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//일단 스킬 스크립트를 다 따로 만들어줬는데 나중에 하나로 통합해서 스킬 매니저를 만든 후 enum으로 따로 관리하면 좋을 것 같기도
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
        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;
        //플레이어의 방향값을 불러와 +인지 -인지 해주기

        Instantiate(Resources.Load<GameObject>("Prefab/SkillObj/SkillSpawn"), playerTransSave + new Vector3(0, 8, 0), Quaternion.identity);
        //여기에서 많이 헷갈렸다.
        //원래는 여기와 Skill1Obj_Script에서 해결하려 했는데
        //따로 투명한 스킬 스폰을 만들어서 걔가 움직이면서 스폰하게 해줘서 매끄럽게 이동이 가능했다.
        //그렇게 하면서 원래 여기서 처리해줘서 스킬 또 시전하면 전에꺼 나오던게 위치 바꿔서 나오던게 지금은 다 각자 따로따로 나오게 해결됐다.

        yield return null;
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
        //이것도 수정 필요
        player.GetComponent<Rigidbody>().useGravity = false; //true는 스킬 오브젝트가 삭제될 때 같이 true되게 해줬음
        Player_ctl.skillAct = true; //이것도 스킬 오브젝트가 삭제될 때

        playerTransSave = player.transform.position;
        direction = Player_ctl.direction;

        Instantiate(Resources.Load("Prefab/SkillObj/Skill3Obj"), playerTransSave, Quaternion.identity);

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
