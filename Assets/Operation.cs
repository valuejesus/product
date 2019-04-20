using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operation : MonoBehaviour
{
    public GameObject operation;

    public Text text;

    public GameObject dron;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartOperation");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dron != null)
        if(dron.activeSelf == true)
        {
            Destroy(text);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (operation.activeSelf == false)
            {
                operation.SetActive(true);
            }
            else
            {
                operation.SetActive(false);
            }
        }
    }
    IEnumerator StartOperation()
    {
        text.text = "プレイして頂きありがとうございます";
        yield return new WaitForSeconds(3);
        text.text = "左下の操作説明を確認してください";
        yield return new WaitForSeconds(3);
        text.text = "操作説明はスペースキーで表示・非表示を切り替えられます";
        yield return new WaitForSeconds(3);
        text.text = "中央の白い光に触れると戦闘が始まります";
        yield return new WaitForSeconds(3);
    }
}
