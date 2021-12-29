using UnityEngine;          // �ޥ� Unity API (�ܮw - ��ƻP�\��)
using UnityEngine.Video;    // �ޥ� �v�� API

namespace KID.Practice
{
    // �׹��� ���O ���O�W�� : �~�����O
    // MonoBehaviour�GUnity �����O�A�n���b����W�@�w�n�~��
    // �~�ӫ�|�ɦ������O������
    // �b���O�H�Φ����W��K�[�T���׽u�|�K�[�K�n
    // �`�Φ����G��� Field�B�ݩ� Property (�ܼ�)�B��k Method�B�ƥ� Event
    /// <summary>
    /// KID 2021.0906
    /// �ĤT�H�ٱ��
    /// ���ʡB���D
    /// </summary>
    public class ThirdPersonController : MonoBehaviour
    {
        #region ��� Field
        // �x�s�C����ơA�Ҧp�G���ʳt�סB���D���׵���...
        // �`�Υ|�j�����G��� int�B�B�I�� float �B�r�� string�B���L�� bool
        // ���y�k�G�׹��� ������� ���W�� (���w �w�]��) ����
        // �׹����G
        // 1. ���} public  - ���\��L���O�s�� - ��ܦb�ݩʭ��O - �ݭn�վ㪺��Ƴ]�w�����}
        // 2. �p�H private - �T���L���O�s�� - ���æb�ݩʭ��O - �w�]��
        // �� Unity �H�ݩʭ��O��Ƭ��D
        // �� ��_�{���w�]�ȽЫ� ... > Reset
        // ����ݩ� Attribute�G���U�����
        // ����ݩʻy�k�G[�ݩʦW��(�ݩʭ�)]
        // Header ���D
        // Tooltip ���ܡG�ƹ����d�b���W�٤W�|��ܼu�X����
        // Range �d��G�i�ϥΦb�ƭ�������ƤW�A�Ҧp�Gint, float
        [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(1, 500)]
        public float speed = 10.5f;
        [Header("���D����"), Range(0, 1000)]
        public int jump = 100;
        [Header("�ˬd�a�����")]
        [Tooltip("�Ψ��ˬd����O�_�b�a���W")]
        public bool isGrounded;
        public Vector3 v3CheckGroudOffset;
        [Range(0, 3)]
        public float checkGroundRadius = 0.2f;
        [Header("�����ɮ�")]
        public AudioClip soundJump;
        public AudioClip soundGround;
        [Header("�ʵe�Ѽ�")]
        public string animatorParWalk = "�����}��";
        public string animatorParRun = "�]�B�}��";
        public string animatorParHurt = "����Ĳ�o";
        public string animatorParDead = "���`�}��";
        public string animatorParJump = "���DĲ�o";
        public string animatorParIsGrounded = "�O�_�b�a�O�W";
        [Header("���a�C������")]
        public GameObject playerObject;

        #region ���G�p�H
        private AudioSource aud;
        private Rigidbody rig;
        private Animator ani;
        #endregion

        #region Unity �������
        /** �m�� Unity �������
        // �C�� Color
        public Color color;
        public Color white = Color.white;                       // �����C��
        public Color yellow = Color.yellow;
        public Color color1 = new Color(0.5f, 0.5f, 0);         // �ۭq�C�� RGB
        public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);   // �ۭq�C�� RGBA

        // �y�� Vector 2 - 4
        public Vector2 v2;
        public Vector2 v2Right = Vector2.right;
        public Vector2 v2Left = Vector2.left;
        public Vector2 v2Up = Vector2.up;
        public Vector2 v2One = Vector2.one;
        public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
        public Vector3 v3 = new Vector3(1, 2, 3);
        public Vector3 v3Forward = Vector3.forward;
        public Vector4 v4 = new Vector4(1, 2, 3, 4);

        // ���� �C�|��� enum
        public KeyCode key;
        public KeyCode move = KeyCode.W;
        public KeyCode jump = KeyCode.Space;

        // �C����������G������w�w�]��
        // �s�� Project �M�פ������
        public AudioClip sound;     // ���� mp3, ogg, wav
        public VideoClip video;     // �v�� mp4,
        public Sprite sprite;       // �Ϥ� png, jpeg - ���䴩 gif
        public Texture2D texture2D; // 2D �Ϥ� png, jpeg
        public Material material;   // ����y
        [Header("����")]
        // ���� Component�G�ݩʭ��O�W�i���|��
        public Transform tra;
        public Animation aniOld;
        public Animator aniNew;
        public Light lig;             
        public Camera cam;

        // ���L�C
        // 1. ��ĳ���n�ϥΦ��W��
        // 2. �ϥιL�ɪ� API
        /**/
        #endregion

