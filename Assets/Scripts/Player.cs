using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public static int speedValue;      // Current speed value
    float jumpForce = 5f;  
    int currentLane = 0;  // The lane the player is in (0 = middle, -1 = left, 1 = right)
    float laneDistance = 2.0f;
    float timeElapsed = 0f;  // To accumulate time between frames
    public static int speedbeforepause;
    int Fuel;
    int FuelDecrement;
    public int Score;
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text speedText;
    [SerializeField]
    TMP_Text fuelText;
    public static bool gameStarted =false ;
    public static bool firstTime;
    [SerializeField]
    TMP_Text FinalfuelText;
    public static bool isPaused;
    [SerializeField]
    GameObject PauseMenuPanel;
    private Events events;
    [SerializeField]
    GameObject StartGamePanel;
    public static bool restarting = false;
    bool onetimemusic = true;
    bool onetimepausemusic = true;
    bool onetimeresumemusic = true;
    public static bool muted = false;
    bool musicmuted1time = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedValue = 0;
        Score = 0;
        Fuel = 50;
        FuelDecrement = 1;
        firstTime = true;
        isPaused = false;
        events = FindObjectOfType<Events>();
        if (!muted)
        { 
            FindObjectOfType<AudioManager>().Play("screens"); 
        }
        print("starting the game screens music is playing");
        if (!restarting)
        {
            StartGamePanel.SetActive(true);
        }
        if (restarting)
        {
          restarting = false;
        }

    }
    void Update()
    {
        if (muted)
        {
            FindObjectOfType<AudioManager>().Stop("screens");
            musicmuted1time = true;
        }
        if (!muted && !gameStarted && musicmuted1time)
        {
            FindObjectOfType<AudioManager>().Play("screens");
            musicmuted1time = false;
        }
            if (gameStarted && onetimemusic && !muted)
        {
            print("game started gameplay music is playing ,screen music is stopping");
            FindObjectOfType<AudioManager>().Stop("screens");
            FindObjectOfType<AudioManager>().Play("gameplay");
            onetimemusic = false;
        }
        // Toggle between pause and resume using the Escape key
        if (gameStarted && Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPaused)
            {
                events.ResumeGame();
                if (onetimeresumemusic && !muted)
                {
                    FindObjectOfType<AudioManager>().Stop("screens");
                    FindObjectOfType<AudioManager>().Play("gameplay");
                    print(" resume,gameplay music is playing ,screen music is stopping");
                    onetimeresumemusic = false;
                    onetimepausemusic = true;
                }
            }
            else
            {
                PauseGame();
                if(onetimepausemusic && !muted)
                {
                    FindObjectOfType<AudioManager>().Stop("gameplay");
                    FindObjectOfType<AudioManager>().Play("screens");
                    print("pause,screen music is playing ,gameplay music is stopping");
                    onetimepausemusic = false;
                    onetimeresumemusic = true;
                }
            }
        }
        if (gameStarted && !isPaused)
        {
            if (firstTime)
            {
                firstTime = false;
                speedValue = 7;
                UpdateSpeed(speedValue);
            }
            // Handle horizontal lane switching
            HandleLaneSwitching();
            UpdateSpeed(speedValue);
            // Handle jumping
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            if (Input.GetButtonDown("Jump") && !IsGrounded())
            { 
                if(!muted)
                    FindObjectOfType<AudioManager>().Play("Invalid");
            }
            // if player drops into a hole game over
            if (transform.position.y < -5)
            {
                FinalfuelText.SetText("Game Over :( \n Final Score: " + Score);
                FindObjectOfType<AudioManager>().Play("empty");
                PlayerManager.gameOver = true;
            }

            // Accumulate time over each frame
            timeElapsed += Time.deltaTime;

            // Every 1 second, increase the score by 1
            if (timeElapsed >= 1f)
            {
                Score += 1;
                scoreText.SetText("Score: " + Score);
                Fuel = Mathf.Clamp(Fuel - FuelDecrement, 0, 50);
                // print fuel and fuel decrement in one line
                //print("Fuel: " + Fuel + " FuelDecrement: " + FuelDecrement);

                fuelText.SetText("Fuel: " + Fuel);
                // Reset timeElapsed for the next second
                timeElapsed = 0f;
            }
            // Check for game over if fuel is depleted
            if (Fuel <= 0)
            {
                FinalfuelText.SetText("Game Over :( \n Final Score: " + Score);
                PlayerManager.gameOver = true;
            }
          
            
        }
       
    }

    void FixedUpdate()
    {
        // Constant forward movement
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedValue);

        // Apply movement to the correct lane
        Vector3 targetPosition = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speedValue);
        transform.position = targetPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Game over
            FinalfuelText.SetText("Game Over :( \n Final Score: " + Score);
            PlayerManager.gameOver = true;
            if(!muted)
                FindObjectOfType<AudioManager>().Play("obs");

        }
        if (collision.gameObject.CompareTag("Burning Tile"))
        {
            FuelDecrement = 10;
            Fuel = Mathf.Clamp(Fuel - FuelDecrement, 0, 50);
            if(!muted)
                FindObjectOfType<AudioManager>().Play("burning");

        }
        if (collision.gameObject.CompareTag(" Supplies Tile"))
        {
            Fuel = 50;
            if(!muted)
                FindObjectOfType<AudioManager>().Play("supply");

        }
        if (collision.gameObject.CompareTag("Boost Tile"))
        {
            speedValue = 14;
            UpdateSpeed(speedValue);
            if (!muted)
                FindObjectOfType<AudioManager>().Play("boost");

        }
        if(collision.gameObject.CompareTag("Sticky Tile"))
        {
            speedValue = 7;
            UpdateSpeed(speedValue);
            if (!muted)
                FindObjectOfType<AudioManager>().Play("sticky");

        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Burning Tile"))
        {
            FuelDecrement = 1;  // Reset fuel decrement to 1 when leaving the Burning Tile
        }
         
        }

    void HandleLaneSwitching()
    {
        // Move to the right lane
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 1)  // Maximum lane is x+1
            {
                currentLane++;
            }
            else {
                if (!muted)
                    FindObjectOfType<AudioManager>().Play("Invalid");
            }
        }

        // Move to the left lane
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > -1)  // Minimum lane is x-1
            {
                currentLane--;
            }
            else
            {
                if (!muted)
                    FindObjectOfType<AudioManager>().Play("Invalid");
            }
        }
 
    }

    bool IsGrounded()
    {
        // Raycast downward from the player's position
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
    void UpdateSpeed(int speed)
    {
        if (speed == 7)
            speedText.SetText("Speed: Low");
        else if (speed == 14)
            speedText.SetText("Speed: High");
    }

    void PauseGame()
    {
        isPaused = true;
        PauseMenuPanel.SetActive(true); // Show the pause menu
        speedbeforepause = speedValue;
        speedValue = 0;
    }
}