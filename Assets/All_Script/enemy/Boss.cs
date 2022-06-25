using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] float _tagetarea = 15f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Rigidbody2D rb;
    Vector2 EnemyPosotion;
    CircleCollider2D rc;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    [SerializeField] int _Hp = 5;

    bool isVisible = false;

    [SerializeField] Image _GameClear;
    [SerializeField] Text _time;
    [SerializeField] Image _title;

    [SerializeField] GameObject destroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rc = GetComponent<CircleCollider2D>();
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);

        if (distance < _tagetarea && PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + 0.02f;
        }
        else if (distance < _tagetarea && PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - 0.02f;
        }

        transform.position = EnemyPosotion;
        if (_Hp <= 0)
        {
            Destroy(gameObject);
            _GameClear.gameObject.SetActive(true);
            _title.gameObject.SetActive(true);
            destroy.gameObject.SetActive(true);
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            _Hp -= 1;
        }

        if (collision.gameObject.tag == ("Bom"))
        {
            _Hp -= 10;
        }

    }

    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        m_scaleX = this.transform.localScale.x;

        if (PlayeyPosition.x > EnemyPosotion.x)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (PlayeyPosition.x < EnemyPosotion.x)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }

    }
}