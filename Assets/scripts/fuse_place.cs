using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse_place : MonoBehaviour
{
    private Rigidbody rig;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        rig = other.GetComponent<Rigidbody>();
        if (other.tag == "fuse")
        {
            rig.freezeRotation = true;
            rig.constraints = RigidbodyConstraints.FreezePosition;
            other.transform.position = this.gameObject.transform.position;
            other.transform.rotation = this.gameObject.transform.rotation;
            other.transform.SetParent(this.gameObject.transform);
            
        }
    }
}
