using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator Door_yellow;
    public string triggerTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Door_yellow.SetBool("isopening", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Door_yellow.SetBool("isopening", false);
        }
    }

    void Awake()
    {
        Door_yellow = this.transform.parent.GetComponent<Animator>();
    }
}
