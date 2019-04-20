using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public GameObject Beam;

    public GameObject handBeam;

    public GameObject fannelBeam;

    public GameObject Player;



    public Transform Muzzle;
    public Transform Muzzle2;
    public Transform Muzzle3;
    public Transform FNMuzzle;
    public Transform FNMuzzle2;
    public Transform FNMuzzle3;
    public Transform FNMuzzle4;
    public Transform FNMuzzle5;


    public float speed = 100f;

    private bool Cannon;
    private bool Handbeam;
    private bool Fannel = false;

    private Vector3 vector3;

    private bool weapon = false;

    public RayCastController castController;

    public AudioSource Cannon_audio;
    public AudioSource ArmBeam_audio;
    public AudioSource Fannel_Injection_audio;
    public AudioSource FannelBeam_audio;
    public AudioSource WeaponChange_audio;

    private float Cannon_capacity = 10;
    private float ArmBeam_capacity = 40;
    public float Fannel_capacity = 50;

   
    public Text Cannon_capacity_text;
    public Text ArmBeam_capacity_text;
    public Text Fannel_capacity_text;

    private bool r = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            weapon = true;
        }
        if (weapon == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WeaponChange_audio.Play();

                Cannon = true;

                Handbeam = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WeaponChange_audio.Play();

                Handbeam = true;

                Cannon = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Fannel_Injection_audio.Play();

                Fannel = true;
            }

            if (Input.GetMouseButtonDown(1))
            {

                if (Cannon == true && Cannon_capacity > 0)
                {
                    BeamCannon();
                    
                }
                if (Handbeam == true && ArmBeam_capacity > 0)
                {
                    ArmBeam();
                }
                if (Fannel == true && Fannel_capacity > 0)
                {
                    Fannel_Cannon();
                }
            }
            

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            weapon = false;

            Fannel = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Fannel = false;
        }

        Cannon_capacity_text.text = ""+Cannon_capacity;
        ArmBeam_capacity_text.text = ""+ArmBeam_capacity;
        Fannel_capacity_text.text = ""+Fannel_capacity;
        
        if(Cannon_capacity <= 0)
        {
            StartCoroutine("Reload_Cannon"); 
        }
        if(Cannon_capacity == 10)
        {
            StopCoroutine("Reload_Cannon");
        }
        
        if (ArmBeam_capacity <= 0)
        {
            StartCoroutine("Reload_ArmBeam");
        }
        if(ArmBeam_capacity == 40)
        {
            StopCoroutine("Reload_ArmBeam");
        }
        if (Fannel_capacity <= 0)
        {
            StartCoroutine("Reload_Fannel");
        }
        if (Fannel_capacity == 50)
        {
            StopCoroutine("Reload_Fannel");
        }
    }
    void BeamCannon()
    {
        Cannon_audio.Play();

        GameObject Beams = Instantiate(Beam) as GameObject;

        Muzzle.transform.rotation = Player.transform.rotation;
        Beams.transform.rotation = Muzzle.transform.rotation;

        Beams.transform.position = Muzzle.position;

        Cannon_capacity -= 1;
    }
   void ArmBeam()
    {

        GameObject HandBeams = Instantiate(handBeam) as GameObject;
        GameObject HandBeams2 = Instantiate(handBeam) as GameObject;


        vector3 = Player.transform.rotation * new Vector3(0, 0, 100) * speed;

        HandBeams.GetComponent<Rigidbody>().AddForce(vector3);
        HandBeams2.GetComponent<Rigidbody>().AddForce(vector3);


        Muzzle2.transform.LookAt(castController.Lookat);
        Muzzle3.transform.LookAt(castController.Lookat);

        HandBeams.transform.rotation = Muzzle2.transform.rotation;
        HandBeams2.transform.rotation = Muzzle3.transform.rotation;

        HandBeams.transform.position = Muzzle2.position;
        HandBeams2.transform.position = Muzzle3.position;

        ArmBeam_audio.Play();

        ArmBeam_capacity -= 2;
    }
    void Fannel_Cannon()
    {
        GameObject FannelBeams = Instantiate(fannelBeam) as GameObject;
        GameObject FannelBeams2 = Instantiate(fannelBeam) as GameObject;
        GameObject FannelBeams3 = Instantiate(fannelBeam) as GameObject;
        GameObject FannelBeams4 = Instantiate(fannelBeam) as GameObject;
        GameObject FannelBeams5 = Instantiate(fannelBeam) as GameObject;

        FannelBeams.transform.rotation = FNMuzzle.transform.rotation;
        FannelBeams2.transform.rotation = FNMuzzle2.transform.rotation;
        FannelBeams3.transform.rotation = FNMuzzle3.transform.rotation;
        FannelBeams4.transform.rotation = FNMuzzle4.transform.rotation;
        FannelBeams5.transform.rotation = FNMuzzle5.transform.rotation;

        FannelBeams.transform.position = FNMuzzle.position;
        FannelBeams2.transform.position = FNMuzzle2.position;
        FannelBeams3.transform.position = FNMuzzle3.position;
        FannelBeams4.transform.position = FNMuzzle4.position;
        FannelBeams5.transform.position = FNMuzzle5.position;

        FannelBeam_audio.Play();

        Fannel_capacity -= 5;
    }
    IEnumerator Reload_Cannon()
    {
        Cannon_capacity_text.text = "リロード中…";
        yield return new WaitForSeconds(10);
        Cannon_capacity = 10;
        yield return null;
        
    }
    IEnumerator Reload_ArmBeam()
    {
        
        ArmBeam_capacity_text.text = "リロード中…";
        yield return new WaitForSeconds(10);
        ArmBeam_capacity = 40;
        yield return null;
    }
    IEnumerator Reload_Fannel()
    {
        Fannel = false;
        Fannel_capacity_text.text = "リロード中…";
        yield return new WaitForSeconds(10);
        Fannel_capacity = 50;
        yield return null;
    }
}
