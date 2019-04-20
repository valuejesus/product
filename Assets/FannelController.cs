using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class FannelController : MonoBehaviour
{
    public GameObject fannel;
    public GameObject fannel2;
    public GameObject fannel3;
    public GameObject fannel4;
    public GameObject fannel5;

    public GameObject flare;
    public GameObject flare2;
    public GameObject flare3;
    public GameObject flare4;
    public GameObject flare5;

    private Vector3 FNvector;
    private Vector3 FNvector2;
    private Vector3 FNvector3;
    private Vector3 FNvector4;
    private Vector3 FNvector5;

    private Quaternion FNquaternion;
    private Quaternion FNquaternion2;
    private Quaternion FNquaternion3;
    private Quaternion FNquaternion4;
    private Quaternion FNquaternion5;

    public RayCastController castController;

    public GameObject Player;

    public GameObject enemy;
    public GameObject R_01;
    

    private bool fn = false;

    private bool weapon = false;

    private bool undo = false;

    private float n = 0;

    public BulletController bulletController;
    // Start is called before the first frame update
    void Start()
    {
        FNvector = fannel.transform.position;
        FNvector2 = fannel2.transform.position;
        FNvector3 = fannel3.transform.position;
        FNvector4 = fannel4.transform.position;
        FNvector5 = fannel5.transform.position;

        FNquaternion = fannel.transform.rotation;
        FNquaternion2 = fannel2.transform.rotation;
        FNquaternion3 = fannel3.transform.rotation;
        FNquaternion4 = fannel4.transform.rotation;
        FNquaternion5 = fannel5.transform.rotation;

    
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            weapon = true;

            undo = false;

            n = 1;
            
        }
        if(bulletController != null)
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Alpha4) || bulletController.Fannel_capacity == 0)
        {
            //weapon = false;

            undo = true;
        }

        if (weapon == true)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {
                undo = false;
                FlareOn();

                fn = true;

                //-Player.transform.rotation * new Vector3(15f, -5f, 5f)

                /* fannel2.transform.position = Vector3.Slerp(transform.position, new Vector3(-1.5f, 1.3f, 0), 0.5f);

                 fannel3.transform.position = Vector3.Slerp(transform.position, new Vector3(0f, 3.3f, 0), 0.5f);

                 fannel4.transform.position = Vector3.Slerp(transform.position, new Vector3(1f, 3, 0), 0.5f);

                 fannel5.transform.position = Vector3.Slerp(transform.position, new Vector3(1.5f, 3, 0), 0.5f);
                 */

                // fannel.transform.rotation = Quaternion.Slerp(transform.rotation,enemy.transform.rotation, 0.3f);
            }
        }
        if(fn == true)
        {
            StartCoroutine(Expansion());

            StartCoroutine(LockOn());

        }
        if(undo == true)
        {
            fn = false;
            StartCoroutine(Cancel());

            FlareOff();
           
        }
    }
    void Injection()
    {
        fannel.transform.Translate(new Vector3(2f, 1f, 1f)* 0.1f);
        fannel2.transform.Translate(new Vector3(0f, 1f, 1f)* 0.1f);
        fannel3.transform.Translate(new Vector3(2f, 0f, 1f)* 0.1f);
        fannel4.transform.Translate(new Vector3(-2f, 1f, 1f)* 0.1f);
        fannel5.transform.Translate(new Vector3(-2f, 0f, 1f)* 0.1f);

        fannel.transform.LookAt(castController.Lookat);
        fannel2.transform.LookAt(castController.Lookat);
        fannel3.transform.LookAt(castController.Lookat);
        fannel4.transform.LookAt(castController.Lookat);
        fannel5.transform.LookAt(castController.Lookat);
    }
    void Lock()
    {
        if (n == 1 && enemy != null)
        {
            fannel.transform.position = Vector3.Slerp(transform.position, enemy.transform.position - new Vector3(-3f, -4f, 0f), 0.8f);
            fannel2.transform.position = Vector3.Slerp(transform.position, enemy.transform.position - new Vector3(3f, -3f, 3f), 0.8f);
            fannel3.transform.position = Vector3.Slerp(transform.position, enemy.transform.position - new Vector3(5f, -5f, 0f), 0.8f);
            fannel4.transform.position = Vector3.Slerp(transform.position, enemy.transform.position - new Vector3(-3f, -2f, 1f), 0.8f);
            fannel5.transform.position = Vector3.Slerp(transform.position, enemy.transform.position - new Vector3(-1f, -4f, 2f), 0.8f);
        }
        
        fannel.transform.LookAt(castController.Lookat);
        fannel2.transform.LookAt(castController.Lookat);
        fannel3.transform.LookAt(castController.Lookat);
        fannel4.transform.LookAt(castController.Lookat);
        fannel5.transform.LookAt(castController.Lookat);
    }
    void Lock2()
    {
        if (enemy == null && R_01 != null)
        {
            fannel.transform.position = Vector3.Slerp(transform.position, R_01.transform.position - new Vector3(-3f, -4f, 0f), 0.8f);
            fannel2.transform.position = Vector3.Slerp(transform.position, R_01.transform.position - new Vector3(3f, -3f, 3f), 0.8f);
            fannel3.transform.position = Vector3.Slerp(transform.position, R_01.transform.position - new Vector3(5f, -5f, 0f), 0.8f);
            fannel4.transform.position = Vector3.Slerp(transform.position, R_01.transform.position - new Vector3(-3f, -2f, 1f), 0.8f);
            fannel5.transform.position = Vector3.Slerp(transform.position, R_01.transform.position - new Vector3(-1f, -4f, 2f), 0.8f);
        }

        fannel.transform.LookAt(castController.Lookat);
        fannel2.transform.LookAt(castController.Lookat);
        fannel3.transform.LookAt(castController.Lookat);
        fannel4.transform.LookAt(castController.Lookat);
        fannel5.transform.LookAt(castController.Lookat);
    }

    void Undo()
    {
        
        fannel.transform.position = Player.transform.position + Player.transform.rotation * FNvector;
        fannel2.transform.position = Player.transform.position + Player.transform.rotation * FNvector2;
        fannel3.transform.position = Player.transform.position + Player.transform.rotation * FNvector3;
        fannel4.transform.position = Player.transform.position + Player.transform.rotation * FNvector4;
        fannel5.transform.position = Player.transform.position + Player.transform.rotation * FNvector5;


        fannel.transform.rotation = Player.transform.rotation * FNquaternion;
        fannel2.transform.rotation = Player.transform.rotation * FNquaternion2;
        fannel3.transform.rotation = Player.transform.rotation * FNquaternion3;
        fannel4.transform.rotation = Player.transform.rotation * FNquaternion4;
        fannel5.transform.rotation = Player.transform.rotation * FNquaternion5;

        
    }
    void FlareOn()
    {
        flare.SetActive(true);
        flare2.SetActive(true);
        flare3.SetActive(true);
        flare4.SetActive(true);
        flare5.SetActive(true);
    }
    void FlareOff()
    {
        flare.SetActive(false);
        flare2.SetActive(false);
        flare3.SetActive(false);
        flare4.SetActive(false);
        flare5.SetActive(false);
    }


    IEnumerator Expansion()
    {
        Injection();
        
        //yield return new WaitForSeconds(3f);
        
        yield break;
    }
    IEnumerator LockOn()
    {
        yield return new WaitForSeconds(2f);

        StopCoroutine(Expansion());
        if(enemy != null)
        {
            Lock();
        }else
        {
            Lock2();
        }
        
        
        yield break;
    }
    IEnumerator Cancel()
    {
        
        StopCoroutine(Expansion());
        StopCoroutine(LockOn());
        Undo();

        //yield return new WaitForSeconds(3f);
        
        yield return null;
    }

}
