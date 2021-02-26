using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovePlattform : MonoBehaviour
{
    private float speed;


    private Vector3 StartPos;
    

    private int Dirrection; // -1 = runter / +1 = hoch


    private Vector3 TargetPosition;


    public bool Move;

    private Vector3 Target;
    private Vector3 velocity = Vector3.zero;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        
        StartPos = transform.position;

        TargetPosition = TargetPosition + StartPos;

        speed = Random.Range(0.03f, 0.15f);
        
        
        
        if(Random.Range(-1.0f, 1.0f) >= 0)
        {
            Dirrection = 1;
        }
        else
        {
            Dirrection = -1;
        }

        StartCoroutine(moveTarget());
    }


    private void FixedUpdate()
    {
        if (Move)
        {
            //Target = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
            
            //transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);

            transform.position =    transform.position = Vector3.SmoothDamp(transform.position, Target, ref velocity, 0.8f);
            
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

    private IEnumerator moveTarget()
    {
        while (Move)
        {
            Target = Vector3.MoveTowards(transform.position, TargetPosition, speed * 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }
    



}
