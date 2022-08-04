using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4Obj_Script : MonoBehaviour
{
    int damage = 5 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함
    float speed = 10;
    int direction = Player_skill.direction;

    private void Start()
    {
        Invoke("DestroyObj", 2f);
    }

    void Update()
    {
        //계속 앞으로 나아가게(플레이어 방향 받아서)
        if (direction == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (direction == -1)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            //데미지 주기
            other.GetComponent<Monster>().hp -= damage;
        }

        if (other.gameObject.tag == "FloorWall")
        {
            //회전하는 곳에 가면 회전하게 해줌
            transform.rotation = other.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            //데미지 주기
            other.GetComponent<Monster>().hp -= damage / other.GetComponent<Monster>().defense;
            Debug.Log(damage / other.GetComponent<Monster>().defense);
        }
    }
}
