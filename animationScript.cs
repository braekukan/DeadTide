using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: this is the controller for the animations for the player in regards to walking. 
//Name: animationScript.cs

public class animationScript : MonoBehaviour
{
    //creates an animator
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //gets the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets value of the isWalking variable from the animator component
        bool isWalking = animator.GetBool("isWalking");

        //walking animation for moving forward
        if (!isWalking && Input.GetKey("w"))
        {
            animator.SetBool("isWalking", true);
        }
        // stops walking animation for moving forward
        if(isWalking && !Input.GetKey("w"))
        {
            animator.SetBool("isWalking", false);
        }
        //walking animation for moving to left
        if (!isWalking && Input.GetKey("a"))
        {
            animator.SetBool("isWalking", true);
        }
        //stops walking animation for moving to left
        if(isWalking && !Input.GetKey("a"))
        {
            animator.SetBool("isWalking", false);
        }
        //walking animation for moving backward
        if (!isWalking && Input.GetKey("s"))
        {
            animator.SetBool("isWalking", true);
        }
        //stops walking animation for moving backward
        if(isWalking && !Input.GetKey("s"))
        {
            animator.SetBool("isWalking", false);
        }
        //walking animation for moving to right
        if (!isWalking && Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
        }
        //stops walking animation for moving to right
        if(isWalking && !Input.GetKey("d"))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
