using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static int hp = 100;
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
    }

    private void Move()
    {
        //멋대로 움직이다가 전방에 플레이어 발견하면 플레이어를 향해 감
    }
}