        #endregion

        #region �ݩ� Property
        /** �ݩʽm��
        // �ݩʤ��|��ܦb���O�W
        // �x�s��ơA�P���ۦP
        // �t���b��G�i�H�]�w�s���v�� Get Set
        // �ݩʻy�k�G�׹��� ������� �ݩʦW�� { ��; �s; }
        public int readAndWrite { get; set; }
        // ��Ū�ݩʡG�u����o get
        public int read { get; }
        // ��Ū�ݩʡG�z�L get �]�w�w�]�ȡA����r return ���Ǧ^��
        public int readValue
        {
            get
            {
                return 77;
            }
        }
        // �߼g�ݩʡG�T��A�����n�� get
        // public int write { set; }
        // value �����O���w����
        private int _hp;
        public int hp
        {
            get 
            { 
                return _hp; 
            }
            set
            {
                _hp = value;
            }
        }
        /**/
        /// <summary>
        /// ���D����
        /// </summary>
        // C# 7.0 �s���l �i�H�ϥ� Lambda => �B��l
        // �y�k�Gget => { �{���϶� } - ���i�ٲ��j�A��
        private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
        #endregion

        #region �m�ߤ�k Method
        /** �m�ߤ�k
        // �w�q�P��@�������{�����϶��A�\��
        // ��k�y�k�G�׹��� �Ǧ^������� ��k�W�� (�Ѽ�1, ...�Ѽ�N) { �{���϶� }
        // �`�ζǦ^�����G�L�Ǧ^ void - ����k�S���Ǧ^���
        // �榡�ơGCtrl + K D
        // �ۭq��k�G
        // �ۭq��k�ݭn�Q�I�s�~�|�����k�����{��
        // �W���C�⬰�H���� - �S���Q�I�s
        // �W���C�⬰�G���� - ���Q�I�s
        private void Test()
        {
            print("�ڬO�ۭq��k~");
        }

        private int ReturnJump()
        {
            return 999;
        }

        // �Ѽƻy�k�G������� �ѼƦW�� ���w �w�]��
        // ���w�]�Ȫ��Ѽƥi�H����J�޼ơA��񦡰Ѽ�
        // �� ��񦡰Ѽƥu���b () �k��
        private void Skill(int damage, string effect = "�ǹЯS��", string sound = "�ǹǹ�")
        {
            print("�Ѽƪ��� - �ˮ`�ȡG" + damage);
            print("�Ѽƪ��� - �ޯ�S�ġG" + effect);
            print("�Ѽƪ��� - ���ġG" + sound);
        }

        /* ���~�G���O�ѼƨS���b () �k��
        private void ErrorSkill(string effect = "�ǹЯS��", int damage)
        {

        }

        // ��ӲաG���ϥΰѼ�
        // ���C���@�P�X�R��
        private void Skill100()
        {
            print("�ˮ`�ȡG" + 100);
            print("�ޯ�S��");
        }

        private void Skill150()
        {
            print("�ˮ`�ȡG" + 150);
            print("�ޯ�S��");
        }

        private void Skill200()
        {
            print("�ˮ`�ȡG" + 200);
            print("�ޯ�S��");
        }

        // �� �D���n���ܭ��n
        // BMI = �魫 / ���� * ���� (����)
        /// <summary>
        /// �p�� BMI ��k
        /// </summary>
        /// <param name="weight">�魫�A��쬰����</param>
        /// <param name="height">�����A��쬰����</param>
        /// <param name="name">�W�١A���q�̪��W��</param>
        /// <returns>BMI ���G</returns>
        private float BMI(float weight, float height, string name = "����")
        {
            print(name + " �� BMI");

            return weight / (height * height);
        }
        */
        #endregion

