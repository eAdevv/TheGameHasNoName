using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    HealthandScore healthandscore;
    public GameObject deadEffectRG, deadEffectBP, deadEffectFlappy;
    public GameObject PauseMenu;
    public bool isGameActive = true;
    public bool isGamePaused = false;

    void Start()
    {
        healthandscore = GameObject.Find("Gobel").GetComponent<HealthandScore>();
    }

    
    void Update()
    {

        if (isGameActive == false) 
        {

            GameObject [] Gameobject_Black =  GameObject.FindGameObjectsWithTag("Black");
            
                    EndGameEffectControl(deadEffectBP, Gameobject_Black);

            GameObject[] Gameobject_Red    =  GameObject.FindGameObjectsWithTag("Red");

                    EndGameEffectControl(deadEffectRG, Gameobject_Red);

            GameObject[] Gameobject_Purple =  GameObject.FindGameObjectsWithTag("Purple");

                    EndGameEffectControl(deadEffectBP, Gameobject_Purple);

            GameObject[] Gameobject_Green  =  GameObject.FindGameObjectsWithTag("Green");

                    EndGameEffectControl(deadEffectRG, Gameobject_Green);

            GameObject[] Gameobject_Flappy =  GameObject.FindGameObjectsWithTag("Flappy");

                    EndGameEffectControl(deadEffectFlappy, Gameobject_Flappy);

        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

   public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        GameObject music = GameObject.FindGameObjectWithTag("floor");
        music.GetComponent<AudioSource>().Play();


    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
        GameObject  music = GameObject.FindGameObjectWithTag("floor");
        music.GetComponent<AudioSource>().Pause();

    }
    public void exitButton()
    {
        Application.Quit();
    }

    public void EndGameEffectControl(GameObject deadEffect,GameObject [] Game_Object)
    {
        for (int i = 0; i < Game_Object.Length; i++)
        {
            Destroy(Game_Object[i]);
            GameObject Gameobject_Effect = Instantiate(deadEffect, Game_Object[i].gameObject.transform.position, Quaternion.Euler(-180f, 0, 0)) as GameObject;
            Destroy(Gameobject_Effect.gameObject, 1f);
        }
    }

}
