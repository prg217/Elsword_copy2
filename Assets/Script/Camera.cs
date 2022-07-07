using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; //나중에 게임 매니저에서 캐릭터 선택마다 바꿀 수 있게 해줘야함
    float speed = 3f;

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 3.5f, -13);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * speed); //부드럽게 회전
    }
}
