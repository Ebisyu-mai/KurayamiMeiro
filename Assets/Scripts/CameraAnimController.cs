using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimController : MonoBehaviour
{
    GameContoller gameContoller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameContoller = GameObject.Find("GameController").GetComponent<GameContoller>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameContoller.gameOver)
        {
            anim.enabled = true;
        }
    }
}
