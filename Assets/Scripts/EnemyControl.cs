using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemyControl : MonoBehaviour
{
    private float Speed = 2f;
    private float FlappySpeed = 1.5f;
    HealthandScore healthandscore;
    SpawnControl SoundControl;

    public GameObject deadEffectRG,deadEffectBP,deadEffectFlappy;
  
    void Start()
    {
        healthandscore = GameObject.Find("Gobel").GetComponent<HealthandScore>();
        SoundControl = GameObject.Find("EnemyScript").GetComponent<SpawnControl>();
        
    }

   
    void Update()
    {
      
        if(healthandscore.Score >= 1000)
        {
            Speed = 4f;
        }
        if(healthandscore.Score >= 3000)
        {
            Speed = 6f;          
        }
        if(healthandscore.Score >= 5000)
        {
            Speed = 7f;            
        }

        if(healthandscore.Score >= 10000)
        {
            Speed = 8f;
        }
        if(healthandscore.Score >= 15000)
        {
            Speed = 10f;
        }

    
        if(this.gameObject.tag == "Black" || this.gameObject.tag == "Purple" )
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }

       if(this.gameObject.tag == "Green" || this.gameObject.tag == "Red")
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

       if(this.gameObject.tag == "Flappy")
        {
            transform.position += Vector3.left * FlappySpeed * Time.deltaTime;
        }
           
    }

   

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(this.gameObject.tag == "Flappy")
        {

            if (collider.gameObject.tag == "FireBall")
            {
                SoundControl.PopSound();
                Destroy(this.gameObject);
                Destroy(collider.gameObject);
                healthandscore.GetFlappyScore();

                GameObject go = Instantiate(deadEffectFlappy, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(go.gameObject, 1f);
            }
            if (collider.gameObject.tag == "StopLeft")
            {
                Destroy(this.gameObject);
            }
        }

        if(this.gameObject.tag == "Lava")
        {
            if(collider.gameObject.tag == "floor")
            {
                Destroy(this.gameObject);
            }
            if(collider.gameObject.tag == "Player")
            {
                healthandscore.health -= 2;
                Destroy(this.gameObject);
            }
           
        }

        if(this.gameObject.tag == "Black" || this.gameObject.tag == "Purple")
        {
            if(collider.gameObject.tag == "Player")
            {
                healthandscore.health -= 1;
                Destroy(this.gameObject);

                ParticleEffect_BlueAndPurple();
            }
            if(collider.gameObject.tag == "StopRight")
            {
                Destroy(this.gameObject);
            }
            
            if(collider.gameObject.tag == "FireBall")
            {
                SoundControl.PopSound();
                Destroy(this.gameObject);           
                Destroy(collider.gameObject);
                healthandscore.GetScore();

                ParticleEffect_BlueAndPurple();
            }
        }

        if (this.gameObject.tag == "Red" || this.gameObject.tag == "Green")
        {
            if (collider.gameObject.tag == "Player")
            {
                healthandscore.health -= 1;
                Destroy(this.gameObject);

                ParticleEffect_RedAndGreen();
            }

            if (collider.gameObject.tag == "StopLeft")
            {
                Destroy(this.gameObject);
            }
            if (collider.gameObject.tag == "FireBall")
            {
                SoundControl.PopSound();
                Destroy(this.gameObject);
                Destroy(collider.gameObject);              
                healthandscore.GetScore();

                ParticleEffect_RedAndGreen();
            }
        }
    }

    public void ParticleEffect_RedAndGreen()
    {
        GameObject go = Instantiate(deadEffectRG, this.gameObject.transform.position, Quaternion.Euler(-180f, 0, 0)) as GameObject;
        Destroy(go.gameObject, 1f);
    }

    public void ParticleEffect_BlueAndPurple()
    {
        GameObject go = Instantiate(deadEffectBP, this.gameObject.transform.position, Quaternion.Euler(-180f, 0, 0)) as GameObject;
        Destroy(go.gameObject, 1f);
    }
}
