using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    public int piramiddoNum = 0;
    public int treasureNum = 0;
    public int hp = 3;
    public GameObject clearWarp;

    //Heart
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    Image image1;
    Image image2;
    Image image3;
    public Sprite heart;
    public Sprite noHeart;

    //Chet&Mimick
    public GameObject chest;
    public GameObject mimick;
    public Vector3[] boxLocate;
    public int[] boxDirection;
    // Start is called before the first frame update
    void Start()
    { 
        clearWarp.SetActive(false);
        image1 = heart1.GetComponent<Image>();
        image2 = heart2.GetComponent<Image>();
        image3 = heart3.GetComponent<Image>();

        int mimick1 = Random.Range(0, 7);
        int mimick2 = Random.Range(0, 7);
        int mimick3 = Random.Range(0, 7);

        while (mimick1 == mimick2 | mimick2 == mimick3 | mimick1 == mimick3)
        {
            mimick1 = Random.Range(0, 7);
            mimick2 = Random.Range(0, 7);
            mimick3 = Random.Range(0, 7);
        }

        for (int i = 0; i < boxLocate.Length; i++)
        {
            if (i == mimick1 | i == mimick2 | i == mimick3)
            {
                GameObject mimicks = Instantiate(mimick) as GameObject;
                mimicks.transform.position = boxLocate[i];
                mimicks.transform.rotation = Quaternion.Euler(0, boxDirection[i], 0);
            }
            else
            {
                GameObject chests = Instantiate(chest) as GameObject;
                chests.transform.position = boxLocate[i];
                chests.transform.rotation = Quaternion.Euler(0, boxDirection[i], 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (piramiddoNum == 3)
        {
            clearWarp.SetActive(true);
        }

        if (hp == 3)
        {
            image1.sprite = heart;
            image2.sprite = heart;
            image3.sprite = heart;
        }
        else if (hp == 2)
        {
            image3.sprite = noHeart;
        }
        else if (hp == 1)
        {
            image2.sprite = noHeart;
        }
        else if (hp == 0)
        {
            image1.sprite = noHeart;
            Debug.Log("GameOver");
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
