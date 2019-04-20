using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Reset1 : MonoBehaviour
{
    private ObjectResetter resetter;
    // Start is called before the first frame update
    void Start()
    {
        resetter = GetComponent<ObjectResetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            resetter.DelayedReset(1f);
            Debug.Log("Reset");
        }
        
    }
    public void Reset()
    {
        Debug.Log("リセット");
    }
}
