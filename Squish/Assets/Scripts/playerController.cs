using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private int speed;

    public static float timeLeft = 12f;

    private Rigidbody2D rb2d;

    private int count;
    public Text countText;

    public GameObject bugSplat;
    public GameObject bugGoop;
    public GameObject goopScreen;

    public Text winText;
    public Text loseText;
    public Text quitText;

    public AudioSource bugCreature;
    public AudioClip slamSquish;

    public AudioSource winSource;
    public AudioSource loseSource;
    public AudioSource bgSource;


    void Start()
    {
        winSource.gameObject.SetActive(false);
        loseSource.gameObject.SetActive(false);
        bgSource.gameObject.SetActive(false);

        bugCreature.clip = slamSquish;

        rb2d = GetComponent<Rigidbody2D> ();

        count = 0;

        winText.text = "";
        loseText.text = "";
        quitText.text = "";

        SetCountText();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        SetCountText();

        //win
        if (count == 8 && (timeLeft < 11 || timeLeft > 0))
        {
            PlayAudio();
            speed = 0;
            goopScreen.SetActive(true);
            winText.text = "YOU WIN";
            quitText.text = "Press [ESC] to Quit.";
        }

        //begin
        else if (timeLeft > 10)
        {
            PlayAudio();
            goopScreen.SetActive(true);
            speed = 0;
        }

        //lose and end
        else if (count != 8 && timeLeft < 0)
        {
            PlayAudio();
            speed = 0;
            goopScreen.SetActive(true);
            loseText.text = "YOU LOSE";
            quitText.text = "Press [ESC] to Quit.";
        }

        else
        {
            goopScreen.SetActive(false);
            speed = 65;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && (timeLeft < 10 && timeLeft > 0))
        {
            Instantiate(bugSplat, other.transform.position, other.transform.rotation);
            Instantiate(bugGoop, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

            bugCreature.Play();

            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count + "/8"; 
    }

    IEnumerator AudioWait()
    {
        yield return new WaitForSeconds(2f);

        bgSource.gameObject.SetActive(true);
    }

    
    private void PlayAudio()
    {
        //win
        if (count == 8 && (timeLeft < 11 || timeLeft > 0))
        {
            winSource.gameObject.SetActive(true);
        }

        //begin
        else if (timeLeft > 10)
        {
            bgSource.gameObject.SetActive(true);
        }

        //lose and end
        else if (count != 8 && timeLeft < 1)
        {
            loseSource.gameObject.SetActive(true);
        }
    }
}
