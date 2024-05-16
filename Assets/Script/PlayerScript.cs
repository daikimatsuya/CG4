using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    private GameManagerScript gm;

    private float playerSpeed;
    private bool isCanJump;
    private bool isClear;

    [SerializeField] private float playerAcce;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float jumpPower;


    private void PlayerController()
    {
        if(!isClear)
        {
            Move();
            Jump();
        }
      
    }
    private void Move()
    {
        playerSpeed = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerSpeed += playerAcce;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerSpeed -= playerAcce;
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
    private void Load()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManagerScript>();    
        rb = GetComponent<Rigidbody>();

        isCanJump = true;
        isClear = false;
        playerSpeed = 0;
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            gm.Clear();
            isClear = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       Load();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();
    }
}
