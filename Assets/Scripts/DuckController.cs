//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Mathematics;
// ^ I think, i don't know why libary on top isn't not used

using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuckController : MonoBehaviour
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
    [SerializeField] GameObject duckplayer;

    public int healthBar = 5;
    public int score = 0;

    public int foodScore = 3;
    private static readonly int Jump = Animator.StringToHash("Jump");

    //void Start() {
        //public Text Health;
        //public Text Score;
        //public Text condition = " ";
    //}
    //time only; based on instructor
    //[SerializeField] float timecheck;

    void Update()
    {
        //timecheck = Time.time;

        playerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            duckplayer.transform.Translate(Vector2.right * speed * Time.deltaTime);
            duckplayer.transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            duckplayer.transform.Translate(Vector2.right * speed * Time.deltaTime);
            duckplayer.transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > jumpCooldown)
        {
            playerAnimator.SetBool("Jump", true);
            jumpCooldown = Time.time + jumpRate;
            playerRigidbody.AddForce(jumpSpeed * (Vector2.up * jumpPower));
        }
        else
        {
            playerAnimator.SetBool(Jump, false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            SceneManager.LoadScene("Level1");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            Destroy(col.gameObject);
            score++;
            print("score added" + score);
        }
    }
}
