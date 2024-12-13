using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointdoortutorial : MonoBehaviour
{
    Animator Door_orange;
    public string triggerTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Door_orange.SetBool("orangeopen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Door_orange.SetBool("orangeopen", false);
        }
    }

    void Awake()
    {
        Door_orange = this.transform.parent.GetComponent<Animator>();
    }
}
