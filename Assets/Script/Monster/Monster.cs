using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 100;
    RaycastHit hitInfo;
    float speed = 3f;
    float stateSpeed = 1.5f;

    int layerMask;
    int randomState;
    public float time;
    public float timeSave = 0;
    public float timeSave2 = 0;
    bool player = false;

    public int power = 10;
    int direction = 1;

    bool isAttack = false;

    private void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Player");
    }

    void Start()
    {
        randomState = Random.Range(0, 5); //0부터 4까지
    }

    void Update()
    {
        time += Time.deltaTime;

        if (hp <= 0)
        {
            Destroy(gameObject);
            StageManager.monsterCount--;
        }

        if (player == false)
        {
            Move();
        }

        PlayerRay();
    }

    private void Move()
    {
        //랜덤으로 멈출지 오른쪽갈지 왼쪽갈지 정해준다
        //그리고 한 3초마다 상태 재정의 해주면 될 것 같음
        if (timeSave + 3 <= time)
        {
            randomState = Random.Range(0, 5); //0부터 4까지
            timeSave = time;
        }

        if (Physics.Raycast(transform.position, transform.right, out hitInfo, 1.5f))
        {
            randomState = Random.Range(0, 5); //0부터 4까지

            if (randomState == 1)
            {
                randomState = 2;
            }
        }
        else if (Physics.Raycast(transform.position, transform.right * -1, out hitInfo, 1.5f))
        {
            randomState = Random.Range(0, 5); //0부터 4까지

            if (randomState == 2)
            {
                randomState = 1;
            }
        }


        switch (randomState)
        {
            case 1:
                transform.Translate(Vector3.right * Time.deltaTime * stateSpeed);
                direction = 1;
                break;

            case 2:
                transform.Translate(Vector3.left * Time.deltaTime * stateSpeed);
                direction = -1;
                break;

            default:
                break;
        }

    }

    void PlayerRay()
    {
        //인식 범위에 닿으면 ! 한 번 띄워주기 => 시간 남을때 하자
        Debug.DrawRay(transform.position, transform.right * 20f, Color.red);
        if (Physics.BoxCast(transform.position + new Vector3(0, 10, 0), new Vector3(1, 10, 10), transform.right, out hitInfo, GameManager.player.transform.rotation, 20f, layerMask))
        {
            player = true;
            //박스캐스트를 이용해서 하니 Y축도 잡히게 되었다.
            //FloorWall을 인식해서 문제가 있었는데, 레이어를 따로 분리해서 인식시켜주니 정상적으로 작동된다.
            if (Physics.Raycast(transform.position, transform.right, out hitInfo, 1.5f, layerMask)) 
            {
                //여기에 공격하는거 넣기
                if (isAttack == false)
                {
                    isAttack = true;
                    StartCoroutine("Attack");
                    timeSave2 = time;
                }
                else if (isAttack == true && timeSave2 + 2.5f <= time)
                {
                    isAttack = false;
                }
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);//로컬 좌표
                direction = 1;
            }
        }
        else if (Physics.BoxCast(transform.position + new Vector3(0, 10, 0), new Vector3(1, 10, 10), transform.right * -1, out hitInfo, GameManager.player.transform.rotation, 20f, layerMask))
        {
            player = true;
            if (Physics.Raycast(transform.position, transform.right * -1, out hitInfo, 1.5f, layerMask))
            {
                //여기에 공격하는거 넣기
                if (isAttack == false && timeSave2 + 2.5f <= time)
                {
                    isAttack = true;
                    StartCoroutine("Attack");
                    timeSave2 = time;
                }
                else if (isAttack == true)
                {
                    isAttack = false;
                }
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);//로컬 좌표
                direction = -1;
            }
        }
        else
        {
            player = false;
        }

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        var attack = Instantiate(Resources.Load<GameObject>("Prefab/MonsterAttack/Attack1"), transform.position + new Vector3(direction * 2, 0, 0), Quaternion.identity);
        attack.GetComponent<Attack1_Script>().power = power;

        //무한반복 안되게 쿨타임 주기
    }

}
