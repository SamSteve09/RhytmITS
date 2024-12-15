using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text percentHitText;
    public Text normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public int currentScore;
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;
    public float percentHit;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        totalNotes = 0;
        normalHits = 0;
        goodHits = 0;
        perfectHits = 0;
        missedHits = 0;
    }

    // Add score based on the grade
    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreText();
    }

    // Update the score text UI
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Method to calculate and display the ranking
    public void CalculateAndDisplayStats(float totalNotes)
    {
        percentHit = ((normalHits * 0.5f) + (goodHits * 0.75f) + perfectHits) / totalNotes * 100f;
        percentHitText.text = percentHit.ToString("F1") + "%";

        string rankVal = "F";
        if (percentHit > 90)
        {
            rankVal = "S";
        }
        else if (percentHit > 80)
        {
            rankVal = "A";
        }
        else if (percentHit > 70)
        {
            rankVal = "B";
        }
        else if (percentHit > 60)
        {
            rankVal = "C";
        }
        else if (percentHit > 40)
        {
            rankVal = "D";
        }
        else if (percentHit > 20)
        {
            rankVal = "E";
        }

        rankText.text = rankVal;
        finalScoreText.text = currentScore.ToString();

        normalsText.text = normalHits.ToString();
        goodsText.text = goodHits.ToString();
        perfectsText.text = perfectHits.ToString();
        missesText.text = missedHits.ToString();
    }

    // Methods to increment hit counts
    public void NormalHit()
    {
        normalHits++;
    }

    public void GoodHit()
    {
        goodHits++;
    }

    public void PerfectHit()
    {
        perfectHits++;
    }

    public void NoteMiss()
    {
        missedHits++;
    }
}
