using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public Text timeText;
    public static float timeLeft = 12f;

    public Text titleText;
    public Text introText;
    public Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();

        titleText.text = "SQUISH";
        introText.text = "Use [ARROW KEYS] to move [SPACEBAR] to squish all 8 bugs.";
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft > 10)
        {
            timeText.text = "Time Left: 10";
        }

        else
        {
            titleText.text = "";
            introText.text = "";

            timeText.text = "Time Left: " + Mathf.Round(timeLeft);

            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
