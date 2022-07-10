using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Damage : MonoBehaviour
{
    [SerializeField] Image _Life;
    [SerializeField] public int _Hp = 3;
    [SerializeField] Image _BackGround;
    [SerializeField] Image _GameOver;
    [SerializeField] Text _time;
    [SerializeField] Image _Continue;
    [SerializeField] float _timer = 3;

     float _MaxHp = 1f;

    GameObject RM;
    GameObject PM;
    //スタートボタン設定


    // Start is called before the first frame update
    void Start()
    {
        RM = GameObject.Find("Rock_Marker");
        PM = GameObject.Find("marimo");
        Debug.Log(_Hp);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        var CM = RM.GetComponent<Rock_Marker>();
        var MOVE = PM.GetComponent<NewPlayer>();
        _Life.GetComponent<Image>().fillAmount = _MaxHp;

        if (_Hp <= 0)
        {
            _BackGround.gameObject.SetActive(true);
            _GameOver.gameObject.SetActive(true);
            _time.gameObject.SetActive(true);
            _Continue.gameObject.SetActive(true);
            CM.Marker_off = false;
            MOVE.speed = 0f;
            MOVE.jumpForce = 0f;
        }

    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_timer >= 3 && collision.gameObject.tag == "Enemy")
            {
                _Hp -= 1;
                _timer = 0;
                _MaxHp -= 0.33334f;
            }
        }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Holy Light")
        {
            _Hp = 3;
            _MaxHp = 1f;
        }
    }

}

