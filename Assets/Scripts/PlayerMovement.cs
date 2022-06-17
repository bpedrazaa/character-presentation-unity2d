using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    Rigidbody2D rb;

    public float speed = 50f;
    float hMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Reimplementation of the Update
    void FixedUpdate()
    {
        if (rb.position.x > -8.5 && rb.position.x < 8.5)
        {
            controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
            animator.SetFloat("Speed", Mathf.Abs(hMove));
            jump = false;
        }
        else
        {
            rb.MovePosition(new Vector2(0.0f, 0.0f));
        }
    }

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }
     
    public void OnCrouch(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "block03") {
            Debug.Log("Collision");
            SceneManager.LoadScene("SelectionScene");
        } 
    }

}
