using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class kameme : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>移動速度</summary>
    [SerializeField] float _moveSpeed = 1f;
    private SpriteRenderer Renderer;
    /// <summary>壁を検出するための line のオフセット</summary>
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    ///// <summary>床を検出するための line のオフセット</summary>
    //[SerializeField] Vector2 _lineForGround = new Vector2(1f, -1f);
    ///// <summary>床のレイヤー</summary>
    //[SerializeField] LayerMask _groundLayer = 0;
    ///// <summary>移動方向</summary>
    //Vector2 _moveDirection = Vector2.right;
    Rigidbody2D _rb = default;
    bool _wall = true;
    Vector2 _Line = new Vector2(5f, 0f);
    [SerializeField] float _tagetarea = 0.1f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Vector2 EnemyPosotion;
    float m_h;
    //float m_scaleX;
    [SerializeField] bool m_flipX = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        Renderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        m_h = Input.GetAxisRaw("Horizontal");
        Move();
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);
        if (distance < _tagetarea && PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + 0.03f;
        }
    }
    void Move()
    {
        Vector2 start = this.transform.position;   // start は「LineCast の始点」である
        Debug.DrawLine(start, start + _lineForWall);  // 検出するセンサーとなる Line を Scene に描く
        // 壁の検出を試みる
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);    // hit には line の衝突情報が入っている
        Vector2 velo = Vector2.zero; // velo は速度のベクトル
        if (!hit.collider)  // hit.collider は「ray が衝突した collider」が入っている。ray が何にもぶつからなかったら null である。
        {
            // 何も検出しなかったら方向を決める
            velo = _lineForWall * _moveSpeed;
        }
        else
        {
            if (_wall)
            {
                //_lineForGround = new Vector2(1f, -1f);
                _lineForWall = new Vector2(3f, 0f);
                _wall = false;
                Renderer.flipX = true;

            }
            else
            {
                //_lineForGround = new Vector2(-1f, -1f);
                _lineForWall = new Vector2(-3f, 0f);
                _wall = true;
                Renderer.flipX = false;
            }
        }
        velo.y = _rb.velocity.y;    // 落下については現在の値を保持する
        _rb.velocity = velo;        // 速度ベクトルをセットする
    }

}