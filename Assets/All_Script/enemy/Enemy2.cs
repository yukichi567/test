using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy�p��
public class Enemy2 : Enemy
{
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    // Start is called before the first frame update


    //Destroy���ɔ����G�t�F�N�g�ǉ�
    private void OnDestroy()
    {
        Instantiate(m_effectPrefab, transform.position, transform.rotation);
    }
}
