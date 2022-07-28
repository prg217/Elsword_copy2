using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerPower = 100; //전투력
    public static GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");

        //씬 이동해도 데이터 날아가지 않게 해주기
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
