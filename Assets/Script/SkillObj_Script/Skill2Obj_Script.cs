using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Obj_Script : MonoBehaviour
{
    int damage = 20 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함

    private void Start()
    {
        Invoke("DestroyObj", 1.5f);
    }

    void Update()
    {

    }

    void DestroyObj()
    {
        GameManager.player.GetComponent<Rigidbody>().useGravity = true;
        Player_ctl.skillAct = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            //데미지 주기
            Monster.hp -= damage;
        }
    }
}
