using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class r_01Controller : MonoBehaviour
{
    public Transform Player;

    public ParticleSystem damege_particle;

    public AudioSource audioSource;

    public float damege;

    public AudioSource burst;

    private bool b = false;

    public Text R_01APtext;

    public float AP = 20000;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("enumerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (R_01APtext != null)
        {
            R_01APtext.text = "敵AP　" + AP;
        }

        transform.LookAt(Player);
        transform.Translate(0, 0,1 * 0.02f);

        if(AP <= 0)
        {
            if (!b)
            {
                b = true;
                burst.Play();
                Destroy(gameObject, 1f);
            }
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        
        if (other.gameObject.tag == "Laser")
        {
            DamegeParticle();
            AP -= 50;
        }
        if (other.gameObject.tag == "CannonBeam")
        {
            DamegeParticle();
            AP -= 300;
        }
        if (other.gameObject.tag == "ArmsBeam")
        {
            DamegeParticle();
            AP -= 100;
        }
    }
    void DamegeParticle()
    {
        damege_particle.Play();
        audioSource.Play();
    }
    IEnumerator enumerator()
    {
        text.text = "level3";
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
}
