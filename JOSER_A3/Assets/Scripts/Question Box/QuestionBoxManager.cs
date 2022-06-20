using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionBoxManager : MonoBehaviour
{

    private static QuestionBoxManager instance;
    //    private List<Question> questions = new List<Question>();

    [Header("Question Box")]
    public GameObject questionBox;

    // num of questions
    [Header("Questions in Level")]
    public int numQuestionsInLevel;


    [Header("Num Questions Database ")]


    /*  Dictionary<string, Dictionary<string, Dictionary<string, string>>> questions = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();  */

    [Header("Question UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI answer1;
    [SerializeField] private TextMeshProUGUI answer2;
    [SerializeField] private TextMeshProUGUI answer3;

    // GLOBAL VARIABLE  
    public List<Question> questions = new List<Question>();

    public bool waitingForAnswer = false;

    LoadExcel loadExcelScript;

    public TextMeshProUGUI scoreText;
    public int score;
    public GameObject responseFeedbackRight;
    public GameObject responseFeedbackWrong;

   // public GameObject doorToBeOpen;
    public GameObject[] doorsToBeOpen;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance QuestionBoxManager in the scene!");
        }
        instance = this;

        GameObject DatabaseManager = GameObject.Find("DatabaseManager");
        loadExcelScript = DatabaseManager.GetComponent<LoadExcel>();

        //Score initializes with value ZERO
        score = 0;

        //Load Questions
        StartQuestionLoading();
    }

    public static QuestionBoxManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
    }

    // When the player gets to a checkpoint
    public void StartQuestionLoading()
    {
        // Load the array with questions from the DataBase - carregar array de questões
        Debug.Log("vai carregar array...");
        //List<Question> list = loadExcelScript.LoadQuestionData();
        loadExcelScript.LoadQuestionData();

        GameObject databaseManager = GameObject.Find("DatabaseManager");
        LoadExcel loadExcel = databaseManager.GetComponent<LoadExcel>();
        questions = loadExcel.questions;


        /* Debug.Log("questões");
        foreach (Question q in questions)
        {
            Debug.Log("question: " + q);
        }
        Debug.Log("----- carregou array ----"); */

        //List<Question> questions = loadExcelScript.LoadQuestionData();
    }


    public void DisplayNextQuestion(int numQuestion)
    {

        waitingForAnswer = true;
        Debug.Log("Display question: " + questions[numQuestion].question + " --------");
        questionText.text = questions[numQuestion].question;

        Dictionary<string, string> answers = questions[numQuestion].answers;

        List<string> keyList = new List<string>(answers.Keys);

        //Dictionary<string, string>.KeyCollection keys = answersText.Keys;

        answer1.text = "1- " + keyList[0];
        answer2.text = "2- " + keyList[1];
        answer3.text = "3- " + keyList[2];

        //answerTheQuestion(answers);

        StartCoroutine(WaitForAnswer(answers, numQuestion));
    }

    IEnumerator WaitForAnswer(Dictionary<string, string> answers, int numQuestion)
    {
        List<string> valueList = new List<string>(answers.Values);
        for (; ; )
        {


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (valueList[0].Trim().Equals("Right") || valueList[0].Trim().Equals("right"))
                {
                    Debug.Log("Correta!");
                    score += 10;
                    scoreText.text = score.ToString();

                    //Aparece feedback positivo
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackRight));


                }
                else
                {
                    Debug.Log("Incorreta!");
                    score -= 10;
                    scoreText.text = score.ToString();
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackWrong));

                }
                waitingForAnswer = false;
                break;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (valueList[1].Trim().Equals("Right") || valueList[1].Trim().Equals("right"))
                {
                    Debug.Log("Correta!");
                    score += 10;
                    scoreText.text = score.ToString();
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackRight));
                }
                else
                {
                    Debug.Log("Incorreta!");
                    score -= 10;
                    scoreText.text = score.ToString();
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackWrong));

                }
                waitingForAnswer = false;
                break;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (valueList[2].Trim().Equals("Right") || valueList[2].Trim().Equals("right"))
                {
                    Debug.Log("Correta!");
                    score += 10;
                    scoreText.text = score.ToString();
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackRight));
                }
                else
                {
                    Debug.Log("Incorreta!");
                    score -= 10;
                    scoreText.text = score.ToString();
                    StartCoroutine(DisableAfter3Seconds(responseFeedbackWrong));
                }
                waitingForAnswer = false;
                break;
            }



            /*   } */
            //Debug.Log("Finished waiting for user input");
            yield return null;
        }
        questionBox.SetActive(false);
        //doorToBeOpen.SetActive(false);

        doorsToBeOpen[numQuestion].SetActive(false);

        //Question.text = "";
        //Answer.text = "";
    }

    IEnumerator DisableAfter3Seconds(GameObject gameObject)
    {

        gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        gameObject.SetActive(false);

    }

    void EndQuestions()
    {
        Debug.Log("End of Questions");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
