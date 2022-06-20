using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public static int highScoreValue = 0;



    public static ScoreManager Instance;

    // public TextMeshProUGUI scoreLastGame;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public static ScoreManager GetInstance()
    {
        return Instance;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckHigherScore();
        highScore.text = highScoreValue.ToString();
    }

    public void GameOver()
    {
    }


}
