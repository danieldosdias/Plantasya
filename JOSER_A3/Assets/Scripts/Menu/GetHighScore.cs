using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHighScore : MonoBehaviour
{

    public TextMeshProUGUI scoreLastGame;



    // Start is called before the first frame update
    void Start()
    {
        /*  scoreManager = ScoreManager.GetInstance();
         if (scoreManager.CheckHigherScore() != null)
         {
             highScore.text = scoreManager.CheckHigherScore();
         } */
        //highScore = scoreManager.getins;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHigherScore();
    }
    public void CheckHigherScore()
    {
        //Caso score jogo anterior > high score
        if (int.Parse(scoreLastGame.text, System.Globalization.NumberStyles.AllowLeadingSign) > ScoreManager.highScoreValue)
        {
            Debug.Log("mudou score");
            ScoreManager.highScoreValue = int.Parse(scoreLastGame.text, System.Globalization.NumberStyles.AllowLeadingSign);
        }
    }


}
