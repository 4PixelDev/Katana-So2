using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //currentScore = 0;
    }

    public void AddScore(int scoreAmount)
    {
        currentScore++;
        scoreText.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // we'v beatn the highest score, congrats
            PlayerPrefs.SetInt("HighScore", currentScore);
            HighScore.text = currentScore.ToString();
        }


    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        HighScore.text = "0";
    }
}
