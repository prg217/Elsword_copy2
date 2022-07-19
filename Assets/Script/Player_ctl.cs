using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://developug.blogspot.com/2014/11/rigidbody-rotation.html : 플레이어 넘어지지 않게함
public class Player_ctl : MonoBehaviour
{
    public bool isJump = false;
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public static int direction = 1; //캐릭터 방향

    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //점프 및 양옆 이동
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump == false)
        {
            body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isJump = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //월드 좌표로 하면 물체가 아무리 회전해도 월드 좌표를 따르기 때문에 회전값에 영향을 안받지만, 로컬 좌표로 하면 물체의 회전에 영향을 받는다.
            direction = -1;
            transform.Translate(Vector3.left * Time.deltaTime * speed);//로컬 좌표
            //transform.position += Vector3.left * Time.deltaTime * speed; //월드 좌표
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            //transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
