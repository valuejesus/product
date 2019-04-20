using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : MonoBehaviour
{
    public Transform homing_laser;
    public Transform homing_laser2;
    public Transform homing_laser3;

    private Vector3 vector3;
    private Vector3 vector3_2;
    private Vector3 vector3_3;

    public Transform Player;

    private Vector3 homing_vector = new Vector3(0,2,1);
    private Vector3 homing_vector2 = new Vector3(1,0.5f,1);
    private Vector3 homing_vector3 = new Vector3(-1,0.5f,1);

    private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        vector3 = homing_laser.position;
        vector3_2 = homing_laser2.position;
        vector3_3 = homing_laser3.position;
    }

    // Update is called once per frame
    void Update()
    {
        homing_laser.Translate(homing_vector * speed);
        homing_laser2.Translate(homing_vector2 * speed);
        homing_laser3.Translate(homing_vector3 * speed);

        homing_laser.LookAt(Player);
        homing_laser2.LookAt(Player);
        homing_laser3.LookAt(Player);
    }
}
