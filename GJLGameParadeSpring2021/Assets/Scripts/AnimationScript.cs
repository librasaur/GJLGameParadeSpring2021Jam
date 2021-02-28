using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator sheepAnim1;
    // Start is called before the first frame update
    void Start()
    {
        sheepAnim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

        //walking\\
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            sheepAnim1.CrossFade("walking", 0.1f);
            sheepAnim1.SetBool("isWalking", true);
            sheepAnim1.SetBool("isIdle", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            sheepAnim1.SetBool("isIdle", true);
            sheepAnim1.SetBool("isWalking", false);
            sheepAnim1.CrossFade("Idle", 0.1f);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            sheepAnim1.CrossFade("backstep", 0.1f);
            sheepAnim1.SetBool("isReversing", true);
            sheepAnim1.SetBool("isIdle", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            sheepAnim1.SetBool("isIdle", true);
            sheepAnim1.SetBool("isReversing", false);
            sheepAnim1.CrossFade("Idle", 0.1f);
        }



        //placeholder for testing the character selection animations\\

        if (Input.GetKeyDown(KeyCode.A))
        {
            sheepAnim1.CrossFade("CS no", 0.1f);
            sheepAnim1.SetBool("isPicked", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            sheepAnim1.SetBool("isIdle", true);
            sheepAnim1.SetBool("isPicked", false);
            sheepAnim1.CrossFade("Idle", 0.1f);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            sheepAnim1.CrossFade("CS yes", 0.1f);
            sheepAnim1.SetBool("isNotPicked", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            sheepAnim1.SetBool("isIdle", true);
            sheepAnim1.SetBool("isNotPicked", false);
            sheepAnim1.CrossFade("Idle", 0.1f);
        }



    }
    // needs to merge this into lizzies character controller as input will affect the triggers\\
}
