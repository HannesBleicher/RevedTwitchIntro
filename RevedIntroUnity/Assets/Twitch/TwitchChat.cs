using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TwitchChat : MonoBehaviour
{
    private TwitchIRC IRC;

    private spawner Spawner;

    private SaveNames names;

    private bool allowSpwn;

    private Menu menu;


    public Image ConnectionStateImage;
    
    private void Awake()
    {
        Application.runInBackground = true;
        
        Spawner = GetComponent<spawner>();
        menu = GetComponent<Menu>();
        names = GetComponent<SaveNames>();
        
        // Place TwitchIRC.cs script on an gameObject called "TwitchIRC"
        IRC = GetComponent<TwitchIRC>();

        // Add an event listener
        IRC.newChatMessageEvent.AddListener(NewMessage);

        StartCoroutine(waitTime());
    }


    private void FixedUpdate()
    {
        int state = IRC.ConnectonState;

        if (state == 0 )
        {
            ConnectionStateImage.color = Color.red;
        }
        if (state == 1 )
        {
            ConnectionStateImage.color = Color.yellow;
        }
        if (state == 2 )
        {
            ConnectionStateImage.color = Color.green;
        }
    }


    public void NewMessage(Chatter chatter)
    {
        string UserName = chatter.login;

        if (allowSpwn)
        {
            if (menu.SliderAllowAgain == 0)
            {
                if (UserName.Length < 15)
                {
                    Spawner.Spawn(UserName);
                    allowSpwn = false;
                    StartCoroutine(waitTime());
                }

                if (UserName.Length > 16 && UserName.Length < 25 && Random.Range(1, 10) < 3)
                {
                    Spawner.Spawn(UserName);
                    allowSpwn = false;
                    StartCoroutine(waitTime());
                }

            }
            else
            {
                if (!names.IsUsed(UserName))
                {
                    if (UserName.Length < 15)
                    {
                        Spawner.Spawn(UserName);
                        allowSpwn = false;
                        StartCoroutine(waitTime());
                    }

                    if (UserName.Length > 16 && UserName.Length < 25 && Random.Range(1, 10) < 3)
                    {
                        Spawner.Spawn(UserName);
                        allowSpwn = false;
                        StartCoroutine(waitTime());
                    }
                }
                else
                {
                    allowSpwn = true;
                }
            }
            

        }
    }
    


    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(menu.DelayTime);
        allowSpwn = true;
    }
}