        #region ��k Method
        // �P�| Ctrl + M O
        // �i�} Ctrl + M L
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="speedMove">���ʳt��</param>
        private void Move(float speedMove)
        {
            // �Ш��� Animator �ݩ� Apply Root Motion�G�Ŀ�ɨϥΰʵe�첾��T
            // ����.�[�t�� = �T���V�q - �[�t�ץΨӱ������T�Ӷb�V���B�ʳt��
            // �e�� * ��J�� * ���ʳt��
            // �ϥΫe�ᥪ�k�b�V�B�ʨåB�O���쥻���a�ߤޤO
            rig.velocity =
                Vector3.forward * MoveInput("Vertical") * speedMove +
                Vector3.right * MoveInput("Horizontal") * speedMove +
                Vector3.up * rig.velocity.y;
        }

        /// <summary>
        /// ���ʫ����J
        /// </summary>
        /// <param name="axisName">�n���o���b�V�W��</param>
        /// <returns>���ʫ����</returns>
        private float MoveInput(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        /// <summary>
        /// �ˬd�a�O
        /// </summary>
        /// <returns>�O�_�I��a�O</returns>
        private bool CheckGround()
        {
            // ���z.�л\�y��(�����I�A�b�|�A�ϼh)
            Collider[] hits = Physics.OverlapSphere(
                transform.position +
                transform.right * v3CheckGroudOffset.x +
                transform.up * v3CheckGroudOffset.y +
                transform.forward * v3CheckGroudOffset.z,
                checkGroundRadius, 1 << 3);

            //print("�y��I�쪺�Ĥ@�Ӫ���G" + hits[0].name);

            isGrounded = hits.Length > 0;

            // �Ǧ^ �I���}�C�ƶq > 0 - �u�n�I����w�ϼh����N�N��b�a���W
            return hits.Length > 0;
        }

        /// <summary>
        /// ���D
        /// </summary>
        private void Jump()
        {
            // print("�O�_�b�a���W�G" + CheckGround());

            // �åB &&
            // �p�G �b�a���W �åB ���U�ť��� �N ���D
            if (CheckGround() && keyJump)
            {
                // ����.�K�[���O(�����󪺤W�� * ���D)
                rig.AddForce(transform.up * jump);
            }
        }

        /// <summary>
        /// ��s�ʵe
        /// </summary>
        private void UpdateAnimation()
        {
            /** �m�߻P�����ʵe�����
            // �� �m��
            // �w�����G�G
            // ���U�e�Ϋ�� �N���L�ȳ]�� true
            // �S������ �N���L�ȳ]�� false
            // Input
            // if (��ܱ���)
            // !=�B== ����B��l (��ܱ���)

            // ���a���e�ΫᲾ�ʮ� true
            // �S�����U�e�Ϋ�� false
            // ������ ������ 0 �N�N�� true
            // ������ ���� 0 �N�N�� false

            // �S�����T���{���A�u������A�X���{��

            // �e�� ������ 0 �� ���k ������ 0 ���O����
            // || �Ϊ�
            */
            ani.SetBool(animatorParWalk, MoveInput("Vertical") != 0 || MoveInput("Horizontal") != 0);
            // �]�w�O�_�b�a�O�W �ʵe�Ѽ�
            ani.SetBool(animatorParIsGrounded, isGrounded);
            // �p�G ���U ���D�� �N �]�w���DĲ�o�Ѽ�
            // �P�_�� �u���@��ԭz(�u���@�Ӥ���) �i�H�ٲ� �j�A��
            if (keyJump) ani.SetTrigger(animatorParJump);
        }
        #endregion

        #region �ƥ� Event
        // �S�w�ɶ��I�|���檺��k�A�{�����J�f Start ���� Console Main
        // �}�l�ƥ�G�C���}�l�ɰ���@�� - �B�z��l�ơA���o��Ƶ���
        private void Start()
        {
            #region �m�ߩI�s��k
            /**
            print(BMI(61, 1.68f, "KID"));
            print(BMI(50, 1.5f));

            Skill100();
            Skill200();
            // �I�s���ѼƤ�k�ɡA������J�������޼�
            Skill(300);
            Skill(999, "�z���S��");
            // �ݨD�G�ˮ`�� 500�A�S�ĥιw�]�ȡA���Ĵ��� ������
            // ���h�ӿ�񦡰ѼƮɥi�ϥΫ��W�Ѽƻy�k�G�ѼƦW��: ��
            Skill(500, sound: "������");

            // �I�s�ۭq��k�y�k�G��k�W��()�F
            Test();
            Test();
            // �I�s���Ǧ^�Ȫ���k
            // 1. �ϰ��ܼƫ��w�Ǧ^�� - �ϰ��ܼƶȯ�b�����c (�j�A��) ���s��
            int j = ReturnJump();
            print("���D�ȡG" + j);
            // 2. �N�Ǧ^��k���Ȩϥ�
            print("���D�ȡA��ȨϥΡG" + (ReturnJump() + 1));
            */
            #endregion

            #region ��X��k
            /** ��X ��k
            print("���o�A�U�w~");

            Debug.Log("�@��T��");
            Debug.LogWarning("ĵ�i�T��");
            Debug.LogError("���~�T��");
            */
            #endregion

            #region �ݩʽm��
            /** �ݩʽm��
            // ���P�ݩ� ���o Get�B�]�w Set
            print("����� - ���ʳt�סG" + speed);
            print("�ݩʸ�� - Ū�g�ݩʡG" + readAndWrite);
            speed = 20.5f;
            readAndWrite = 90;
            print("�ק�᪺���");
            print("����� - ���ʳt�סG" + speed);
            print("�ݩʸ�� - Ū�g�ݩʡG" + readAndWrite);
            // ��Ū�ݩ�
            // read = 7;    // ��Ū�ݩʤ���]�w set
            print("��Ū�ݩʡG" + read);
            print("��Ū�ݩʡA���w�]�ȡG" + readValue);

            // �ݩʦs���m��
            print("HP�G" + hp);
            hp = 100;
            print("HP�G" + hp);
            */
            #endregion

            // �n���o�}�����C������i�H�ϥ�����r gameObject

            // ���o���󪺤覡
            // 1. �������W��.���o����(����(��������)) ��@ ��������;
            aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
            // 2. ���}���C������.���o����<�x��>();
            rig = gameObject.GetComponent<Rigidbody>();
            // 3. ���o����<�x��>();
            // ���O�i�H�ϥ��~�����O(�����O)�������A���}�ΫO�@ ���B�ݩʻP��k
            ani = GetComponent<Animator>();
        }

        // ��s�ƥ�G�@������� 60 ���A60 FPS - Frame Per Second
        // �B�z����ʹB�ʡA���ʪ���A��ť���a��J����
        private void Update()
        {
            Jump();
            UpdateAnimation();
        }

        // �T�w��s�ƥ�G�T�w 0.02 �����@�� - 50 FPS
        // �B�z���z�欰�A�Ҧp�GRigidbody API
        private void FixedUpdate()
        {
            Move(speed);
        }

        // ø�s�ϥܨƥ�G
        // �b Unity Editor ��ø�s�ϥܻ��U�}�o�A�o����|�۰�����
        private void OnDrawGizmos()
        {
            // 1. ���w�C��
            // 2. ø�s�ϧ�
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

            // transform �P���}���b�P���h�� Transform ����
            Gizmos.DrawSphere(
                transform.position +
                transform.right * v3CheckGroudOffset.x +
                transform.up * v3CheckGroudOffset.y +
                transform.forward * v3CheckGroudOffset.z,
                checkGroundRadius);
        }
        #endregion
    }
}
