using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerControler
{
    Animator animPlayer;
    bool checkSmokeRun;
    int numSmoke;
    public GameObject pausePanel, optionsPanel, volumePanel, controlsPanel;
    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        animPlayer = GetComponent<Animator>();
        sprPlayer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = 6;
        life = 3;
        gun = 1;
        checkSmokeRun = true;
        numSmoke = 0;
    
    }

    private void Update()
    {
        if (!isPaused)
        {
            ProcessInputs();
            ChooseGun();
            Run();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }

    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            optionsPanel.SetActive(false);
            volumePanel.SetActive(false); 
            controlsPanel.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animPlayer.SetBool("IsMoving", (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0));
        animPlayer.SetFloat("MoveX", (moveX));
        animPlayer.SetFloat("MoveY", (moveY));

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.Space) && (Input.GetButton("Vertical") || Input.GetButton("Horizontal")))
        {
            CameraShake.Instance.ShakeCamera(0.1f, 0.1f);
            animPlayer.speed = 1.5f;
            speed = 9;
            if (numSmoke <= 5)
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
            animPlayer.speed = 1f;
            numSmoke = 0;
            speed = 6;
        }

        
    }

    IEnumerator RunSmoke()
    {
        yield return new WaitForSeconds(0.03f);
        checkSmokeRun = true;
    }
}
