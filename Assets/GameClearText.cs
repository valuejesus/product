using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearText : MonoBehaviour
{
    public GameObject R_01;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(R_01 == null)
        {
            StartCoroutine(Clear());
            StopCoroutine(Clear());
        }
    }
    IEnumerator Clear()
    {
        text.text = "ゲームクリアです　お疲れ様でした";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ClearScene");
    }
}
