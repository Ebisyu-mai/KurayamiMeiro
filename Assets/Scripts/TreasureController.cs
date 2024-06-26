using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    Animator anim;
    bool inRange;
    bool treasureGet;
    public GameObject treasure;
    Renderer rend;

    GameContoller gameContoller;
    // Start is called before the first frame update
    void Start()
    {
        gameContoller = GameObject.Find("GameController").GetComponent<GameContoller>();
        anim = GetComponent<Animator>();
        rend = treasure.GetComponent<Renderer>();
        treasureGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) & inRange & !treasureGet & IsVisible())
        {
            treasureGet = true;
            gameContoller.treasureNum++;
            anim.SetBool("PutF", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    public bool IsVisible()
    {
        return rend.isVisible;
    }
}
