using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //죽으면 쫄몹들 다 죽고 결과창->마을로 돌아가게 함
        if (GetComponent<Monster>().hp <= 0)
        {
            StageManager.DestroyMonster();
            StageManager.ClearUI();
        }
    }
}
