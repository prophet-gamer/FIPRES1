using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class highlight_c : MonoBehaviour
{
    /*
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
        
    }*/
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private Vector3 Center;

    void Start()
    {
        Center = new Vector3(Screen.width >> 1, Screen.height >> 1);
    }

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Center);
        if (Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if ((highlight.CompareTag("interact") || highlight.CompareTag("fuse") || highlight.CompareTag("Open") || highlight.CompareTag("lever")) && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 10.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }
}
