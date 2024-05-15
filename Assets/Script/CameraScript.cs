using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform tf;
    private Transform playerPos;

    private void CameraController()
    {
        Move();
    }
    private void Move()
    {
        tf.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
    }
    // Start is called before the first frame update
    void Start()
    {
        tf= GetComponent<Transform>(); 
        playerPos=GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraController();
    }
}
