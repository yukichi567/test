using UnityEngine;

/// <summary>
/// �����G�t�F�N�g�𐧌䂷��R���|�[�l���g
/// </summary>
public class Crasheffect : MonoBehaviour
{
    /// <summary>�������ԁi�b�j�B���̎��Ԃ��o�߂�����G�t�F�N�g��j������</summary>
    [SerializeField] float m_lifetime = 0.5f;

    void Start()
    {
        // Destroy �֐��̑������Ɂu���b��ɔj�����邩�v���w��ł���
        Destroy(this.gameObject, m_lifetime);
    }
}
