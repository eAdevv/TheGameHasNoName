using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public GameObject crosshair, player, gun, FireBall , smoke;
    private Vector3 target;
    public Transform FBPos;
    public AudioClip jumpSound, FireBallSound;

    public float offset;
    public float startCoolDown = 0.33f;
    private float CoolDownTime;
    
    GobelMove gobelMove;
    GameControl GameControl;
    void Start()
    {
        Cursor.visible = false;
        gobelMove = GameObject.Find("Gobel").GetComponent<GobelMove>();
        GameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
    }
    private void Update()
    {

        if (GameControl.isGameActive == true && GameControl.isGamePaused == false)
        {
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshair.transform.position = new Vector2(target.x, target.y);

            Vector3 diff = target - gun.transform.position;
            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);


            if (CoolDownTime <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<AudioSource>().PlayOneShot(FireBallSound, 1f);
                    Instantiate(FireBall, FBPos.position, FBPos.rotation);
                    CoolDownTime = startCoolDown;
                }
                if (Input.GetKeyDown(KeyCode.Mouse1) && gobelMove.isGround == true)
                {
                    if (gun.transform.rotation.z >= -200 || gun.transform.rotation.z <= -175)
                    {
                        GetComponent<AudioSource>().PlayOneShot(jumpSound, 1f);
                        GameObject go = Instantiate(smoke, FBPos.position, FBPos.rotation) as GameObject;
                        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8f), ForceMode2D.Impulse);
                        gobelMove.isGround = false;
                        Destroy(go.gameObject, 0.1f);
                    }
                }
            }

            else
            {
                CoolDownTime -= Time.deltaTime;
        
            }

        }
        else
        {
            if(GameControl.isGamePaused == false)
            {
                crosshair.gameObject.SetActive(true);
            }
           
        }
         
    }
    
}

