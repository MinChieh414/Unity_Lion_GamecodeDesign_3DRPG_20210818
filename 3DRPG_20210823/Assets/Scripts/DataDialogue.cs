using UnityEngine;

namespace KID.Dialogue
{
    /// <summary>
    /// ��ܨt�Ϊ����
    /// NPC �n��ܪ��T�Ӷ��q���e
    /// �����ȫe�B���ȶi�椤�B��������
    /// </summary>
    // ScriptableObject �~�Ӧ����O�|�ܦ��}���ƪ���
    // �i�N���}����Ʒ�����O�s�b�M�� Project��
    // CreateAssetMenu ���O�ݩʡG�������O�إ߱M�פ����
    // menuName ���W�١A�i�� / ���h
    // fileName �ɮצW��
    [CreateAssetMenu(menuName = "KID/��ܸ��", fileName = "NPC ��ܸ��")]
    public class DataDialogue : ScriptableObject
    {
        [Header("��ܪ̦W��")]
        public string nameDialogue;
        // �}�C�G�O�s�ۦP������������c
        // TextArea �r����ݩʡA�i�]�w���
        [Header("���ȫe��ܤ��e"), TextArea(2, 7)]
        public string[] beforeMission;
        [Header("���ȶi�椤��ܤ��e"), TextArea(2, 7)]
        public string[] missionning;
        [Header("���ȧ�����ܤ��e"), TextArea(2, 7)]
        public string[] afterMission;
        [Header("���ȻݨD�ƶq"), Range(0, 100)]
        public int countNeed;
        // �ϥΦC�|�G
        // �y�k�G�׹��� �C�|�W�� �۩w�q���W�١F
        [Header("NPC ���Ȫ��A")]
        public StateNPCMission stateNPCMission = StateNPCMission.BeforeMission;
    }
}
