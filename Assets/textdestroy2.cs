using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textdestroy2 : MonoBehaviour
{
    public r_01Controller r_01Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(r_01Controller.AP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
