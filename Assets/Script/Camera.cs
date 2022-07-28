using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; //나중에 게임 매니저에서 캐릭터 선택마다 바꿀 수 있게 해줘야함
    float speed = 3f;

    private void LateUpdate()
    {
        //Vector3 dir = player.transform.position - transform.position;
        //Debug.Log(dir);
        transform.position = player.transform.position + new Vector3(0, 2.5f, -13);
        //로컬 x좌표를 바꿔줘야함 좀 더 오른쪽으로... 근데 정면에서는 문제 없음
        //값의 차도 똑같음
        
        //transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * speed); //부드럽게 회전
        //그리고 회전 후에 플레이어를 가운데에 둘 수 있게 해야할듯
    }
}
