using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    RaycastHit hitInfo;
    public Camera camera;
    private Vector3 Center;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Center = new Vector3(Screen.width >> 1, Screen.height >> 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(camera.ScreenPointToRay(Center), out hitInfo, 10.0f, LayerMask.GetMask("Highlight", "addedOBJ")))
        {
            GameObject game = hitInfo.collider.gameObject;
            rb = game.GetComponent<Rigidbody>();
            if (game.tag == "lever")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    game.GetComponent<Animator>().enabled = true;
                }

            }
        }
    }
}
