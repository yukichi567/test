using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Damage : MonoBehaviour
{

    [SerializeField] int _Hp = 200;
    [SerializeField] Image _GameClear;
    [SerializeField] Text _time;
    [SerializeField] Image _Continue;
    [SerializeField] float _timer = 3;

    //スタートボタン設定


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_Hp <= 0)
        {
            _GameClear.gameObject.SetActive(true);
            _time.gameObject.SetActive(true);
            _Continue.gameObject.SetActive(true);
        }

    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_timer >= 3 && collision.gameObject.tag == "Enemy")
            {
                _Hp -= 1;
                _timer = 0;
            }
        }



}

