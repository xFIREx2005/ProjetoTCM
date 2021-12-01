using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerControler 
{
    bool checkSmokeRun;
    int numSmoke;
    private void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
        life = 3;
        gun = 1;
        checkSmokeRun = true;
        numSmoke = 0;
    
    }

    private void Update()
    {
        ProcessInputs();
        ChooseGun();
        Run();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 13;
            if (numSmoke <= 6)
                if (checkSmokeRun == true)
                {
                    Instantiate(smokeRun, smokeSpawn.transform.position, transform.rotation);
                    StartCoroutine(RunSmoke());
                    numSmoke++;
                    checkSmokeRun = false;
                }

        }
        else
        {
            numSmoke = 0;
            speed = 8;
        }

        
    }

    IEnumerator RunSmoke()
    {
        yield return new WaitForSeconds(0.05f);
        checkSmokeRun = true;
    }
}
