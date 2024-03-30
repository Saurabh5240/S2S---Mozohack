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

    private float gainMoney=0;

    private float gain = 0;
    public bool gamePause;
    public bool popup = false;
    //GameOver Displays
    public GameObject restart;
    public TextMeshProUGUI finalText;

    //DecisionPoints
    private int decisionCount = 0 ;

    public GameObject DonePopup;

    //ButtonEvents
    public GameObject upButton;
    public GameObject downButton;
    public GameObject doneButton;

    private Button up;
    private Button down;
    private Button done;

    //GamePopups]
    public GameObject[] images;

    
    // Start is called before the first frame update
    void Start()
    {
        predictText.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        //Set Butttons

        up = upButton.GetComponent<Button>();
        down= downButton.GetComponent<Button>();
        done = doneButton.GetComponent<Button>();



    }

    // Update is called once per frame
    void Update()
    {
        playerMoney = player.GetComponent<Player>().money;
        scoreText.text = "Money: $" + (playerMoney + gainMoney);// player money
        DecisionPointLevel1();
        GameOver();

        //Button Events
        if (Input.GetKeyDown(KeyCode.E))
        {
            up.onClick.Invoke();
        
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            down.onClick.Invoke();

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            done.onClick.Invoke();

        }


    }

    void DecisionPointLevel1()
    {
        if ((desCandle[0].gameObject.transform.position.x - player.transform.position.x) < 19f && decisionCount==0)
        {
            
            predictText.gameObject.SetActive(true);
            gamePause = true;


        }
        if (( desCandle[1].gameObject.transform.position.x - player.transform.position.x < 17f) && decisionCount == 1)
        {
            predictText.gameObject.SetActive(true);
          
            gamePause = true;


        }
        if ((desCandle[2].gameObject.transform.position.x - player.transform.position.x < 17f) && decisionCount == 2)
        {
            predictText.gameObject.SetActive(true);

            gamePause = true;


        }
        if ((desCandle[3].gameObject.transform.position.x - player.transform.position.x < 17f) && decisionCount == 3)
        {
            predictText.gameObject.SetActive(true);

            gamePause = true;


        }
        if ((desCandle[4].gameObject.transform.position.x - player.transform.position.x < 17f) && decisionCount == 4)
        {
            predictText.gameObject.SetActive(true);

            gamePause = true;


        }
        if ((desCandle[5].gameObject.transform.position.x - player.transform.position.x < 17f) && decisionCount == 5)
        {
            predictText.gameObject.SetActive(true);

            gamePause = true;


        }
        


    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    public void UpPrediction()
    {
        
        predictText.gameObject.SetActive(false);
      
        popup = true;
        decisionCount += 1;
        DonePopup.gameObject.SetActive(true);
        if (decisionCount == 1)
        {
            gainMoney += 500;
            images[0].gameObject.SetActive(true);

        }
        if (decisionCount == 2)
        {
            gainMoney -= 500;
            images[1].gameObject.SetActive(true);

        }
        if (decisionCount == 3)
        {
            gainMoney -= 500;
            images[2].gameObject.SetActive(true);

        }
        if (decisionCount == 4)
        {
            gainMoney += 500;
            images[3].gameObject.SetActive(true);

        }
        if (decisionCount == 5)
        {
            gainMoney -= 500;
            images[4].gameObject.SetActive(true);

        }
        if (decisionCount == 6)
        {
            gainMoney += 500;
            images[5].gameObject.SetActive(true);

        }


    }
    public void DownPrediction()
    {
        
        predictText.gameObject.SetActive(false);
     
        popup = true;
        decisionCount += 1;
        DonePopup.gameObject.SetActive(true);
        if (decisionCount == 1)
        {
            gainMoney -= 500;
            Debug.Log(playerMoney);
           
            images[0].gameObject.SetActive(true);

        }
        if (decisionCount == 2)
        {
            gainMoney += 500;
            Debug.Log(playerMoney);

            images[1].gameObject.SetActive(true);

        }
        if (decisionCount == 3)
        {
            gainMoney += 500;
            images[1].gameObject.SetActive(true);

        }
        if (decisionCount == 4)
        {
            gainMoney -= 500;
            images[3].gameObject.SetActive(true);

        }
        if (decisionCount == 5)
        {
            gainMoney += 500;
            images[4].gameObject.SetActive(true);

        }
        if (decisionCount == 6)
        {
            gainMoney -= 500;
            images[5].gameObject.SetActive(true);

        }

    }

    public void PopupOver()
    {
        gamePause = false;
        popup = false;
        DonePopup.gameObject.SetActive(false);
        images[0].gameObject.SetActive(false);
        images[1].gameObject.SetActive(false);
        images[2].gameObject.SetActive(false);
        images[3].gameObject.SetActive(false);
        images[4].gameObject.SetActive(false);
        images[5].gameObject.SetActive(false);

    }


    public void GameOver()
    {
        if (player.GetComponent<Player>().death)
        {
            gamePause = true;
            predictText.gameObject.SetActive(false);
            if (playerMoney + gainMoney > 500)
            {
                finalText.text = "Start Money : $ 500 " + "\n" + "Final Money : $" + (gainMoney + playerMoney)  + "\n" + "Total profit : $" + ((gainMoney + playerMoney) - 500);
            
            }
            if (playerMoney + gainMoney < 500 && playerMoney + gainMoney > 0)
            {
                finalText.text = "Start Money : $ 500 " + "\n" + "Final Money : $" + (gainMoney + playerMoney) + "\n" + "Total Loss : $" + (500 - (gainMoney + playerMoney));

            }
            if (playerMoney + gainMoney < 0)
            {
                finalText.text = "Start Money : $ 500 " + "\n" + "Final Money : $" + (gainMoney + playerMoney) + "\n" + " -- Loss -- \nDebt : $" + (500 - (gainMoney + playerMoney));

            }
            if (playerMoney + gainMoney == 500)
            {
                finalText.text = "Start Money : $ 500 " + "\n" + "Final Money : $" + (gainMoney + playerMoney) + "\n" + "No Profit or loss!";

            }
            
            
            restart.gameObject.SetActive(true);
        
        }
    
    }

    
    
}
