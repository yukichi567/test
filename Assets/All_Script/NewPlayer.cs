using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{

    //移動速度
    [SerializeField] public float speed = 0f;
    private SpriteRenderer Renderer;
    private Rigidbody2D _rb;
    //2Dジャンプ
    [SerializeField] public float jumpForce = 0f;
    [SerializeField] private int jumpCount = 0;

    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool _flipX = false;
    [SerializeField] int hp = 5;

    private string enemyTag = "Enemy";
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
       _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed;
            Renderer.flipX = false;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            position.x += speed;
            Renderer.flipX = true;
        }
        transform.position = position;

        if (Input.GetKey(KeyCode.Space) && this.jumpCount < 2)
        {
            this._rb.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == enemyTag)
        {
            Debug.Log("敵と接触した！");
        }
         else if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }
}
