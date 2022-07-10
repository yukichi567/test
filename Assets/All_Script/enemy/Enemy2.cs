using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy継承
public class Enemy2 : Enemy
{
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    // Start is called before the first frame update


    //Destroy時に爆発エフェクト追加
    private void OnDestroy()
    {
        Instantiate(m_effectPrefab, transform.position, transform.rotation);
    }
}
