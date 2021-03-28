using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public Transform spawnerRight, spawnerLeft, FlappySpawner;
    public GameObject Black, Red, Green, Purple,Flappy;
    public AudioSource popping;

    private float RightTime, LeftTime, FlappyTime;
    private float minTime = 1f;
    private float maxTime = 3f;
    private float FlappyMinTime = 5f;
    private float FlappyMaxTime = 7f;
    private float EnemyCoolDownTimeRight = 2f;
    private float EnemyCoolDownTimeLeft = 2f;
    private float FlappyCoolDown = 7f;

    HealthandScore healthandscore;
    GunSystem gunsystem;
    GameControl GameControl;
    void Start()
    {
        healthandscore = GameObject.Find("Gobel").GetComponent<HealthandScore>();
        gunsystem = GameObject.Find("Main Camera").GetComponent<GunSystem>();
        GameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
       if (healthandscore.Score >= 1000)
       {
            maxTime = 2f;
       }

       if (healthandscore.Score >= 3000)
       {
            minTime = 0.75f;
            maxTime = 2.25f;
       }

       if (healthandscore.Score >= 5000)
       {
            FlappyMinTime = 3f;
            FlappyMaxTime = 5f;
            minTime = 0.6f;
            maxTime = 1.75f;
       }

       if (healthandscore.Score >= 7500)
       {
            FlappyMinTime = 2f;
            FlappyMaxTime = 4f;
            minTime = 0.4f;
            maxTime = 1.5f;
       }

       if (healthandscore.Score >= 10000)
       {
            FlappyMinTime = 1f;
            FlappyMaxTime = 3f;
            gunsystem.startCoolDown = 0.20f;
            minTime = 0.3f;
            maxTime = 1f;
       }

        if (GameControl.isGameActive == true)
        {


            if (EnemyCoolDownTimeRight <= 0)
            {
                int RandomEnemyRight = Random.Range(1, 3);
                if (RandomEnemyRight == 1)
                {
                    Instantiate(Red, spawnerRight.position, spawnerRight.rotation);
                }
                else
                {
                    Instantiate(Green, spawnerRight.position, spawnerRight.rotation);
                }
                RightTime = Random.Range(minTime, maxTime);
                EnemyCoolDownTimeRight = RightTime;
            }
            else
            {
                EnemyCoolDownTimeRight -= Time.deltaTime;
            }


            if (EnemyCoolDownTimeLeft <= 0)
            {
                int RandomEnemyLeft = Random.Range(1, 3);

                if (RandomEnemyLeft == 1)
                {
                    Instantiate(Black, spawnerLeft.position, spawnerLeft.rotation);
                }
                else
                {
                    Instantiate(Purple, spawnerLeft.position, spawnerLeft.rotation);
                }
                LeftTime = Random.Range(minTime, maxTime);
                EnemyCoolDownTimeLeft = LeftTime;
            }

            else
            {
                EnemyCoolDownTimeLeft -= Time.deltaTime;
            }

            if (healthandscore.Score >= 2000)
            {

                if (FlappyCoolDown <= 0)
                {
                    Instantiate(Flappy, FlappySpawner.position, FlappySpawner.rotation);
                    FlappyTime = Random.Range(FlappyMinTime, FlappyMaxTime);
                    FlappyCoolDown = FlappyTime;
                }
                else
                {
                    FlappyCoolDown -= Time.deltaTime;

                }
            }


        }          
        
    }

    public void PopSound()
    {
        popping.Play();
    }



}
