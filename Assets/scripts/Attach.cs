using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attach : MonoBehaviour
{
    RaycastHit hitInfo;
    public Camera camera;
    private Vector3 Center;
    private GameObject selected;
    private Vector3 attachpoint;
    private Vector3 rot;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Center = new Vector3(Screen.width >> 1, Screen.height >> 1);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Physics.Raycast(camera.ScreenPointToRay(Center), out hitInfo, 10.0f, LayerMask.GetMask("Highlight", "addedOBJ")))
        {
            GameObject game = hitInfo.collider.gameObject;
            rb = game.GetComponent<Rigidbody>();
            if (game.tag == "interact" || game.tag == "fuse")
            {
                selected = game;
                if (Input.GetKey(KeyCode.E))
                {
                    game.transform.position = this.gameObject.transform.position;
                    game.transform.SetParent(this.gameObject.transform);
                    if(rb.detectCollisions == true)
                    { 
                        rb.mass = 0;
                        rb.useGravity = false; 
                    } 
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    game.transform.SetParent(null);
                    rb.useGravity = true;
                    rb.mass = 1;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (selected != null)
            {
                selected.transform.SetParent(null);
                rb.useGravity = true;
                rb.mass = 1;
            }
        }
    }
}
