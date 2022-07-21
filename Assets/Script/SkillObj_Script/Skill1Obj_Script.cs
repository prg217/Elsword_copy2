using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Obj_Script : MonoBehaviour
{
    public float speed = 30f;
    bool isFloor = false;
    int damage = 10 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함

    int direction = Player_skill.direction;

    Transform trans;

    private void Start()
    {
        Invoke("DestroyObj", 1);

        transform.Rotate(new Vector3(1, -4, direction * 15));
    }

    void Update()
    {
        if (isFloor == false)
        {
            //바닥이랑 닿으면 멈춘다
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isFloor = true;
        }

        if (other.gameObject.tag == "Monster")
        {
            //데미지 주기
            Monster.hp -= damage;
        }

        if (other.gameObject.tag == "FloorWall")
        {
            //회전하는 곳에 가면 회전하게 해줌
            //원인은 여기서 제대로 회전이 안이뤄져서 인 것 같다.
            //-24쯤이 나와야하는데 -0.2가 나옴
            //플레이어는 제대로 회전한다.
            //플레이어처럼 Floor 스크립트에 아래의 코드를 그 것 대로 입력해 보았을 때도 제대로 작동되지 않음
            //transform.Rotate(transform.rotation.x, other.transform.rotation.y, transform.rotation.z);
            transform.rotation = other.transform.rotation;
            Debug.Log(other.transform.rotation); //따로 Floor를 불러 했을때도 값이 같음

            //여기랑 Player_skill쪽의 Skill1쪽 손봐야함
        }
    }
}
