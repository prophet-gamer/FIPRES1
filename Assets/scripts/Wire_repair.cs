using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Wire_repair : MonoBehaviour
{
    public bool wire;
    public GameObject connect1;
    public GameObject connect2;
    private GameObject tool;
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        //tool = other.transform.parent;
        if (other.name == "Pliers")
        {
            connect1.SetActive(true);
            connect2.SetActive(true);
            tool = other.gameObject;
            other.transform.SetParent(null);
            rb.mass = 1;
            rb.useGravity = true;
            other.GetComponent<Animator>().enabled = true;

            wire = true;
            kill(tool, 3);
        }

    }
    public void kill(GameObject other, float num)
    {
        if (other.name == "Pliers")
        {
            Destroy(other, num);
        }
    }
}
