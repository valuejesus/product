using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour
{
    public GameObject enemybeam;
    public GameObject enemybeam2;


    public Transform shootpoint;
    public Transform shootpoint2;
    public Transform shootpoint3;
    public Transform shootpoint4;

    public DamegeParticle damegeParticle;
    public Transform Player;

    private float speed = 10f;

    private Ray ray;

    private RaycastHit raycastHit;

    private Vector3 vector3;

    private float shoottime;
    private float shoottime2;

    private float waittime = 2f;
    private float waittime2 = 4f;
    private float waittime_r;

    public GameObject Dron;


    float d;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        shoottime += Time.deltaTime;
        shoottime2 += Time.deltaTime;


        waittime_r = Random.Range(0, 1000);





        if (Dron != null)
            if (Dron.activeSelf == true && damegeParticle.AP >= 5000)
            {
                if (waittime < shoottime)
                {
                    Beam();
                }
 
            }else if(damegeParticle.AP < 5000)
            {
                if(waittime_r >= 900)
                {
                    Beam();
                    Beam2();
                }
            }
    }
    void Beam()
    {
        shootpoint.transform.LookAt(Player.transform);

        GameObject beam = Instantiate(enemybeam) as GameObject;

        beam.transform.position = shootpoint.position;

        beam.transform.rotation = shootpoint.rotation;

        vector3 = shootpoint.transform.rotation * new Vector3(0, 0, 100);
        

        beam.GetComponent<Rigidbody>().AddForce(vector3 * speed);

        shoottime = 0f;
    }
    void Beam2()
    {
        

        shootpoint4.transform.LookAt(Player.transform);

        if (waittime2 <= shoottime2)
        {
            GameObject beam_diffusion = Instantiate(enemybeam2) as GameObject;
            beam_diffusion.transform.position = shootpoint4.position;
            beam_diffusion.transform.rotation = shootpoint4.rotation;

            shoottime2 = 0;
        }

        

        
        GameObject beam2 = Instantiate(enemybeam) as GameObject;
        GameObject beam3 = Instantiate(enemybeam) as GameObject;
        

        
        beam2.transform.position = shootpoint2.position;
        beam3.transform.position = shootpoint3.position;

        
        beam2.transform.rotation = shootpoint2.rotation;
        beam3.transform.rotation = shootpoint3.rotation;

        vector3 = shootpoint.transform.rotation * new Vector3(100, 0, 0);


        beam2.GetComponent<Rigidbody>().AddForce(vector3 * speed);
        beam3.GetComponent<Rigidbody>().AddForce(-vector3 * speed);

        
    }
}
