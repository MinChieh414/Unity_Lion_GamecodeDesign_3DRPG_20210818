using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���Ĩt��
    /// ���ѵ��f���n���񭵮Ī�����
    /// </summary>
    // ���M�Τ���ɡ� �|�n�D����G�|�۰ʲK�[���w������
    // [�n�D����(����(����1), ����(����2), ...)]
    [RequireComponent(typeof(AudioSource))]
    public class AudioSystem : MonoBehaviour
    {
        #region ���
        private AudioSource aud;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }
        #endregion

        #region ��k�G���}
        /// <summary>
        /// �H���`���q���񭵮�
        /// </summary>
        /// <param name="sound">����</param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }

        /// <summary>
        /// ���񭵮ĨåB�H�����q�A0.7 ~ 1.2
        /// </summary>
        /// <param name="sound">����</param>
        public void PlaySoundRandomVolume(AudioClip sound)
        {
            float volume = Random.Range(0.7f, 1.2f);
            aud.PlayOneShot(sound, volume);
        }
        #endregion
    }
}
