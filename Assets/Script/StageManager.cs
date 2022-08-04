using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //시작할때 이 맵에 남아있는 몬스터들을 탐색
    //몬스터가 0마리 일때만 문을 부실 수 있도록 함
    //단 보스 몬스터는 보스 몬스터에 들어가는 별도의 코드로 죽으면 바로 게임이 끝나게 함
    public static int monsterCount = 0;
    public static bool doorOpen = false;
    public static List<GameObject> monster = new List<GameObject>();

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

    public static void DestroyMonster()
    {
        for (int i = 0; i < monster.Count; i++)
        {
            monster[i].GetComponent<Monster>().hp = 0;
        }
    }

    public void ESC() //중도포기
    {
        SceneManager.LoadScene("Town");
    }

    public void ClearESC() //클리어
    {
        SceneManager.LoadScene("Town");
    }

    public static void ClearUI() //결과창 띄우기
    {
        //여기에 결과창 ui추가하기
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            //여기서 몬스터 숫자 카운트하기
            monsterCount++;
            monster.Add(other.gameObject);
        }
    }

}
