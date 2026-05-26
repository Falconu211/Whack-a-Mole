using TMPro;
using UnityEngine;

public class EndTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] GameObject EndGameText;

    public float timeLimit = 60.0f;

    public bool gameEnd = false;

    private string timeText;


    private void Start()
    {
        EndGameText.SetActive(false);
        timeText = "Last Time:";
        TimerText.text = timeText += Mathf.RoundToInt(timeLimit);
    }

    private void Update()
    {
        if (!gameEnd)
        {
            timeLimit -= Time.deltaTime;

            if (timeLimit < 0)
            {
                gameEnd = true;
                EndGameText.SetActive(true);
            }

            timeText = "Last Time:";
            TimerText.text = timeText += Mathf.RoundToInt(timeLimit);
        } 
    }
}
