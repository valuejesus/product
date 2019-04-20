using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public Ray ray;

    public RaycastHit Hit;

    public Vector3 Lookat;

    public Transform Player;

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        transform.rotation = Player.rotation;
        //レイの設定
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //レイキャストの設定（原点、飛ばす方向、衝突した情報、長さ）
        if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
        {
            //レイを可視化
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Hit.distance, Color.yellow);
            

            Lookat = Hit.point;

            
        }
    }
}
