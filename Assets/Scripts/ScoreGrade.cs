// Menerapkan polymorphism untuk score grade (perfect,good,hit/normal)
using UnityEngine;

public abstract class ScoreGrade : MonoBehaviour
{
    public abstract string GradeName { get; }
    public static float MaxTimingError { get; } = 0.2f;
    public abstract int Score { get; }
    public static bool IsInRange(float timingError)
    {
        return timingError <= MaxTimingError;
    }

    // Reward the player for this grade
    public virtual void Reward(GameManager gameManager)
    {
        // Increase score based on the grade
        gameManager.AddScore(Score);  // Add score to game manager
        gameManager.UpdateScoreText();  // Update score text
    }

    // Update the score text based on the current score
    public virtual void UpdateScoreText(GameManager gameManager)
    {
        gameManager.scoreText.text = "Score: " + gameManager.currentScore.ToString();
    }
}
public class PerfectGrade : ScoreGrade
{
    public override string GradeName => "Perfect";
    public new static float MaxTimingError => 0.1f;
    public override int Score => 150;
    public override void Reward(GameManager gameManager)
    {
        base.Reward(gameManager);
        gameManager.PerfectHit();
    }
    public new static bool IsInRange(float timingError)
    {
        return timingError <= MaxTimingError;
    }

}
public class GoodGrade : ScoreGrade
{
    public override string GradeName => "Good";
    public new static float MaxTimingError => 0.15f;
    public override int Score => 125;
    public override void Reward(GameManager gameManager)
    {
        base.Reward(gameManager);
        gameManager.GoodHit();
    }
    public new static bool IsInRange(float timingError)
    {
        return timingError <= MaxTimingError;
    }
}
public class HitGrade : ScoreGrade
{
    public override string GradeName => "Hit";
    public override int Score => 100;
    public override void Reward(GameManager gameManager)
    {
        base.Reward(gameManager);
        gameManager.NormalHit();
    }
}
