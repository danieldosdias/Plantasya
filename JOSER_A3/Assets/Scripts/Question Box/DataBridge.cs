using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class DataBridge : MonoBehaviour
{
    //private string DATA_URL = "https://plantasya-9db71-default-rtdb.europe-west1.firebasedatabase.app/";

    private DatabaseReference databaseReference;

    private string userID;
    // Start is called before the first frame update
    void Start()
    {
        //Firebase.FirebaseApp.DefaultInstance.Options.DatabaseUrl = "asd";

        userID = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

    }



    public IEnumerator GetQuestion(Action<string> onCallback)
    {
        var question = databaseReference.Child("Questions").Child("Question1").Child("Question").GetValueAsync();
        /*  var questionref = FirebaseDatabase.DefaultInstance.GetReference("Questions");

         questionref.OrderByValue() */

        yield return new WaitUntil(predicate: () => question.IsCompleted);

        /*   FirebaseDatabase.DefaultInstance
        .GetReference("Questions")
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log("erro");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task..Result;
                List<string> q= new List<string>();
                foreach (DataSnapshot s in task.Result)
                {
                    Debug.Log(s);
                    q.Add(s.Key);
                }
                    onCallback.Invoke(q);

                Debug.Log(snapshot);
            }
            return;
        });
          return null; */

        if (question != null)
        {
            DataSnapshot snapshot = question.Result;
            onCallback.Invoke(snapshot.Value.ToString());
            Debug.Log("resultado:" + snapshot.Value.ToString());
        }
    }

    public void getQuestionInfo()
    {
        StartCoroutine(GetQuestion((string quest) =>
        {
            Debug.Log("QUESTION RETURNED: " + quest);
        }));
    }



    // Update is called once per frame
    void Update()
    {

    }
}
