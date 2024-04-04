using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public int piramiddoNum = 0;
    public int treasureNum = 0;
    public GameObject clearWarp;
    // Start is called before the first frame update
    void Start()
    {
        clearWarp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (piramiddoNum == 3)
        {
            clearWarp.SetActive(true);
        }
    }
}
