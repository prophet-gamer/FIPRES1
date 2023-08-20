using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.VFX;

public class timeline : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject scene;
    public Wire_repair wires;
    public fuse_place fuses;
    private PlayableDirector direct;
    public float targetTime = 5.0f;

    [System.Obsolete]
    void Update()
    {
        if(wires.wire && fuses.fuse)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            scene.SetActive(true);
            scene.GetComponent<ParticleSystem>().Play();
            targetTime -= Time.deltaTime;
        }

        if (targetTime <= 0.0f)
        {
            cam2.enabled = false;
            cam1.enabled = true;
            //scene.SetActive(false);
            //scene.GetComponent<ParticleSystem>().Stop();
        }
    }

}
