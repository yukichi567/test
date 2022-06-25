using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class kameme : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>�ړ����x</summary>
    [SerializeField] float _moveSpeed = 1f;
    private SpriteRenderer Renderer;
    /// <summary>�ǂ����o���邽�߂� line �̃I�t�Z�b�g</summary>
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    /// <summary>�ǂ̃��C���[�i���C���[�̓I�u�W�F�N�g�ɐݒ肳��Ă���j</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>�������o���邽�߂� line �̃I�t�Z�b�g</summary>
    [SerializeField] Vector2 _lineForGround = new Vector2(1f, -1f);
    /// <summary>���̃��C���[</summary>
    [SerializeField] LayerMask _groundLayer = 0;
    /// <summary>�ړ�����</summary>
    Vector2 _moveDirection = Vector2.right;
    Rigidbody2D _rb = default;
    bool _wall = true;
    Vector2 _Line = new Vector2(5f, 0f);
    [SerializeField] float _tagetarea = 0.1f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Rigidbody2D rb;
    Vector2 EnemyPosotion;
    CircleCollider2D rc;
    float m_h;
    float m_scaleX;
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
        Vector2 start = this.transform.position;   // start �́uLineCast �̎n�_�v�ł���
        Debug.DrawLine(start, start + _lineForWall);  // ���o����Z���T�[�ƂȂ� Line �� Scene �ɕ`��
        // �ǂ̌��o�����݂�
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);    // hit �ɂ� line �̏Փˏ�񂪓����Ă���
        Vector2 velo = Vector2.zero; // velo �͑��x�̃x�N�g��
        if (!hit.collider)  // hit.collider �́uray ���Փ˂��� collider�v�������Ă���Bray �����ɂ��Ԃ���Ȃ������� null �ł���B
        {
            // �������o���Ȃ���������������߂�
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
        velo.y = _rb.velocity.y;    // �����ɂ��Ă͌��݂̒l��ێ�����
        _rb.velocity = velo;        // ���x�x�N�g�����Z�b�g����
    }

}