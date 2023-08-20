using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class off_fire : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject tool;
    public GameObject fire;
    public GameObject control;
    public Wire_repair wire;

    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        //tool = other.transform.parent;
        if (other.name == "Fire+extinguisher-final")
        {
            tool = other.gameObject;
            fire.SetActive(false);
            fire.GetComponent<ParticleSystem>().Stop();
            wire.wire = false;
            kill(control, 3);
        }
    }
    public void kill(GameObject other, float num)
    {
        Destroy(other, num);
    }
}
