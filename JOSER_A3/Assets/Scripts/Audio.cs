using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;


    void Start()
    {
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (muted == false)
            {
                muted = true;
                AudioListener.pause = true;
                UpdateButtonIcon();
            }
            else
            {
                muted = false;
                AudioListener.pause = false;
                UpdateButtonIcon();
            }
        }
    }

    /*  public void DetectKeyboardInput()
     {
         if (Input.GetKeyDown(KeyCode.M))
         {
             if (muted == false)
             {
                 muted = true;
                 AudioListener.pause = true;
             }
             else
             {
                 muted = false;
                 AudioListener.pause = false;

             }
         }
     } */
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;

        }
        UpdateButtonIcon();
    }


    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }


    /*  public void MuteToggle(bool muted)
     {
         if (muted)
         {
             AudioListener.volume=0;
         }else{
             AudioListener.volume=0.2f;
         }
     } */
}
