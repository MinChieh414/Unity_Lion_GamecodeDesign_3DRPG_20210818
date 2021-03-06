using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace KID.Dialogue
{
    /// <summary>
    /// 對話系統
    /// 顯示對話框、對話內容打字效果
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 欄位
        [Header("對話系統需要的介面物件")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("對話間隔"), Range(0, 10)]
        public float dialogueInterval = 0.3f;
        [Header("對話按鍵")]
        public KeyCode dialogueKey = KeyCode.Space;
        [Header("打字事件")]
        public UnityEvent onType;
        #endregion

        /// <summary>
        /// 開始對話
        /// </summary>
        public void Dialogue(DataDialogue data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());          // 啟動協同程序
            StartCoroutine(ShowDialogueContent(data));
        }

        /// <summary>
        /// 停止對話：關閉對話功能，介面淡出
        /// </summary>
        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }

        /// <summary>
        /// 切換對話框群組
        /// </summary>
        /// <param name="fadeIn">是否淡入：true 淡入，false 淡出</param>
        private IEnumerator SwitchDialogueGroup(bool fadeIn = true)
        {
            // 三元運算子
            // 語法：布林值 ? true 結果 : false 結果 ;
            // 透過布林值決定要增加得值，true 增加 0.1，false 增加 -0.1
            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)                    // 迴圈指定執行次數
            {
                groupDialogue.alpha += increase;            // 群組元件 透明度 遞增
                yield return new WaitForSeconds(0.01f);     // 等待時間
            }
        }

        /// <summary>
        /// 顯示對話內容
        /// </summary>
        /// <param name="data">對話資料</param>
        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textName.text = "";                     // 清除 對話者
            textName.text = data.nameDialogue;      // 更新 對話者

            #region 處理狀態與對話資料
            string[] dialogueContents = { };        // 儲存 對話內容 為 空值

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

            // 遍尋每一段對話
            for (int j = 0; j < dialogueContents.Length; j++)
            {
                textContent.text = "";          // 清除 對話內容
                goTriangle.SetActive(false);    // 隱藏 提示圖示

                // 遍尋對話每一個字
                for (int i = 0; i < dialogueContents[j].Length; i++)
                {
                    onType.Invoke();                                            // 執行事件
                    textContent.text += dialogueContents[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }

                goTriangle.SetActive(true);     // 顯示 提示圖示

                // 持續等待 輸入 對話按鍵 null 等待一個影格的時間
                while (!Input.GetKeyDown(dialogueKey)) yield return null;
            }

            StartCoroutine(SwitchDialogueGroup(false));     // 淡出
        }
    }
}
