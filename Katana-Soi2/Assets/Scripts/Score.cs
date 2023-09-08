using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int scoreAmount)
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        currentScore = 0;
    }
}
