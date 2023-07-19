using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        WalkHandler();
        JumpHandler();
    }

    void WalkHandler() {
        float XInput = Input.GetAxis("Horizontal");
        float ZInput = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(XInput * WalkSpeed * Time.deltaTime, 0, ZInput * WalkSpeed * Time.deltaTime);

        Vector3 NewPosition = transform.position + Movement;

        rb.MovePosition(NewPosition);
    }

    void JumpHandler() { 
    
    
    }

}
