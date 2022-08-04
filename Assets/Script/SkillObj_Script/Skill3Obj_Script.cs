using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3Obj_Script : MonoBehaviour
{
    int damage = 10 * (int)(GameManager.playerPower * 0.05); //전투력 비례 해서 데미지 강해지게 만들어야함
    int direction = Player_skill.direction; //방향값이 쓸때마다 바뀌지 않음!

    private void Start()
    {
        Invoke("DestroyObj", 1f);
        transform.rotation = GameManager.player.transform.rotation;
        //transform.position = GameManager.player.transform.position + Vector3.right * 8;

        if (direction == -1)
        {
            transform.Translate(Vector3.left * 8f);
        }
        else if (direction == 1)
        {
            transform.Translate(Vector3.right * 8f);
        }

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
            other.GetComponent<Monster>().hp -= damage / other.GetComponent<Monster>().defense;
            Debug.Log(damage / other.GetComponent<Monster>().defense);
        }
    }
}
