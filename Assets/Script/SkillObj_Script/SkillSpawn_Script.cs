using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawn_Script : MonoBehaviour
{
    public float speed = 3f;
    int direction = Player_skill.direction; //방향값이 쓸때마다 바뀌지 않음!
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(1, -4, direction * 15));

        StartCoroutine("Obj");
    }

    // Update is called once per frame
    void Update()
    {
        //방향에 따라 다른 방향으로 가게 만들기
        if (direction == -1)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (direction == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    IEnumerator Obj()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i != 0)
            {
                GameObject instance = Instantiate(Resources.Load<GameObject>("Prefab/SkillObj/Skill1Obj"), transform.position, Quaternion.identity);
                instance.transform.rotation = transform.rotation;
                instance.transform.Rotate(instance.transform.rotation.x, instance.transform.rotation.y, direction * 15);
            }

            yield return new WaitForSeconds(0.3f);
        }
        //5번 소환
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FloorWall")
        {
            //회전하는 곳에 가면 회전하게 해줌
            transform.rotation = other.transform.rotation;

        }
    }
}
