using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Go_Title : MonoBehaviour
{
    [SerializeField] float _timer;
    [SerializeField] Text _timerlimit;

    public static int _Hp = 3;
    public static float _MaxHp = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float _count = 10 - _timer;
        _timerlimit.text = $"{_count.ToString("F0")}";
        if (_count <= 0.01f)
        {
            //SceneManager.LoadScene("Title");
            Invoke("MoveScene2",0.5f);
            _Hp = 3;
            _MaxHp = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))        
        {
            //SceneManager.LoadScene("stage1");
            Invoke("MoveScene", 0.5f);
            _Hp = 3;
            _MaxHp = 1f;
        }

    }

     void MoveScene()
    {
        SceneManager.LoadScene("stage1");

    }
    void MoveScene2()
    {
        SceneManager.LoadScene("Title");

    }

}
