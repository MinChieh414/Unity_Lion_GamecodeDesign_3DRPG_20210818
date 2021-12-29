using UnityEngine;

/// <summary>
/// �R�A�ݩʻP��k API �Ұ�m��
/// </summary>
public class APIStaticPractice : MonoBehaviour
{
    private void Start()
    {
        print("�`�@���X�[��v���G" + Camera.allCamerasCount);    // 1
        print("2D ���O�G" + Physics2D.gravity);                 // 0, -9.8
        print("��P�v�G" + Mathf.PI);                           // 3.14159

        Physics2D.gravity = new Vector2(0, -20);
        Time.timeScale = 0.5f;
        print("9.999 �h���p�I���G�G" + Mathf.Round(9.999f));    // 10

        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        print("a b ���I���Z���G" + Vector3.Distance(a, b));

        Application.OpenURL("https://unity.com/");
    }

    private void Update()
    {
        print("�O�_��J���N��G" + Input.anyKey);
        print("�ɶ��G" + Time.time);
        print("�O�_���U�ť���G" + Input.GetKeyDown(KeyCode.Space));
    }
}
