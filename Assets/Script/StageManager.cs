using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    //시작할때 이 맵에 남아있는 몬스터들을 탐색
    //몬스터가 0마리 일때만 문을 부실 수 있도록 함
    //단 보스 몬스터는 보스 몬스터에 들어가는 별도의 코드로 죽으면 바로 게임이 끝나게 함
    public static int monsterCount = 0;
    public static bool doorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterCount == 0)
        {
            //문 때릴 수 있게
            //근데 초기 값도 0이여서 다른 방법은 없을까?
            doorOpen = true;
        }
        else
        {
            doorOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            //여기서 몬스터 숫자 카운트하기
            //그리고 몬스터 스크립트에서 죽으면 여기에 신호를 보내면?
            monsterCount++;
            Debug.Log(monsterCount);
            Debug.Log(doorOpen);
        }
    }

}
