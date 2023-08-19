using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float movement = 1;
    public float gravity = 9.8f;
    private float velocity = 0;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movement;
        float vertical = Input.GetAxis("Vertical") * movement;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
