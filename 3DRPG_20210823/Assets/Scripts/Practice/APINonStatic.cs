using UnityEngine;

/// <summary>
/// �{�� API�G�D�R�A Non Static
/// </summary>
public class APINonStatic : MonoBehaviour
{
    public Transform tra1;  // �׹��� �n�s���D�R�A�����O ���W��
    public Camera cam;
    public Light lig;

    private void Start()
    {
        #region �D�R�A�ݩ�
        // �P�R�A�t��
        // 1. �ݭn���骫��
        // 2. ���o���骫�� - �w�q���ñN�n�s��������s�J���
        // 3. �C������B���󥲶��s�b������
        // ���o Get
        // �y�k�G���W��.�D�R�A�ݩ�
        print("��v�����y�СG" + tra1.position);
        print("��v�����`�סG" + cam.depth);

        // �]�w Set
        // �y�k�G���W��.�D�R�A�ݩ� ���w �ȡF
        tra1.position = new Vector3(99, 99, 99);
        cam.depth = 7;
        #endregion

        #region �D�R�A��k
        // �I�s
        // �y�k�G
        // ���W��.�D�R�A��k�W��(�����޼�)�F
        lig.Reset();
        #endregion
    }
}
