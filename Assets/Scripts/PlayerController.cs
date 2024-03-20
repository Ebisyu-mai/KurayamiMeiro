using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public float sensitivityX = 15;
    public float sensitivityY = 15;

    public float minimumX = -360;
    public float maximumX = 360;

    public float minimumY = -60;
    public float maximumY = 60;

    public float rotationX = 0;
    public float rotationY = 0;

    public GameObject verRot;
    public GameObject horRot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationYにYの移動量*sensitivityYの分だけ増やす
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//rotationYを-60〜60の値にする

        verRot.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする
        horRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする


        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
    }
}
