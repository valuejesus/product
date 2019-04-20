using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
    }
    private void OnParticleCollision(GameObject other)
    {
   
        Destroy(gameObject, 0.05f);
    }
    
}
