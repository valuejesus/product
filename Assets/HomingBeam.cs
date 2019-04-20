using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBeam : MonoBehaviour
{
    public Transform Player;
    private GameObject player;
    
    private Vector3 vector3 = new Vector3(0, 2, 2);

    private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vector3 * speed);
        transform.LookAt(player.transform);
        Destroy(gameObject, 15f);
    }
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
