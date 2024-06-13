using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] private string inGame;
    [SerializeField] private GameObject hitkey;
    [SerializeField] private float hitKeyTimer;

    private int timer;

    private void TitleSceneController()
    {
        SceneChange();
        BlinkingHitKey();
    }
    private void SceneChange()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Jump") != 0)
        {
            SceneManager.LoadScene(inGame);
        }
    }
    private void BlinkingHitKey()
    {
        timer--;
        if(timer<=0)
        {
            timer = (int)(hitKeyTimer * 2 * 60);
        }
        if (timer > hitKeyTimer * 60)
        {
            hitkey.SetActive(false);
        }
        else
        {
            hitkey.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        TitleSceneController();
    }
}
