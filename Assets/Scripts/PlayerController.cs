using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    Rigidbody rb;
    bool started;
    public bool gameOver;
    int lives = 3;
    int coins = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        started = false;
        gameOver = false;
    }

    private void Update()
    {
       if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, 0, moveSpeed);
                started = true;
            }
        }
       Debug.DrawRay(transform.position, Vector3.down, Color.blue);
       if(! Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }
        if(Input.GetMouseButtonDown(0) &&!gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z >0)
        {
            rb.velocity = new Vector3(moveSpeed, 0, 0);
        }

        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, moveSpeed);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="trap")
        {
            
            lives--;
            if(lives<1 && coins!>2)
            {
                gameOver = true;
              
                Debug.Log("u died");

            }
        }

        if(other.gameObject.tag =="coin")
        {
            coins++;
            other.gameObject.SetActive(false);
            Debug.Log("coin added");
        }
    }

}
