using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void SetMode()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("mode", true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            animator.SetBool("mode", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMode();
    }
}
