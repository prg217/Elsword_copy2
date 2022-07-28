using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; //나중에 게임 매니저에서 캐릭터 선택마다 바꿀 수 있게 해줘야함
    float rSpeed = 3f;
    float pSpeed = 10f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * pSpeed);
        //부드럽게 이동
        
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * rSpeed); //부드럽게 회전
    }
}
