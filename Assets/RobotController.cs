using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    private Vector3 vector3;

    private Rigidbody rigidbody;

    private float boostspeed = 10f;

    public float speed = 4f;

    private Quaternion quaternionY;
    private Quaternion quaternionX;

    private float turnspeed = 3f;

    public GameObject Camera;

    public GameObject enemy;
    public GameObject R_01;
    

    private float n;

    public ParticleSystem particle;

    
    private float damege;

    public GameObject canvas;

    public AudioSource audio;

    public Text AP;

    private float armorpoint = 5000;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        //quaternionY = Quaternion.Euler(0,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        /* float x = Input.GetAxis("Horizontal") * boostspeed;

         float z = Input.GetAxis("Vertical") * boostspeed;

         rigidbody.AddForce(x, 0, z);
         */
        float x = transform.position.x;
        float z = transform.position.z;

        if (Input.GetKey(KeyCode.W))
        {
            vector3.z = 1f;
            //vector3 = new Vector3(0f, 0, 1);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            vector3.z = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector3.z = -1f;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            vector3.z = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vector3.x = -1f;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            vector3.x = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector3.x = 1f;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            vector3.x = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            speed = 50f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed = 4f;
        }
        if (vector3.magnitude > 0f)
        {
            transform.position += Camera.transform.rotation * vector3 * Time.deltaTime * speed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Camera.transform.rotation, 1f);
        }
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(x, 0.05f,z);
        }

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Camera.transform.rotation * vector3), 0.1f);
        if (Input.GetMouseButton(1))
        {
            quaternionY *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnspeed, 0);
            //quaternionX *= Quaternion.Euler(Input.GetAxis("Mouse Y") * turnspeed, 0, 0);
        }
        //transform.rotation = quaternionY;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            n = 1;
        }
        if (n == 1 && enemy != null)
        {
            transform.LookAt(enemy.transform);
        }
        if(enemy == null && R_01 != null)
        {
            transform.LookAt(R_01.transform);
        }
       

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            n = 0;
        }
        
        if(armorpoint <= 0)
        {

            StartCoroutine(GameOver());

        }
        if(AP != null)
        AP.text = "AP " + armorpoint;
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "ENBeam")
        {
            particle.Play();

            audio.Play();

            armorpoint -= 100;
        }
    }
    IEnumerator GameOver()
    {
        Time.timeScale = 0.2f;

        canvas.SetActive(true);

        yield return null;
    }
    


        
}

