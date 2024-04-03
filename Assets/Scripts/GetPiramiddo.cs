using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPiramiddo : MonoBehaviour
{
    bool inRange;
    bool piramiddoGet;
    public GameObject piramiddo;
    Renderer rend;
    GameContoller gameContoller;
    // Start is called before the first frame update
    void Start()
    {
        rend = piramiddo.GetComponent<Renderer>();
        gameContoller = GameObject.Find("GameController").GetComponent<GameContoller>();
        piramiddoGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !piramiddoGet)
        {
            if (IsVisible() && inRange)
            {
                piramiddoGet = true;
                gameContoller.piramiddoNum++;
                Destroy(piramiddo);
            }
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
