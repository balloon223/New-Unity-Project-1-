using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(isOpened == false)
        {
            isOpened = true;
            door.transform.position += new Vector3(0, -10);
        }
    }
}