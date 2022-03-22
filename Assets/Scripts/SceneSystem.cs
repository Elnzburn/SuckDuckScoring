//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Mathematics;
// ^ I think, i don't know why libary on top isn't not used

using UnityEngine;

public class SceneSystem : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    //[SerializeField] float maxSpeed = 1f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] bool grounded;

    [SerializeField] float jumpPower = 20f;
    [SerializeField] float jumpRate = 10f;
    [SerializeField] float jumpCooldown = 0.5f;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;
    //[SerializeField] Physics2D playerPhysics2D;
    //[SerializeField] GameObject this;

    
    
    
    //time only; based on instructor
    //[SerializeField] float timecheck;

    void Update()
    {
        //timecheck = Time.time;

        playerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            this.transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            this.transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > jumpCooldown)
        {
            playerAnimator.SetBool("Jump", true);
            jumpCooldown = Time.time + jumpRate;
            playerRigidbody.AddForce(jumpSpeed * (Vector2.up * jumpPower));
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }
}
