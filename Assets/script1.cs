using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsRun", false);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 velocity = new Vector3(0, 0, 0.02f);
            transform.position += transform.rotation * velocity;
            animator.SetBool("IsRun", true);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            worldAngle.y += 1.0f;
            transform.eulerAngles = worldAngle;
        }
 
    }
}
