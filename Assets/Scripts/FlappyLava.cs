using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyLava : MonoBehaviour
{
    private float LavaTime;
    private float LavaCoolDown;

    public GameObject Lava;
    public Transform lavapos;
    private float Min = 1f;
    private float Max = 8f;

    GameObject go;
    HealthandScore healthandscore;

    void Start()
    {
        LavaCoolDown = Random.Range(2f, 5f);
        healthandscore = GameObject.Find("Gobel").GetComponent<HealthandScore>();
    }

  
    void Update()
    {
        if (healthandscore.Score >= 4000)
        {
            Max = 6f;
        }
        if (healthandscore.Score >= 5000)
        {
            Max = 5f;
        }
        else if (healthandscore.Score >= 10000)
        {
            Max = 4f;
        }
        else if (healthandscore.Score >= 15000)
        {
            Max = 3f;
        }

        LavaTime = Random.Range(Min, Max);

        if (LavaCoolDown <= 0)
        {
            go = Instantiate(Lava, lavapos.position, lavapos.rotation);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -3f), ForceMode2D.Impulse);
            LavaCoolDown = LavaTime;
        }
        else 
        {
            LavaCoolDown -= Time.deltaTime;
        }
    }
}
