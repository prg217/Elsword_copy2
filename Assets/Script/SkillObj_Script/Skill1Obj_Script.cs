using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Obj_Script : MonoBehaviour
{
    public float speed = 30f;
    bool isFloor = false;
    int damage = 10 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함

    public static int direction = Player_skill.direction;

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
            //transform.Rotate(transform.rotation.x, other.transform.rotation.y, transform.rotation.z);
            transform.rotation = other.transform.rotation;
            transform.Rotate(new Vector3(transform.rotation.x + 1, transform.rotation.y - 4, transform.rotation.z + direction * 15));
            //일단 위와 같이 하면 회전값은 정상적으로 나온다

            //여기랑 Player_skill쪽의 Skill1쪽 손봐야함
            //일단 나중에
        }
    }
}
