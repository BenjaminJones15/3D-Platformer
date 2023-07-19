using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpSpeed;

    private Vector3 PlayerSize;

    private Rigidbody rb;
    private Collider col;

    private bool JumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        PlayerSize = col.bounds.size;
    }

    // Update is called once per frame
    void FixedUpdate(){
        WalkHandler();
        JumpHandler();
    }

    void WalkHandler() {
        float XInput = UnityEngine.Input.GetAxis("Horizontal");
        float ZInput = UnityEngine.Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(XInput * WalkSpeed * Time.deltaTime, 0, ZInput * WalkSpeed * Time.deltaTime);

        Vector3 NewPosition = transform.position + Movement;

        rb.MovePosition(NewPosition);
    }

    void JumpHandler(){
        float YInput = UnityEngine.Input.GetAxis("Jump");

        if (YInput > 0){
            bool IsGrounded = CheckGrounded();

            if (JumpPressed != true && IsGrounded == true){
                JumpPressed = true;
                Vector3 Jump = new Vector3(0, YInput * JumpSpeed, 0);
                rb.AddForce(Jump, ForceMode.VelocityChange);
            }
            
        } else{
            JumpPressed = false;
        }
    }

    private bool CheckGrounded(){
        Vector3 Corner1 = transform.position + new Vector3(PlayerSize.x/2, -PlayerSize.y/2 + 0.01f, PlayerSize.z/2);
        Vector3 Corner2 = transform.position + new Vector3(-PlayerSize.x / 2, -PlayerSize.y / 2 + 0.01f, PlayerSize.z / 2);
        Vector3 Corner3 = transform.position + new Vector3(PlayerSize.x / 2, -PlayerSize.y / 2 + 0.01f, -PlayerSize.z / 2);
        Vector3 Corner4 = transform.position + new Vector3(-PlayerSize.x / 2, -PlayerSize.y / 2 + 0.01f, -PlayerSize.z / 2);

        bool Grounded1 = Physics.Raycast(Corner1, -Vector3.up, 0.1f);
        bool Grounded2 = Physics.Raycast(Corner2, -Vector3.up, 0.1f);
        bool Grounded3 = Physics.Raycast(Corner3, -Vector3.up, 0.1f);
        bool Grounded4 = Physics.Raycast(Corner4, -Vector3.up, 0.1f);

        print(Grounded4);
        print(Grounded3);
        print(Grounded2);
        print(Grounded1);

        return Grounded1 || Grounded2 || Grounded3 || Grounded4;
    }
}
