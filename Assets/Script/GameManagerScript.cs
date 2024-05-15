using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private float blockSize;
    [SerializeField] private GameObject goal;

    private GameObject gameClearText;

    #region mapchip
    int[,] map =
    {
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
        { 1,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1},
        { 1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
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
                if (map[y,x] == 1)
                {
                    GameObject _ = Instantiate(block);
                    _.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 0);
                }
                if (map[y,x] == 2)
                {

                }
                if (map[y,x] == 3)
                {
                    GameObject _ = Instantiate(goal); ;
                    _.transform.position = new Vector3(x - 2, map.GetLength(0) - y, 0);
                }
            }
        }

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
        gameClearText.SetActive(false);
        BlockCreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
