using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    private float playerSpeed;
    private bool isCanJump;

    [SerializeField] private float playerAcce;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float jumpPower;

    private void PlayerController()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerSpeed += playerAcce;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerSpeed -= playerAcce;
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerSpeed = 0;
        }
        if( Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            playerSpeed = 0;
        }

        if(playerSpeed > MaxSpeed)
        {
            playerSpeed = MaxSpeed;
        }
        if(playerSpeed < -MaxSpeed)
        {
            playerSpeed = -MaxSpeed;
        }

        rb.velocity=new Vector3 (playerSpeed, rb.velocity.y, 0);
    }
    private void Jump()
    {
        if(isCanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y+jumpPower, 0);
                isCanJump = false;
            }
        }
        
    }
    public void OnCollisionEnter(Collision collision) 
    {
         {
            ContactPoint[] contacts = collision.contacts;
            Vector2 otherNormal = contacts[0].normal;
            Vector2 upVector = new Vector2(0, 1);
            float dotUN = Vector2.Dot(upVector, otherNormal);
            float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
            if (dotDeg <= 45)
            {
                isCanJump = true;
            }
             }//Ú’n”»’è
    }
        // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();

        isCanJump = true;
        playerSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();
    }
}
