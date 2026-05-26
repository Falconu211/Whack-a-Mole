using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    public int score = 0;
    string scoreText;

    private void Start()
    {
        scoreText = "Score:";
        ScoreText.text = scoreText += score;
    }

    public void SetScore(int addPoint)
    {
        score += addPoint;

        scoreText = "Score:";
        ScoreText.text = scoreText += score;
    }
}
