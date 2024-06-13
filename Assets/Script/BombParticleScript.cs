using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParticleScript : MonoBehaviour
{
    [SerializeField] private int deleteTime;

    private void Delete()
    {
        if (deleteTime <= 0)
        {
            Destroy(this.gameObject);
        }
        deleteTime--;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delete();
    }
}
