﻿using UnityEngine;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 15f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>色の配列</summary>
    [SerializeField] Color[] m_colors = default;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;

    Animator _animator;
    /// <summary>m_colors に使う添字</summary>
    int m_colorIndex;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    bool onGround = true;
    int jumpCount = 0; //何回ジャンプしたか
    bool jump;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        // 各種入力を受け取る
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("ここにジャンプする処理を書く。");
            //float jmp = AddForce(m_jumpPower);

            if (jumpCount < 2) jump = true;

        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ここに弾を発射する処理を書く。");
            GameObject go = Instantiate(m_bulletPrefab,m_muzzle.transform.position,Quaternion.identity);
            //go.transform.position = transform.position;
            go.GetComponent<BulletController>().dir = (int)m_scaleX;
         }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("ここに色を切り替える処理を書く。");
            //for()
            //m_sprite.color = Color.black;
            m_sprite.color = m_colors[m_colorIndex% m_colors.Length];
            m_colorIndex++;


        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }

    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);

        if (jump)
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            jump = false;

            jumpCount++;
        }
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
    }


    
}
