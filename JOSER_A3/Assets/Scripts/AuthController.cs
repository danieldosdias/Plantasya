using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Auth;

public class AuthController : MonoBehaviour
{

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    // Login Variables
    [Header("Login")]
    public TextMeshProUGUI usernameLoginInput, passwordLoginInput;


    //Register variables
    [Header("Register")]
    public TextMeshProUGUI usernameRegisterInput, passwordRegisterInput;

    [Header("Error Window")]
    public GameObject errorWindow;
    public TextMeshProUGUI errorDescription;


    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
       /*  FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.Log(" **************** Could not resolve all Firebase dependencies: " + dependencyStatus);

                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        }); */
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        if (auth == null)
        {
            Debug.Log("null");
        }
    }

    //Function for the login button
  /*   public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(usernameLoginInput.text, passwordLoginInput.text));
    }
 */


    //Function for the register button
    /* public void RegisterButton()
    {
        //Call the register coroutine passing the email, password
        StartCoroutine(Register(usernameRegisterInput.text, passwordRegisterInput.text));
    } */

    /* private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = FirebaseSignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            errorDescription.text = message;
            errorWindow.SetActive(true);
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            /*  warningLoginText.text = "";
             confirmLoginText.text = "Logged In";}} */
        
     

     public void Logout()
    {

    }

    public void Login_Anonymous()
    {

    }



    /* private void Update()
    {
        if (flag)
        {
            errorWindow.SetActive(true);
            Debug.Log("flag = true");
        }
        else
        {
            errorWindow.SetActive(false);
            Debug.Log("flag = false");
        }
    }
 */


    /* public void Login()
    {


        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(usernameLoginInput.text, usernameLoginInput.text).ContinueWith(
            (task =>
            {
                if (task.IsCanceled)
                {
                    Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                    Debug.Log("deu erro");
                    flag = true;
                    GetErrorMessage((AuthError)e.ErrorCode);
                    return;

                }
                if (task.IsFaulted)
                {

                    Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                    Debug.Log("deu erro");
                    flag = true;
                    GetErrorMessage((AuthError)e.ErrorCode);
                    return;

                }
                if (task.IsCompleted)
                {
                    Debug.Log("User " + usernameLoginInput + " is LOGGED IN");
                }
            })
        );

    } */


    /*  public void RegisterUser()
     {

         //   --------------------- DAR FIX NA VALIDAÇÃO DOS CAMPOS ----------------------


                 string username = usernameRegisterInput.text;
                 string password = passwordRegisterInput.text;


                 if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                 {
                     Debug.Log("username:  " + usernameRegisterInput.text);
                     Debug.Log("password:  " + passwordRegisterInput.text);
                     print("Please enter an email and password to register");

                     return;
                 }


                 Debug.Log("passou no if");

         FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(usernameRegisterInput.text, passwordRegisterInput.text).ContinueWith(
                    (task =>
                    {
                        if (task.IsFaulted)
                        {

                            Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                            GetErrorMessage((AuthError)e.ErrorCode);
                            return;

                        }
                        if (task.IsCanceled)
                        {

                            Firebase.FirebaseException e = task.Exception.Flatten().InnerException as Firebase.FirebaseException;
                            GetErrorMessage((AuthError)e.ErrorCode);
                            return;
                        }
                        if (task.IsCompleted)
                        {
                            Debug.Log("REGISTRATION COMPLETED!");
                        }


                    })
            );
     } */


    /*  public void Activate()
     {
         errorWindow.SetActive(true);
     } */
    public void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();
        Debug.Log("errorDescription  ---  " + msg + "  --------");

        errorDescription.text = msg;
        Debug.Log("errorDescription.text : " + errorDescription.text);


        Debug.Log("passou a função ");


        /* if (errorWindow != null)
        {
            Debug.Log("Encontrou");
            Debug.Log("errorWindow is active");
        }
        else
        {
            Debug.Log("Não encontrou errorWindow");

        } */






        /* switch (errorCode)
        {

            case AuthError.AccountExistsWithDifferentCredentials:
                errorDescription.text = msg;
                break;

            case AuthError.EmailAlreadyInUse:
                errorDescription.text = msg;
                break;
            case AuthError.InvalidEmail:
                errorDescription.text = msg;
                break;

            case AuthError.WeakPassword:
                errorDescription.text = msg;
                break;

            case AuthError.MissingPassword:
                errorDescription.text = msg;
                break;

            case AuthError.MissingEmail:
                errorDescription.text = msg;
                break;

            case AuthError.WrongPassword:
                errorDescription.text = msg;
                break;

            case AuthError.UserNotFound:
                errorDescription.text = msg;
                break;
        } */

    }

}
