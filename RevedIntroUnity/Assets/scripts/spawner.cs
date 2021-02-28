using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawner : MonoBehaviour
{

    public GameObject peepo;
    public GameObject peepoClown;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
    }
    

    public void Spawn(string username)
    {
        if (Random.Range(0.0f, 4.0f) < 3.8f)
        {
            GameObject player;
            player = Instantiate(peepo, transform.position, quaternion.identity);
            player.GetComponent<peepo>().PlayetNameText.maxVisibleLines = 1;
            player.GetComponent<peepo>().PlayetNameText.text = username;
            
        }
        else
        {
            GameObject player;
            player = Instantiate(peepoClown, transform.position, quaternion.identity);
            player.GetComponent<peepoClown>().PlayetNameText.maxVisibleLines = 1;
            player.GetComponent<peepoClown>().PlayetNameText.text = username;
        }

        


    }


}
