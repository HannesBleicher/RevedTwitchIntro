using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;


public class peepoClown : MonoBehaviour
{
    private float jumpHight;
    private float JumpIntervallTime;
    private float runSpeed;

    private Rigidbody2D rb;
    public bool grounded;
    public bool JumpGrounded;
    
    
    public TextMeshPro PlayetNameText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        
        jumpHight = Random.Range(1.0f, 1.3f);
        JumpIntervallTime = Random.Range(0.5f, 1.5f);
        runSpeed = Random.Range(1.2f, 1.5f);

        StartCoroutine(jumpIntevall());

        rb = GetComponent<Rigidbody2D>();

        //PlayetNameText.text = "UserName123";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (new Vector3(1.3f * runSpeed, 0, 0) * Time.deltaTime);
        
        ChackGrounded();
        ChackForJump();
    }


    private void ChackGrounded()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, new Vector2(0, -100));
        if (hitDown.collider != null)
        {
            if (!hitDown.collider.CompareTag("peepo"))
            {
                if (Vector2.Distance(transform.position, hitDown.point) < 0.6f)
                {
                    grounded = true;
                }
                else
                {
                    grounded = false;
                }
            }
        }
        else
        {
            grounded = false;
        }
    }

    private void ChackForJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1f, -1.0f));
        if (hit.collider != null)
        {
            float Dis = Vector2.Distance(transform.position, hit.point);
            if (Dis > 0.8f)
            {
                Jump();
            }
            Debug.DrawLine(transform.position, hit.point);

        }
    }

    private void Jump()
    {
        if (grounded && JumpGrounded)
        {
            rb.AddForce(Vector2.up*(jumpHight*110*Random.Range(1.8f,2.5f)));
            JumpGrounded = false;
        }
        
    }

    private IEnumerator jumpIntevall()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f) * JumpIntervallTime);
            Jump();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("delete"))
        {
            Destroy(gameObject);
        }
        if (!collision.gameObject.CompareTag("peepo"))
        {
            JumpGrounded = true;
        }
        
    }
    
    


}
