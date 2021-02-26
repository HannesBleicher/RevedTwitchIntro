using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTitle : MonoBehaviour
{

    private float speed = 50;

    private Vector3 StartPos;

    private RectTransform pos;

    private Vector3 Target;
    private Vector3 TargetPosition;
    
    private Vector3 velocity = Vector3.zero;

    private float Smooth = 2;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        pos = GetComponent<RectTransform>();
        StartPos = pos.localPosition;
        TargetPosition = TargetPosition + StartPos;
        Target = pos.localPosition;
        StartCoroutine(moveTarget());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //pos.localPosition = Vector3.MoveTowards(pos.localPosition, Target, speed * Time.deltaTime);
        
        pos.localPosition =  pos.localPosition = Vector3.SmoothDamp(pos.localPosition, Target, ref velocity, Smooth);
        
        
        if (Vector3.Distance(Target, TargetPosition) < 5)
        {

            TargetPosition = GenerateTarget()+ StartPos;
            //speed = Random.Range(0.11f, 0.33f);
        }
    }

    private IEnumerator moveTarget()
    {
        while (true)
        {
            Target = Vector3.MoveTowards(pos.localPosition, TargetPosition, speed * 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }


    private Vector3 GenerateTarget()
    {
        float minRange = 20;
        float maxRange = 30;
        
        float x, y;
        if (Random.Range(1, 11) < 5)
        {
            x = Random.Range(minRange, maxRange);
        }
        else
        {
            x = -Random.Range(minRange, maxRange);
        }
        
        
        if (Random.Range(1, 11) < 5)
        {
            y = Random.Range(minRange, maxRange);
        }
        else
        {
            y = -Random.Range(minRange, maxRange);
        }

        return new Vector3(x, y, 0);
    }
    
}
