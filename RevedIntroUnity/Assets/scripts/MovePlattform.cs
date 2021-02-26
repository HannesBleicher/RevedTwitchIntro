using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlattform : MonoBehaviour
{
    private float speed;


    private Vector3 StartPos;
    

    private int Dirrection; // -1 = runter / +1 = hoch


    private Vector3 TargetPosition;


    public bool Move;

    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        
        StartPos = transform.position;

        TargetPosition = TargetPosition + StartPos;

        speed = Random.Range(0.06f, 0.25f);
        
        if(Random.Range(-1.0f, 1.0f) >= 0)
        {
            Dirrection = 1;
        }
        else
        {
            Dirrection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, TargetPosition) < 0.1)
            {
                if (Dirrection == 1)
                {
                    TargetPosition = new Vector3(0, -Random.Range(0.2f,0.9f), 0)+ StartPos;
                    Dirrection = -1;
                    speed = Random.Range(0.11f, 0.33f);
                }

                else
                {
                    TargetPosition = new Vector3(0, Random.Range(0.2f,0.9f), 0) + StartPos;
                    Dirrection = 1;
                    speed = Random.Range(0.11f, 0.33f);
                }
            }
        }


    }
    



}
