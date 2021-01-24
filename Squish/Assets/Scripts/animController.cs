using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    Animator myAnimator;

    public AudioSource hammSlam;
    public AudioClip hammDown;

    void Start()
    {
        hammSlam.clip = hammDown;

        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("slam");
            hammSlam.Play();
        }

    }
        
}
