using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Transform tf;
    [SerializeField] private GameObject sound;
    [SerializeField] private GameObject particle;
    GameManagerScript gm;

    private void Roll()
    {
        tf.localEulerAngles=new Vector3(tf.localEulerAngles.x,tf.localEulerAngles.y+2,tf.localEulerAngles.z); 
    }
    private void Get()
    {
        GameObject _=Instantiate(sound);
        GameObject __=Instantiate(particle);
        __.transform.position=tf.transform.position;
        gm.GetScore();
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Get();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tf=GetComponent<Transform>();
        gm=GameObject.FindWithTag("GameController").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Roll();
    }
}
