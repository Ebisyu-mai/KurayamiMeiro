using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimickController : MonoBehaviour
{
    Animator anim;
    bool inRange;
    bool mimickGet;
    public GameObject mimick;
    Renderer rend;

    GameContoller gameContoller;

    // Start is called before the first frame update
    void Start()
    {
        gameContoller = GameObject.Find("GameController").GetComponent<GameContoller>();
        anim = GetComponent<Animator>();
        rend = mimick.GetComponent<Renderer>();
        mimickGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) & inRange & !mimickGet & IsVisible())
        {
            mimickGet = true;
            gameContoller.hp--;
            anim.SetBool("PutF", true);
            StartCoroutine("WaitAnim");
            
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

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("PutF",false);
        mimickGet = false;
    }
}
