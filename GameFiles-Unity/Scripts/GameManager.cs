using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] desCandle;
    public TextMeshProUGUI predictText;
    public TextMeshProUGUI scoreText;
    //PLayer refernces
    public GameObject player;
    private float playerMoney;
    

    public bool gamePause;

    //DecisionPoints
    private int decisionCount = 0 ;
    
    
    // Start is called before the first frame update
    void Start()
    {
        predictText.gameObject.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        playerMoney = player.GetComponent<Player>().money;
        scoreText.text = "Money: $" + playerMoney;// player money
        DecisionPointLevel1();
        
    }

    void DecisionPointLevel1()
    {
        if ((desCandle[0].gameObject.transform.position.x - player.transform.position.x < 19f || desCandle[1].gameObject.transform.position.x - player.transform.position.x < 19f) && decisionCount==0)
        {

            predictText.gameObject.SetActive(true);
            gamePause = true;


        }
        else if ((desCandle[0].gameObject.transform.position.x - player.transform.position.x < 19f && desCandle[1].gameObject.transform.position.x - player.transform.position.x < 19f) && decisionCount == 1)
        {
            predictText.gameObject.SetActive(true);
            gamePause = true;


        }
        
    
    }

    public void UpPrediction()
    {
        gamePause = false;
        predictText.gameObject.SetActive(false);
        
        decisionCount += 1;
    }
    public void DownPrediction()
    {
        gamePause = false;
        predictText.gameObject.SetActive(false);
        
        decisionCount += 1;
    }
}
