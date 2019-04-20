using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamegeParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public ParticleSystem damege_effect;

    private Vector3 vector3;

    private Animator animator;
    
    private AudioSource audio;

    public AudioSource audio2;

    private bool d = false;
    private bool d2 = false;

    public Text text;

    public GameObject r_01;

    public float AP = 10000;

    public Text APtext;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        animator = GetComponent<Animator>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AP <= 5000)
        {
            if (!d)
            {
                d = true;

                audio.Play();

                StartCoroutine(Production());
                
            }
        }
        if(AP <= 0)
        {
            if (!d2)
            {
                d2 = true;

                r_01.SetActive(true);

                animator.SetBool("Dead", true);

                audio.Play();

                StartCoroutine(Dead());
            }
        }
        if (APtext != null)
        {
            APtext.text = "敵AP " + AP;
        }
    }

    
    private void OnParticleCollision(GameObject other)
    {
        
        if(other.gameObject.tag == "Laser")
        {
            AP -= 50;
        }
        if (other.gameObject.tag == "CannonBeam")
        {
            AP -= 300;
        }
        if (other.gameObject.tag == "ArmsBeam")
        {
            AP -= 100;
        }
    }
    void DamegeEffect()
    {
        particleSystem.Play();

        damege_effect.Play();

        audio2.Play();
    }
    
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

        yield return null;
    }
    IEnumerator Production()
    {
        
        text.text = "Level2";

        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        text.text = "";
        StopCoroutine(Production());
        yield return null;
    }
    
}
