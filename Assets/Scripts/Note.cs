using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool hasMissed = false;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    // Grade assigned dynamically or based on timing
    private ScoreGrade grade;

    void Start()
    {

        //grade = new HitGrade();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                // Timing error is based on note's position (y-axis)
                float timingError = Mathf.Abs(transform.position.y);
                if (PerfectGrade.IsInRange(timingError))  // Perfect timing
                {
                    grade = gameObject.AddComponent<PerfectGrade>();
                }
                else if (GoodGrade.IsInRange(timingError))
                {
                    grade = gameObject.AddComponent<GoodGrade>();
                }
                else  // Hit timing (out of good/perfect range)
                {
                    grade = gameObject.AddComponent<HitGrade>();
                }

                grade.Reward(GameManager.instance);  // Reward the player
                Instantiate(GetEffectForGrade(grade), transform.position, Quaternion.identity);  // Spawn appropriate effect
                //Instantiate(perfectEffect, transform.position, Quaternion.identity);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator") && gameObject.activeSelf && hasMissed == false)
        {
            canBePressed = false;
            hasMissed = true;
            GameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);  // Miss effect
        }
    }

    // Return the appropriate effect for the grade
    private GameObject GetEffectForGrade(ScoreGrade grade)
    {

        if (grade is PerfectGrade)
        {
            return perfectEffect;
        }
        else if (grade is GoodGrade)
        {
            return goodEffect;
        }
        else
        {
            return hitEffect;
        }
    }
}
