using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDDOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<NewDDOL>().Length > 1)
        {
            // �d�����Ȃ��悤�ɁA���ɂ��鎞�͎������g��j������
            Destroy(this.gameObject);
        }
        else
        {
            // �����������Ȃ����́A������ DontDestroyOnLoad �ɓo�^����
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
