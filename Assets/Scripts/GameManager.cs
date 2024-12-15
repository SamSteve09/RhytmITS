using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool hasStarted;
    public BeatScroller beatScroller;

    public static GameManager instance;

    public Text scoreText;
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;
    public float percentHit;
    public GameObject resultScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public int currentScore;

    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        totalNotes = Object.FindObjectsByType<Note>(FindObjectsSortMode.None).Length;
    }

    void Update()
    {
        if (Input.anyKeyDown && !hasStarted)
        {
            hasStarted = true;
            beatScroller.hasStarted = true;
            music.Play();
        }
        else if (hasStarted && !music.isPlaying && !resultScreen.activeInHierarchy)
        {
            resultScreen.SetActive(true);

            normalsText.text = normalHits.ToString();
            goodsText.text = goodHits.ToString();
            perfectsText.text = perfectHits.ToString();
            missesText.text = missedHits.ToString();

            percentHit = (normalHits * 0.6f + goodHits * 0.8f + perfectHits) / totalNotes * 100f;

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
            else if(perfectHits > 20)
            {
                rankVal = "F";
            }

            rankText.text = rankVal;
            finalScoreText.text = currentScore.ToString();
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;  // Add score to current score
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();  // Update score text
    }

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
    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
