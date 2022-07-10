using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    // Start is called before the first frame update

    private void OnDestroy()
    {
        Instantiate(m_effectPrefab, transform.position, transform.rotation);
    }
}
