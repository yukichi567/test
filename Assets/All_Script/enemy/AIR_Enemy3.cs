using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIR_Enemy3 : MonoBehaviour
{
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Rigidbody2D rb;
    Vector2 EnemyPosotion;
    CircleCollider2D rc;

    [SerializeField] int _hp = 5;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
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
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");

        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

        if (PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + 0.07f;
        }
        else if (PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - 0.07f;
        }

        if (PlayeyPosition.y > EnemyPosotion.y)
        {
            EnemyPosotion.y = EnemyPosotion.y + 0.05f;
        }
        else if (PlayeyPosition.y < EnemyPosotion.y)
        {
            EnemyPosotion.y = EnemyPosotion.y - 0.05f;
        }

        Vector3 pPos = PlayerObject.transform.position;
        Vector3 pos = transform.position;

        Vector3 diff = pPos - pos;
        rb.velocity = diff.normalized * m_h;



        transform.position = EnemyPosotion;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }

        // �ݒ�ɉ����č��E�𔽓]������
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Bullet�^�O�����Q�[���I�u�W�F�N�g�ɓ���������HP��1����
    //    if (collision.gameObject.tag == ("Bullet"))
    //    {
    //        _hp -= 1;
    //    }
    //}
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

    }

    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
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