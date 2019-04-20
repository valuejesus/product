using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 vector3 = new Vector3(0,1.8f,-1.3f);

    private Quaternion quaternion;

    private float turnspeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        quaternion = Quaternion.Euler(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = player.position - transform.rotation * -vector3;

        //transform.Translate(1 * 0.01f, 0, 0);

        quaternion *= Quaternion.Euler(0, 1 * turnspeed, 0); //transform.rotation;
        
        transform.rotation = quaternion;
    }
    //Input.GetAxis("Mouse X")
}
