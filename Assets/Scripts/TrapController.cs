using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    Animator anim;
    bool trapMove;
    bool trapOK;

    GameContoller gameContoller;
    // Start is called before the first frame update
    void Start()
    {
        gameContoller = GameObject.Find("GameController").GetComponent<GameContoller>();
        anim = GetComponent<Animator>();
        trapMove = false;
        trapOK = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (trapMove & trapOK)
        {
            trapMove = false;
            trapOK = false;
            anim.SetBool("StepOn", true);
            if (gameContoller.nagagutu)
            {
                gameContoller.nagagutuLimit--;
            }
            else
            {
                gameContoller.hp--;
            }
            StartCoroutine("WaitTime");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trapMove = true;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("StepOn", false);
        trapOK = true;
    }
}
