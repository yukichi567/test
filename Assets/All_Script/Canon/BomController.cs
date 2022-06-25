using UnityEngine;

/// <summary>
/// �e�ۂ𐧌䂷��R���|�[�l���g
/// </summary>
public class BomController : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float m_initialSpeed = 7f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float m_lifeTime = 10f;
    /// <summary>�C�e�������������ɕ\�������G�t�F�N�g</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    void Start()
    {
        // �E�����ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
        // �������Ԃ��o�߂����玩�����g��j������
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
