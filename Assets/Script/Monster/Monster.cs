using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 100;
    RaycastHit hitInfo;
    float speed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        Move();
        Ray();
    }

    private void Move()
    {
        //멋대로 움직이다가 전방에 플레이어 발견하면 플레이어를 향해 감
    }

    void Ray()
    {
        if (Physics.Raycast(transform.position, transform.right, out hitInfo, 1f))
        {
            //여기에 공격하는거 넣기
            if (hitInfo.transform.name == "Player")
            {

            }
        }
        else if (Physics.BoxCast(transform.position, new Vector3(1, 10, 1), transform.right, out hitInfo, transform.rotation, 10f))
        {
            //박스캐스트를 이용해서 하니 Y축도 잡히게 되었다.
            //다만 휘어지는 곳에 플레이어가 갔을 때 따라오지 않는 것을 보아 x축과 z축도 좀 손 봐야할 것 같다.
            if (hitInfo.transform.name == "Player")
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);//로컬 좌표
            }
        }

        if (Physics.Raycast(transform.position, transform.right * -1, out hitInfo, 1f))
        {
            //여기에 공격하는거 넣기
            if (hitInfo.transform.name == "Player")
            {

            }
        }
        else if (Physics.BoxCast(transform.position, new Vector3(1, 10, 1), transform.right * -1, out hitInfo, transform.rotation, 10f))
        {
            if (hitInfo.transform.name == "Player")
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);//로컬 좌표
            }
        }
    }
}
