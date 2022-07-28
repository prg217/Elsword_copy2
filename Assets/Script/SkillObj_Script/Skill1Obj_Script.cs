using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Obj_Script : MonoBehaviour
{
    public float speed = 30f;
    bool isFloor = false;
    int damage = 10 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함

    //public int direction = SkillSpawn_Script.direction;

    private void Start()
    {
        Invoke("DestroyObj", 1);
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
    }
}
