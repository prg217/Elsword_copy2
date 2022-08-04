using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int hp = 5;

    private void Update()
    {
        if (hp <= 0)
        {
            //부서지고 몇 초 후 다음 스테이지
            //부서지는 애니메이션 넣을 것
            GetComponent<Rigidbody>().freezeRotation = false; //부서지는 대신 옆으로 넘어지게 임시로 해둠

            Invoke("Load", 1);
            //딜레이 넣기
        }
    }

    void Load()
    {
        SceneManager.LoadScene("Stage2");
        //이것도 일단 이렇게 하지만 따로 enum 부여해서 해주는게
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill" && StageManager.doorOpen == true);
        {
            //처음에 hp가 의문의 스킬에 의해서 피 2번 줄어들음
            hp--;
            Debug.Log("HP" + hp);
            Debug.Log(other);
        }
    }
}
