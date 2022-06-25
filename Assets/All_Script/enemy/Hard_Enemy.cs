using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Enemy : MonoBehaviour
{
    [SerializeField] float _tagetarea = 2f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Rigidbody2D rb;
    Vector2 EnemyPosotion;
    CircleCollider2D rc;

    [SerializeField] int _hp = 30;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool m_flipX = false;

    bool isVisible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rc = GetComponent<CircleCollider2D>();
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

    }

    void Update()
    {
        m_h = Input.GetAxisRaw("Horizontal");

        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);

        if (distance < _tagetarea && PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + 0.03f;
        }
        else if (distance < _tagetarea && PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - 0.03f;
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            _hp -= 1;
        }

        if (collision.gameObject.tag == ("Bom"))
        {
            _hp -= 25;
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