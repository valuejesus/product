using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public GameObject boost;

    public GameObject boost_right;

    public GameObject boost_left;

    public GameObject boost_slight_right;

    public GameObject boost_slight_left;

    public GameObject boost_back;

    public GameObject boost_Trail;

    private ParticleSystem particle;

    private Vector3 vector;

    
    // Start is called before the first frame update
    void Start()
    {
        particle = boost_Trail.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.rotation = Quaternion.Slerp();
        if (Input.GetMouseButtonDown(0))
        {
            boost_Trail.SetActive(true);

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
            {
                if(!Input.GetKey(KeyCode.D))
                Invoke("boost1", 0.1f);

                Invoke("boostOff", 0.25f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Invoke("boost2", 0.1f);

                Invoke("boostOff", 0.25f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Invoke("boost3", 0.1f);

                Invoke("boostOff", 0.25f);
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                Invoke("boost6", 0.1f);

                Invoke("boostOff", 0.25f);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                Invoke("boost4", 0.1f);

                Invoke("boostOff", 0.25f);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                Invoke("boost5", 0.1f);

                Invoke("boostOff", 0.25f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            boost_Trail.SetActive(false);
        }


    }
    void boost1()
    {
        //if (Input.GetMouseButtonDown(0))
            boost.SetActive(true);
    }
    void boost2()
    {
        //if (Input.GetMouseButtonDown(0))
        boost_right.SetActive(true);
    }
    void boost3()
    {
        //if (Input.GetMouseButtonDown(0))
        boost_left.SetActive(true);
    }
    void boost4()
    {
        //if (Input.GetMouseButtonDown(0))
        boost_slight_right.SetActive(true);
    }
    void boost5()
    {
        //if (Input.GetMouseButtonDown(0))
        boost_slight_left.SetActive(true);
    }
    void boost6()
    {
        //if (Input.GetMouseButtonDown(0))
        boost_back.SetActive(true);
    }

    void boostOff()
    {
        
        boost.SetActive(false);
        boost_right.SetActive(false);
        boost_left.SetActive(false);
        boost_slight_right.SetActive(false);
        boost_slight_left.SetActive(false);
        boost_back.SetActive(false);
    }
}
