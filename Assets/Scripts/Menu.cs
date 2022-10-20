using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Canvas;
    public Playground Playground;

    // public Background background;
    bool Paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
             if(Paused == true)
             {
                 Canvas.gameObject.SetActive(false);
                 Paused = false;
             } else {
                 Canvas.gameObject.SetActive(true);
                 Paused = true;
             }

            Playground.Pause(Paused);
         }
    }
}
