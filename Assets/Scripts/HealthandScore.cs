using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthandScore : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public float Score;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Text scoreText, menuScoretext, highscoretext;
    public GameObject restartmenu;
    public AudioSource BackGroundMusic;

    GameControl GameControl;
    void Start()
    {
        scoreText.text = Score + "";
        GameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();

        highscoretext.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
    void Update()
    {
        for(int i = 0 ; i<hearts.Length ; i++)
        {

            if(i<health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i<numOfHearts)
            {
                hearts[i].enabled = true;
            } 
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(health <=0)
        {

            GameControl.isGameActive = false;
            scoreText.gameObject.SetActive(false);
            restartmenu.gameObject.SetActive(true);
            Cursor.visible = true;
            BackGroundMusic.Stop();
           
            for(int i = 0 ; i<hearts.Length ; i++)
            {
                hearts[i].gameObject.SetActive(false);
            }

            menuScoretext.text = Score + "";
        }


        if (PlayerPrefs.GetFloat("HighScore") < Score)
        {
            PlayerPrefs.SetFloat("HighScore", Score);
            highscoretext.text =  Score + "";
 
        }

    }

    public  void GetScore ()
    {
        Score += 100f;
        scoreText.text = Score + "";
    }

    public void GetFlappyScore ()
    {
        Score += 300f;
        scoreText.text = Score + "";
    }
}
