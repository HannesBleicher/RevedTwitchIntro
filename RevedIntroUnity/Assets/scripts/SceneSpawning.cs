using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawning : MonoBehaviour
{

    public GameObject Ground1, Ground2;
    public GameObject Cactus, Plant1, Plant2, Stone1, Stone2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(1, 20);

        if (random < 4)
        {
            SpawnCase_2();
        }
        else
        {
            SpawnCase_1();
        }
    }
    
    private void SpawnCase_1()
    {
        Instantiate(Ground1, new Vector3(-11.5f, -3.7f, 0), Quaternion.identity);
        Instantiate(Ground1, new Vector3(8.5f, -3.7f, 0), Quaternion.identity);
        Instantiate(Ground1, new Vector3(-8.5f, -3.7f, 0), Quaternion.identity);
        
        SpawnGround001(new Vector2(0,-3.5f));
        SpawnGround001(new Vector2(4,-3.5f));
        SpawnGround001(new Vector2(-4.6f,-3.5f));
    }
    
    private void SpawnCase_2()
    {
        Instantiate(Ground2, new Vector3(-11.5f, -3.7f, 0), Quaternion.identity);
        Instantiate(Ground2, new Vector3(8.5f, -3.7f, 0), Quaternion.identity);
        Instantiate(Ground2, new Vector3(-8.5f, -3.7f, 0), Quaternion.identity);
        
        SpawnGround002(new Vector2(0,-3.5f));
        SpawnGround002(new Vector2(4,-3.5f));
        SpawnGround002(new Vector2(-4.6f,-3.5f));
    }

    private void SpawnGround001(Vector2 pos)
    {
        GameObject ground;
        ground = Instantiate(Ground1, pos, Quaternion.identity);
        ground.GetComponent<MovePlattform>().Move = true;

        int random = Random.Range(1, 15);


        if (random == 1 | random == 2)
        {
            GameObject obj;
            obj = Instantiate(Plant1, new Vector3(pos.x + Random.Range(-1.0f, 1.0f), pos.y + 1.1f, 0),
                Quaternion.identity);
            obj.transform.parent = ground.transform;

        }

        if (random == 3 | random == 4)
        {
            GameObject obj;
            obj = Instantiate(Plant2, new Vector3(pos.x + Random.Range(-1.0f, 1.0f), pos.y + 0.9f, 0),
                Quaternion.identity);
            obj.transform.parent = ground.transform;
        }

        if (random == 5 | random == 6)
        {
            GameObject obj;
            obj = Instantiate(Stone1, new Vector3(pos.x + Random.Range(-0.8f, 0.8f), pos.y + 1f, 0),
                Quaternion.identity);
            obj.transform.parent = ground.transform;
        }

        if (random == 7 | random == 7)
        {
            GameObject obj;
            obj = Instantiate(Stone2, new Vector3(pos.x + Random.Range(-0.8f, 0.8f), pos.y + 1f, 0),
                Quaternion.identity);
            obj.transform.parent = ground.transform;
        }

        if (random == 8)
        {
            GameObject obj1;
            obj1 = Instantiate(Stone2, new Vector3(pos.x + Random.Range(-0.8f, 0.8f), pos.y + 1f, 0),
                Quaternion.identity);
            obj1.transform.parent = ground.transform;
            GameObject obj2;
            obj2 = Instantiate(Stone1, new Vector3(pos.x + Random.Range(-0.8f, 0.8f), pos.y + 1f, 0),
                Quaternion.identity);
            obj2.transform.parent = ground.transform;
        }

        if (random == 9)
        {
            GameObject obj1;
            obj1 = Instantiate(Stone2, new Vector3(pos.x + Random.Range(-0.8f, 0.8f), pos.y + 1f, 0),
                Quaternion.identity);
            obj1.transform.parent = ground.transform;
            GameObject obj2;
            obj2 = Instantiate(Plant1, new Vector3(pos.x + Random.Range(-1.0f, 1.0f), pos.y + 1.1f, 0),
                Quaternion.identity);
            obj2.transform.parent = ground.transform;
        }
        
    }


    private void SpawnGround002(Vector2 pos)
    {
        GameObject ground;
        ground = Instantiate(Ground2, pos, Quaternion.identity);
        ground.GetComponent<MovePlattform>().Move = true;
        
        int random = Random.Range(1, 15);
        
        
        if (random == 1 | random == 2 | random == 3 )
        { 
            GameObject obj;
            obj = Instantiate(Cactus, new Vector3(pos.x + Random.Range(-1.0f,1.0f), pos.y + 1.3f,0), Quaternion.identity);
            obj.transform.parent = ground.transform;

        }
        if (random == 5)
        {
            GameObject obj1;
            obj1 = Instantiate(Cactus, new Vector3(pos.x + Random.Range(-1.0f,1.0f), pos.y + 1.3f,0), Quaternion.identity);
            obj1.transform.parent = ground.transform;
            
            GameObject obj2;
            obj2 = Instantiate(Cactus, new Vector3(pos.x + Random.Range(-1.0f,1.0f), pos.y + 1.1f,0), Quaternion.identity);
            obj2.transform.parent = ground.transform;
        }


    }
}
