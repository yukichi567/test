using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ə� (Crosshair) �𐧌䂷��R���|�[�l���g
/// �}�E�X�J�[�\���̈ʒu�ɏƏ����ړ�����
/// </summary>
public class Rock_Marker : MonoBehaviour
{
    public bool Marker_off = true;

    void Start()
    {
        // �}�E�X�J�[�\��������
        Cursor.visible = false;
    }

    void Update()
    {
        if (Marker_off == true)
        {
            // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
            // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;    // Z ���W���J�����Ɠ����ɂȂ��Ă���̂ŁA���Z�b�g����
            this.transform.position = mousePosition;
        }
    }
}