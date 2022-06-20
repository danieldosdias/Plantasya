using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    /*    public int questionNumber;
       [TextArea(1, 3)]
       public string question;
       [TextArea(2, 6)]
       public List<string> answers;
       public int idRightAnswer;
    */
    /*  Dictionary<string, Dictionary<string, Dictionary<string, string>>> questions = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
  */

    public int questionNumber;
    [TextArea(1, 3)]
    public string question;
    [TextArea(2, 6)]
    public Dictionary<string, string> answers;



    public Question(int questionNumberInit, string questionInit, Dictionary<string, string> answersInit)
    {
        questionNumber = questionNumberInit;
        question = questionInit;
        answers = answersInit;
    }

    public Question(Question q)
    {
        questionNumber = q.questionNumber;
        question = q.question;
        answers = q.answers;
    }

}
