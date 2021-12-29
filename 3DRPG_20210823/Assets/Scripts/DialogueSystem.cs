using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace KID.Dialogue
{
    /// <summary>
    /// ��ܨt��
    /// ��ܹ�ܮءB��ܤ��e���r�ĪG
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region ���
        [Header("��ܨt�λݭn����������")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("��ܶ��j"), Range(0, 10)]
        public float dialogueInterval = 0.3f;
        [Header("��ܫ���")]
        public KeyCode dialogueKey = KeyCode.Space;
        [Header("���r�ƥ�")]
        public UnityEvent onType;
        #endregion

        /// <summary>
        /// �}�l���
        /// </summary>
        public void Dialogue(DataDialogue data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());          // �Ұʨ�P�{��
            StartCoroutine(ShowDialogueContent(data));
        }

        /// <summary>
        /// �����ܡG������ܥ\��A�����H�X
        /// </summary>
        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }

        /// <summary>
        /// ������ܮظs��
        /// </summary>
        /// <param name="fadeIn">�O�_�H�J�Gtrue �H�J�Afalse �H�X</param>
        private IEnumerator SwitchDialogueGroup(bool fadeIn = true)
        {
            // �T���B��l
            // �y�k�G���L�� ? true ���G : false ���G ;
            // �z�L���L�ȨM�w�n�W�[�o�ȡAtrue �W�[ 0.1�Afalse �W�[ -0.1
            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)                    // �j����w���榸��
            {
                groupDialogue.alpha += increase;            // �s�դ��� �z���� ���W
                yield return new WaitForSeconds(0.01f);     // ���ݮɶ�
            }
        }

        /// <summary>
        /// ��ܹ�ܤ��e
        /// </summary>
        /// <param name="data">��ܸ��</param>
        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textName.text = "";                     // �M�� ��ܪ�
            textName.text = data.nameDialogue;      // ��s ��ܪ�

            #region �B�z���A�P��ܸ��
            string[] dialogueContents = { };        // �x�s ��ܤ��e �� �ŭ�

            switch (data.stateNPCMission)
            {
                case StateNPCMission.BeforeMission:
                    dialogueContents = data.beforeMission;
                    break;
                case StateNPCMission.Missionning:
                    dialogueContents = data.missionning;
                    break;
                case StateNPCMission.AfterMission:
                    dialogueContents = data.afterMission;
                    break;
            }
            #endregion

            // �M�M�C�@�q���
            for (int j = 0; j < dialogueContents.Length; j++)
            {
                textContent.text = "";          // �M�� ��ܤ��e
                goTriangle.SetActive(false);    // ���� ���ܹϥ�

                // �M�M��ܨC�@�Ӧr
                for (int i = 0; i < dialogueContents[j].Length; i++)
                {
                    onType.Invoke();                                            // ����ƥ�
                    textContent.text += dialogueContents[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }

                goTriangle.SetActive(true);     // ��� ���ܹϥ�

                // ���򵥫� ��J ��ܫ��� null ���ݤ@�Ӽv�檺�ɶ�
                while (!Input.GetKeyDown(dialogueKey)) yield return null;
            }

            StartCoroutine(SwitchDialogueGroup(false));     // �H�X
        }
    }
}
