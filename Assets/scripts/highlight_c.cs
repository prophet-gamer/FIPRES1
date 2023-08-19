using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class highlight_c : MonoBehaviour
{
    public Camera camera;
    private int DefaultLayer;
    private int HighlightLayer;
    private Vector3 Center;
    private GameObject currentTarget;
    RaycastHit hitInfo;
    private bool hit;
    
    // Start is called before the first frame update
    void Start()
    {
        Center = new Vector3(Screen.width >> 1, Screen.height >> 1);
        DefaultLayer = LayerMask.NameToLayer("Default");
        HighlightLayer = LayerMask.NameToLayer("Highlight");
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(camera.ScreenPointToRay(Center), out hitInfo, 5.0f, LayerMask.GetMask("Highlight", "addedOBJ")))
        {
            GameObject game = hitInfo.collider.gameObject;
            if (currentTarget != game)
            {
                
                currentTarget = game;
                currentTarget.layer = 3;
                hit = true;
            }
        }
        else if(currentTarget != null)
        {
            currentTarget.layer = 6;
            currentTarget = null;
        }
        
    }
}
