using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Camera camera;
    private Vector3 attachpoint;
    private GameObject selected;
    private Vector3 Center;
    private Vector3 rot;
    RaycastHit hitInfo;
    private Rigidbody rb;
    public Event_Open open;

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

            if (game.tag == "Open" && open.isopen == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    selected = game.transform.parent.gameObject;
                    selected.transform.localRotation = Quaternion.Slerp(selected.transform.localRotation, Quaternion.Euler(-90, 0, 200), 2 * Time.deltaTime);
                }
            }
        }
    }

}
