using UnityEngine;

/// <summary>
/// �m�߫D�R�A API
/// </summary>
public class APINonStaticPractice : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer sprSquare;
    public Camera camMain;
    public SpriteRenderer sprBird;
    public Transform bird1;
    public Rigidbody2D bird2;

    private void Start()
    {
        #region �D�R�A�ݩ�
        print("���o��v�����`�סG" + cam.depth);
        print("��ιϤ����C��G" + sprSquare.color);

        camMain.backgroundColor = Random.ColorHSV();
        sprBird.flipY = true;
        #endregion
    }

    private void Update()
    {
        #region �D�R�A��k
        bird1.Rotate(0, 0, 3);
        bird2.AddForce(new Vector2(0, 10));
        #endregion
    }
}
