using UnityEngine;

/// <summary>
/// �{�� API�G�R�A Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        #region �R�A�ݩ�
        // �P�D�R�A�t��
        // 1. ���ݭn���骫��
        // 2. ���ݭn���o���骫��
        // ���o Get
        // �y�k:
        // ���O�W��.�R�A�ݩ�
        float r = Random.value;
        print("���o�R�A�ݩʡA�H���ȡG" + r);

        // �]�w Set
        // �y�k�G
        // ���O�W��.�R�A�ݩ� ���w �ȡF
        // �� �u�n�ݨ� Read Only �N����]�w
        Cursor.visible = false;
        // Random.value = 99.9f; // ��Ū�ݩʤ���]�w
        #endregion

        #region �R�A��k
        // �I�s�A�ѼơB�Ǧ^
        // ñ���G�ѼơB�Ǧ^
        // �y�k�G
        // ���O�W��.�R�A��k(�����޼�)
        float range = Random.Range(10.5f, 20.9f);
        print("�H���d�� 10.5 ~ 20.9�G" + range);

        // �� API �����ܭ��n�G�ϥξ�Ʈɤ��]�t�̤j��
        int rangeInt = Random.Range(1, 3);
        print("����H���d�� 1 ~ 3�G" + rangeInt);
        #endregion
    }

    private void Update()
    {
        #region �R�A�ݩ�
        // print("�g�L�h�[�G" + Time.timeSinceLevelLoad);
        #endregion

        #region �R�A��k
        float h = Input.GetAxis("Horizontal");
        print("�����ȡG" + h);
        #endregion
    }
}
