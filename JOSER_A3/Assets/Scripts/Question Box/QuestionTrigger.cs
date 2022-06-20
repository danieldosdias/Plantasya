using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{

    /* -------------------- Explanation on the checkpoints -----------

        1- When the game starts, the program will load random questions from the database and inserted them in each checkpoint
        2- When a player gets to a checkpoint the question box is triggered to appear on the screen
        3 - The player must choose an answer by shooting a projectile to them
        4 - the user receives feedback on whether the answer is correct or not
        5- That will enable the player to continue through the level (a door will open after the player answers the question) 


    /* -------------------- Steps To Do   -----------------
     - Grab references for question box
     - Trigger question box when the player collides with the checkpoint
       The question will be on the screen until it gets answered
     - After the question is answered the user will received feedback and that can affect the total score of the level (if its the right answer it will
       increase the score)
     - Then the checkpoint number gets increased so it will pass to the next question

    */
    private static QuestionTrigger instance;

    private QuestionBoxManager questionBoxManager;

    // public GameObject questionBox;

    //private int numQuestion = 0;
    public int numQuestionsInLevel;
    private int numQuestion;

    public GameObject questionBox;

    // public GameObject doorToBeOpen;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance QuestionTrigger in the scene!");
        }
        instance = this;

    }

    public static QuestionTrigger GetInstance()
    {
        return instance;
    }


    public void Start()
    {
       /*  QuestionBoxManager.GetInstance().StartQuestionLoading();
        questionBoxManager = QuestionBoxManager.GetInstance(); */

        numQuestion = 0;
    }
    public void Update()
    {
        //TriggerQuestion();
    }

    // Se o jogador passar num checkpoint
  /*   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && questionBoxManager.waitingForAnswer == false)
        {
            //Question Box Appears
            Debug.Log("aparece question box");
            TriggerQuestion();
        }
    } */

    public void TriggerQuestion()
    {
        Debug.Log("entrou trigger question");

        if (numQuestion < numQuestionsInLevel)
        {

            QuestionBoxManager.GetInstance().DisplayNextQuestion(numQuestion);
            questionBox.SetActive(true);
            numQuestion++;

        }
        else
        {
            EndQuestions();
        }

        /* while (numQuestion < numTotalQuestions)
        {
            QuestionBoxManager.GetInstance().DisplayNextQuestion(numQuestion);
            numQuestion++;
        } */

        /*  foreach (Question q in questions)
         {
             Debug.Log("question : "+q.question);
         }

     }

     /*   private void Awake()
       {
           //Grab references for question box



       }

       private void OnTriggerEnter2D(Collider2D collision)
       {
           if (collision.tag == "Player")
           {
               if (collision.transform.position.x < transform.position.x) // if the player enters the room
               {
                   //Question Box Appears
               }
               else{
                   //Question Box is Hidden
               }
           }
       } */
    }


    void EndQuestions()
    {
        Debug.Log("End of Questions");
    }
}