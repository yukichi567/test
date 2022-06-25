using UnityEngine;

/// <summary>
/// 弾丸を制御するコンポーネント
/// </summary>
public class BomController : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_initialSpeed = 7f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 10f;
    /// <summary>砲弾が当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    void Start()
    {
        // 右方向に飛ばす
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, m_lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            Instantiate(m_effectPrefab, transform.position, transform.rotation);
        }
    }
}
