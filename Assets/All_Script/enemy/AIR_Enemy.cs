using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIR_Enemy : MonoBehaviour
{
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Rigidbody2D rb;
    Vector2 EnemyPosotion;
    CircleCollider2D rc;

    [SerializeField] int _hp = 5;
    [SerializeField] float _Xspeed  ;
    [SerializeField] float _Yspeed  ;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;

    bool isVisible = false;

    [SerializeField] float m_lifeTime = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rc = GetComponent<CircleCollider2D>();
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

        Destroy(this.gameObject, m_lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

        if (PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + _Xspeed;
        }
        else if (PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - _Xspeed;
        }
        
        if (PlayeyPosition.y > EnemyPosotion.y)
        {
            EnemyPosotion.y = EnemyPosotion.y + _Yspeed;
        }
        else if (PlayeyPosition.y < EnemyPosotion.y)
        {
            EnemyPosotion.y = EnemyPosotion.y - _Yspeed;
        }

        Vector3 pPos = PlayerObject.transform.position;
        Vector3 pos = transform.position;

        Vector3 diff = pPos - pos;
        rb.velocity = diff.normalized * m_h;



        transform.position = EnemyPosotion;
        if(_hp <= 0 )
        {
            Destroy(gameObject);
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
            _hp -= 1;
        }

        if (collision.gameObject.tag == ("Bom"))
        {
            _hp -= 10;
        }

        if(collision.gameObject.tag == ("Destroy"))
        {
            Destroy(gameObject);
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