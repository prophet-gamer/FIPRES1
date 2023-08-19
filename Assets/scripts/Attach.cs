using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attach : MonoBehaviour
{
    public Camera camera;
    private Vector3 attachpoint;
    private GameObject selected;
    private Vector3 Center;
    private Vector3 rot;
    RaycastHit hitInfo;
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
        if(Physics.Raycast(camera.ScreenPointToRay(Center), out hitInfo, 10.0f))
        {
            GameObject game = hitInfo.collider.gameObject;
            rb = game.GetComponent<Rigidbody>();
            if (game.tag == "interact")
            {
                selected = game;
                if (Input.GetKey(KeyCode.E))
                {
                    game.transform.position = this.gameObject.transform.position;
                    game.transform.SetParent(this.gameObject.transform);
                    rb.mass = 0;
                    rb.useGravity = false; 
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    game.transform.SetParent(null);
                    rb.useGravity = true;
                    rb.mass = 1;
                }
            }
        }
        
    }
}
