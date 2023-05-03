using TMPro;
using Ultilites;
using UnityEngine;

namespace System
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private float countdownTime = 600f; // thời gian đếm ngược từ 10 phút
        public float currentTime => countdownTime; // thời gian hiện tại

        private void Update()
        {
            /*float t = Time.time - startTime;

        int minutes = (int)t / 60;
        int seconds = (int)t % 60;
        
        timerText.text = $"{minutes:00}:{seconds:00}";*/
            CountDown();
        }

        private void CountDown()
        {
            // giảm giá trị của biến đếm ngược mỗi frame
            countdownTime = Mathf.Max(countdownTime - Time.deltaTime, 0f);

            // hiển thị đồng hồ đếm ngược
            int minutes = Mathf.FloorToInt(countdownTime / 60f);
            int seconds = Mathf.FloorToInt(countdownTime % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";

            // kiểm tra nếu thời gian đếm ngược đã đạt tới 0
            if (countdownTime <= 0f)
            {
                Debug.Log("Time's up!");
                // xử lý logic khi thời gian kết thúc
            }
        }
        
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }
    }
}