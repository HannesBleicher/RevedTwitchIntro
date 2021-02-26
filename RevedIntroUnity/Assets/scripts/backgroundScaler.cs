using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScaler : MonoBehaviour
{
    // Start is called before the first frame update

    public bool typeTrasnform = false;
    
    void Start()
    {
        Application.runInBackground = true;
        if (typeTrasnform)
        {
            float height = Camera.main.orthographicSize * 2;
            float width = height * Screen.width / Screen.height;

            transform.localScale = new Vector3(width, height, 0);
        }
        if (!typeTrasnform)
        {
            float height = Camera.main.orthographicSize * 2;
            float width = height * Screen.width / Screen.height;

            Vector3 scale = transform.localScale; 
            
            transform.localScale = new Vector3(width, height, 0);

            transform.localScale = new Vector3(transform.localScale.x * scale.x, transform.localScale.y * scale.y,1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
