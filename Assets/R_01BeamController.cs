using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_01BeamController : MonoBehaviour
{
    public Transform shootpoint_r;
    public Transform shootpoint2_r;
    public Transform shootpoint3_r;
    public Transform shootpoint4_r;
    public Transform shootpoint5_r;
    public Transform shootpoint6_r;

    public GameObject beam_r;
    public GameObject gatling_beam_r;
    public GameObject diffusion_beam_r;
    public GameObject homing_beam_r;
    public GameObject homing_beam2_r;
    public GameObject homing_beam3_r;

    private float intervaltime_rong = 1f;
    private float intervaltime_gatling = 0.1f;
    private float intervaltime_diffusion = 4f;
    private float intervaltime_homing = 3f;
   

    private float firetime_rong;
    private float firetime_gatling;
    private float firetime_diffusion;
    private float firetime_homing;
    

    public Transform Player;

    private float speed = 30f;

    public Transform R_01;

    private Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        vector3 = R_01.rotation * new Vector3(0, -1, 100);

        shootpoint2_r.LookAt(Player);
        

        firetime_rong += Time.deltaTime;
        firetime_gatling += Time.deltaTime;
        firetime_diffusion += Time.deltaTime;
        firetime_homing += Time.deltaTime;


        if(firetime_rong >= intervaltime_rong)
        {
            RongBeam();
        }
        if (firetime_gatling >= intervaltime_gatling)
        {
            GatlingBeam();
        }
        if (firetime_diffusion >= intervaltime_diffusion)
        {
            DiffusionBeam();
        }
        if (firetime_homing >= intervaltime_homing)
        {
            HomingBeam();
        }

    }
    void RongBeam()
    {
        GameObject rongbeam = Instantiate(beam_r) as GameObject;

        rongbeam.transform.position = shootpoint_r.position;

        rongbeam.transform.rotation = shootpoint_r.rotation;

        firetime_rong = 0;
    }
    void GatlingBeam()
    {
        GameObject gatlingbeam = Instantiate(gatling_beam_r) as GameObject;

        gatlingbeam.transform.position = shootpoint2_r.position;

        gatlingbeam.transform.rotation = shootpoint2_r.rotation;

        gatlingbeam.GetComponent<Rigidbody>().AddForce(vector3 * speed);

        firetime_gatling = 0;
    }
    
    void DiffusionBeam()
    {
        GameObject diffusionbeam = Instantiate(diffusion_beam_r) as GameObject;

        diffusionbeam.transform.position = shootpoint3_r.position;

        firetime_diffusion = 0;
    }
    void HomingBeam()
    {
        GameObject homingbeam = Instantiate(homing_beam_r) as GameObject;
        GameObject homingbeam2 = Instantiate(homing_beam2_r) as GameObject;
        GameObject homingbeam3 = Instantiate(homing_beam3_r) as GameObject;

        homingbeam.transform.position = shootpoint4_r.position;
        homingbeam2.transform.position = shootpoint5_r.position;
        homingbeam3.transform.position = shootpoint6_r.position;

        firetime_homing = 0;
    }

}
