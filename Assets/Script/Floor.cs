using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public void Rotation(GameObject player)
    {
        player.transform.rotation = transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rotation(other.gameObject);
        }
        if (other.gameObject.tag == "Monster")
        {
            Rotation(other.gameObject);
        }
    }
}
