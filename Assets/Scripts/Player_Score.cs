using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Score : MonoBehaviour
{

    public float timeLeft = 120;
    public int playerScore;
    public int highscore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject highScoreUI;
    public AudioSource coin;



    //testing only
    private void Start()
    {
        DataManagement.datamanagement.LoadData();
        highscore = DataManagement.datamanagement.highScore;
        playerScore = PlayerPrefs.GetInt("PlayerScore");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int) timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score:  " + playerScore);
        highScoreUI.gameObject.GetComponent<Text>().text = ("High Score:  " + highscore);
        if (timeLeft < 0.1f)
        {
            if (SceneManager.GetActiveScene().name == ("level1"))
            {
                SceneManager.LoadScene(1);
            }

            if (SceneManager.GetActiveScene().name == ("level2"))
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            DataManagement.datamanagement.SaveData();
            PlayerPrefs.SetInt("PlayerScore", playerScore);

            if (SceneManager.GetActiveScene().name == ("level1"))
            {
                SceneManager.LoadScene(2);
            }

            if (SceneManager.GetActiveScene().name == ("level2"))
            {
                SceneManager.LoadScene(3);
                PlayerPrefs.DeleteAll();
            }
            
        }  
        
        if (trig.gameObject.tag == "Coin")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
            coin.Play();
        }

    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        if (DataManagement.datamanagement.highScore < playerScore)
        {
            DataManagement.datamanagement.highScore = playerScore;
            DataManagement.datamanagement.SaveData();
        }

    }

}
