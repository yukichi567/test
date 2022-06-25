using UnityEngine;

/// <summary>
/// 砲台 (Canon) を制御するコンポーネント
/// </summary>
public class CanonController : MonoBehaviour
{
    /// <summary>砲弾として生成するプレハブ</summary>
    [SerializeField] GameObject m_shellPrefab = default;
    /// <summary>砲口を指定する</summary>
    [SerializeField] Transform m_muzzle = default;
    //照準のマーク
    [SerializeField] Transform m_crosshair;
    AudioSource m_audio = default;
    /// <summary>生成する間隔（秒）</summary>
    [SerializeField] float m_interval = 1f;
    float timer = 1f;
    //爆弾関係
    /// <summary>一定時間おきに生成する GameObject の元となるプレハブ</summary>
    [SerializeField] GameObject m_BomPrefab = default;
/// <summary>Bom生成する間隔（秒）</summary>
    [SerializeField] float m_interval2 = 5f;
    float Bomtimer = 1f;

    /// <summary>砲弾が当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        timer += Time.deltaTime;
        Bomtimer += Time.deltaTime;


        Vector2 dir = m_crosshair.position - transform.position;
        transform.up = dir;


        if (Input.GetButton("Fire1") && timer > m_interval)
        {

            Instantiate(m_shellPrefab, m_muzzle.position, this.transform.rotation);
            timer = 0;
        }

        if (Input.GetMouseButtonDown(1) && Bomtimer > m_interval2)
        {

            Instantiate(m_BomPrefab, m_muzzle.position, this.transform.rotation);
            Bomtimer = 0;
        }
        // 「経過時間」が「生成する間隔」を超えたら
        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }

    }


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
    
}

