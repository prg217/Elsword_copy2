using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_Script : MonoBehaviour
{
    public int power; //파워는 공격을 시도하는 몬스터에게 가져와야함
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_ctl>().hp -= power * 1;
        }
    }
}
