using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpSpeed;

    private Vector3 PlayerSize;

    private Rigidbody rb;
    private Collider col;

    public float CameraDistancez = 4.75f;
    public float CameraDistancex = 2.3f;
    public float CameraDistancey = 5.15f;

    private bool JumpPressed = false;

    public AudioSource audioSource;
    public AudioClip EnemySound;
    public float volume = 1f;
    public bool Fallen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        PlayerSize = col.bounds.size;
        audioSource = GameObject.FindAnyObjectByType<AudioSource>();
        CameraFollow();
    }

    // Update is called once per frame
    void FixedUpdate() {
        WalkHandler();
        JumpHandler();
        FallingHandler();
        CameraFollow();
    }

    void WalkHandler() {
        float XInput = UnityEngine.Input.GetAxis("Horizontal");
        float ZInput = UnityEngine.Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(XInput * WalkSpeed * Time.deltaTime, 0, ZInput * WalkSpeed * Time.deltaTime);

        Vector3 NewPosition = transform.position + Movement;

        rb.MovePosition(NewPosition);

        if (XInput != 0 || ZInput != 0) {
            Vector3 FacingDirection = new Vector3(XInput, 0, ZInput);

            rb.rotation = Quaternion.LookRotation(FacingDirection);
        }
    }

    void JumpHandler() {
        float YInput = UnityEngine.Input.GetAxis("Jump");

        if (YInput > 0) {
            bool IsGrounded = CheckGrounded();

            if (JumpPressed != true && IsGrounded == true) {
                JumpPressed = true;
                Vector3 Jump = new Vector3(0, YInput * JumpSpeed, 0);
                rb.AddForce(Jump, ForceMode.VelocityChange);
            }

        } else {
            JumpPressed = false;
        }
    }

    void FallingHandler() { 
        if (transform.position.y < 0 && Fallen == false) {
            Fallen = true;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        audioSource.PlayOneShot(EnemySound, volume);
        yield return new WaitForSeconds(EnemySound.length);
        Fallen = false;
        GameManager.instance.ResetLevel();
    }

    void CameraFollow()
    {
        Vector3 CamPosition = Camera.main.transform.position;
        CamPosition.z = transform.position.z - CameraDistancez;
        CamPosition.x = transform.position.x - CameraDistancex;
        CamPosition.y = transform.position.y + CameraDistancey;

        Camera.main.transform.position = CamPosition;
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

        return Grounded1 || Grounded2 || Grounded3 || Grounded4;
    }


}
