using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSound : MonoBehaviour
{
    [SerializeField] private int life;

    private void CountDown()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
        life--;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
