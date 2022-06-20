using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeEndGameText : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject TryAgain;
    public GameObject WellDone;
    // Start is called before the first frame update
    void Start()
    {
      /*   if (int.Parse(scoreText.text, System.Globalization.NumberStyles.AllowLeadingSign) <= 0)
        {
            TryAgain.SetActive(true);
        }
        else
        {
            WellDone.SetActive(true);
        } */
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(scoreText.text, System.Globalization.NumberStyles.AllowLeadingSign) <= 0)
        {
            TryAgain.SetActive(true);
            WellDone.SetActive(false);

        }
        else
        {
            TryAgain.SetActive(false);
            WellDone.SetActive(true);
        }
    }
}
