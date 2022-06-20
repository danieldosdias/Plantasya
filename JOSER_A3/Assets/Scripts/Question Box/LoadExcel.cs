using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    [Header("Num Questions")]
    public int numQuestionsLevel;
    public int numTotalQuestions;
    public Question blankQuestion;
    public List<Question> questions = new List<Question>();


    public void LoadQuestionData()
    {
        
        Debug.Log("Load Question Data");
        //Clear List of Questions
        questions.Clear();

        //Get ID's of new questions
        List<int> indexes = getQuestionsIndexes(numQuestionsLevel);

        //Read CSV FILES
        List<Dictionary<string, object>> data = CSVReader.Read("QuestionsPlantasya");
        for (int i = 0; i < data.Count; i++)
        {


            int questionID = int.Parse(data[i]["questionID"].ToString(), System.Globalization.NumberStyles.Integer);
            if (indexes.Contains(questionID))
            {
                string question = data[i]["question"].ToString();

                //string answers = data[i]["answers"].ToString();
                Dictionary<string, string> answers = new Dictionary<string, string>();
                for (int k = 1; k <= 3; k++)
                {
                    string[] answer_split = data[i]["answer" + k].ToString().Split("=");
                    string answer = answer_split[0];
                    string rightOrWrong = answer_split[1];
                    answers.Add(answer, rightOrWrong);
                }
                AddQuestion(questionID, question, answers);
            }

        }

        //RANDOMISE QUESTION ORDER
        questions.Shuffle();

        //Check randomized questions

        /*  Debug.Log("QUESTÕES");
         Debug.Log("-----------------------------------");
         foreach (Question q in questions)
         {
             Debug.Log(q.questionNumber);
         }
         Debug.Log("-----------------------------------");
  */
    }


    public void AddQuestion(int questionID, string question, Dictionary<string, string> answers)
    {
        Question newQuestion = new Question(blankQuestion);

        newQuestion.questionNumber = questionID;
        newQuestion.question = question;
        newQuestion.answers = answers;

        questions.Add(newQuestion);

    }

    public List<int> getQuestionsIndexes(int numberQuestionsInThisLevel)
    {
        System.Random rd = new System.Random();
        List<int> list = new List<int>();

        //carregar lista com o numero total de questões
        for (int i = 0; i < numTotalQuestions; i++)
        {
            list.Add(i);
        }

        //Fazer randomize dos numeros das perguntas
        List<int> randomized = list.OrderBy(item => rd.Next()).ToList();

        randomized.RemoveRange(0, numTotalQuestions - numberQuestionsInThisLevel);


        //Check randomized numbers
        /*  Debug.Log("-------------------- Randomize -------------------");
         foreach (int num in randomized)
         {
             Debug.Log(num);
         }
         Debug.Log("---------------------------------------");

  */

        return randomized;


    }


}
