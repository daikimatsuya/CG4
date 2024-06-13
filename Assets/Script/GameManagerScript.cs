using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject block2;
    [SerializeField] private float blockSize;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject coin;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private Transform goalParticle;

    private GameObject gameClearText;

    private int score;

    #region mapchip
    int[,] map =
    {
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,1,1},
        { 1,1,0,3,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1},
        { 1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };
    #endregion

    private void GameManagerContoroller()
    {

    }
    private void BlockCreate()
    {
        for(int y = 0; y < map.GetLength(0); y++)
        {
            for(int x=0; x < map.GetLength(1); x++)
            {
                GameObject __ = Instantiate(block2);
                __.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 3);

                if (map[y,x] == 1)
                {
                    GameObject _ = Instantiate(block);
                    _.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 0);

                }
                if (map[y,x] == 2)
                {
                    GameObject _ = Instantiate(goal); 
                    _.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 0);
                   goalParticle.position = _.transform.position;
                }
                if (map[y,x] == 3)
                {
                   GameObject _=Instantiate(coin);
                    _.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 0);
                    _.transform.localEulerAngles = new Vector3(0, 0, 90);
                }
            }
        }

    }
    public void GetScore()
    {
        score++;
        scoreText.text = "Score " + score;
    }
    public void Clear()
    {
        gameClearText.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, false);

        gameClearText = GameObject.FindWithTag("GameClearText");
        goalParticle = GameObject.FindWithTag("GoalParticle").GetComponent<Transform>();

        gameClearText.SetActive(false);
        BlockCreate();

        scoreText.text = "Score " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
