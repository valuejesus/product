using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
