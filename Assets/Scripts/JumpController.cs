using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float allowedFlyTime = 0.5f;
    public float maxHeight = 2;
    public float cancelRate = 100;
    public Rigidbody rb;
    float jumpingTime;
    bool jumping;
    bool jumpCancelled;
    bool isGrounded;
    

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){
            float jumpForce = Mathf.Sqrt(maxHeight * -2 * (Physics.gravity.y * gameObject.GetComponent<ManualGravity>().gravityScale));
            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpingTime = 0;
        }
        if(jumping){
            jumpingTime += Time.deltaTime;
            if(Input.GetButtonDown("Crouch")){
                jumpCancelled = true;
            }
            if(jumpingTime > allowedFlyTime){
                jumping = false;
            }
        }
    }
    private void FixedUpdate(){
        if(jumpCancelled && jumping && rb.velocity.y > 0){
            rb.AddForce(Vector3.down * cancelRate);
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
