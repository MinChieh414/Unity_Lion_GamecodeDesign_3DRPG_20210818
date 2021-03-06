using UnityEngine;

namespace KID.Practice
{
    /// <summary>
    /// 認識迴圈
    /// while、do while、for、foreach
    /// </summary>
    public class LearnLoop : MonoBehaviour
    {
        private void Start()
        {
            // 迴圈 Loop
            // 重複執行程式內容
            // 需求：輸出數字 1 - 5
            print(1);
            print(2);
            print(3);
            print(4);
            print(5);

            // while 迴圈
            // 語法：if (布林值) { 程式內容 }     - 布林值為 true 執行一次
            // 語法：while (布林值) { 程式內容 }  - 布林值為 true 持續執行 ※
            int a = 1;

            while (a < 6)
            {
                print("迴圈 while：" + a);
                a++;
            }

            // for 迴圈
            // 語法：for(初始值；條件(布林值)；迴圈結束執行程式) { 程式內容 }
            for (int i = 1; i < 6; i++)
            {
                print("迴圈 for：" + i);
            }
        }
    }
}
