using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Go_Title1 : MonoBehaviour
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("Title");
            Invoke("MoveScene2", 0.5f);
            _Hp = 3;
           _MaxHp = 1f;
        }
    }
    void MoveScene2()
    {
        SceneManager.LoadScene("Title");

    }
}
