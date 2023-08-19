using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Event_Open : MonoBehaviour
{
    private GameObject tool;
    private Rigidbody rb;
    public bool isopen;
    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        //tool = other.transform.parent;
        if (other.name == "MonkeyWrench")
        {            
            tool = other.gameObject;
            other.transform.SetParent(null);
            rb.mass = 1;
            rb.useGravity = true;
            other.GetComponent<Animator>().enabled = true;
            isopen = true;
            kill(tool, 3);
        }
            
    }
    public void stop()
    {
        tool.GetComponent<Animator>().enabled = false;
    }
    public void kill(GameObject other, float num)
    {
        if(other.name == "MonkeyWrench")
        {
            Destroy(other, num);
        }
    }

}
