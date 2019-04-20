using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaincameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 vector3 = new Vector3(0, 2.5f, -4f);

    private Quaternion quaternionY;
    private Quaternion quaternionX;

    private float turnspeed = 10f;

    private float n = 0;

    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        quaternionX = Quaternion.identity;
        quaternionY = Quaternion.Euler(0, 0, 0);
        transform.position = player.transform.position - transform.rotation * vector3;
    }

    // Update is called once per frame
    void Update()
    {
        x = player.transform.position.x - transform.position.x;
        z = player.transform.position.z - transform.position.z;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            n += 1;
        }

        if (n == 0)
        {
            Normalmode();
        }

        if (n >= 1)
        {
            LockOn();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            n = 0;
        }
    }
    void Normalmode()
    {
        if (Input.GetMouseButton(1))
        {
            quaternionX *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnspeed, 0);
            //quaternionY *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * turnspeed, 0, 0);
        }
        transform.rotation = quaternionX;

        transform.position = player.transform.position - transform.rotation * -vector3;
    }
    void LockOn()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, 0.5f);

        
        transform.position = Vector3.Lerp(transform.position, player.transform.position - transform.rotation * -vector3, 0.2f);
       
    }
}
