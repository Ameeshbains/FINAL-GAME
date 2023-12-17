using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RolexScript : MonoBehaviour
{


    //This is for the score to appear
    public TextMeshProUGUI scoreText;

    //This is to set the score
    private int score;


    //This is for the horizontal input
    public float horizontalInput;


    //This is for the vertical input
    public float verticalInput;


    //This is for the speed 
    public float speed = 15.0f;
    private Animator playerAnim;

    public int gameOverThreshold = 100; // points needed for winning the game


    //This is for the particle effects
    public ParticleSystem explosionParticle;


    //The range in which the player can move
    public float xRange = 15.0f;
    public float zRange = 15.0f;
    public float zForwardRange = 15.0f;


    //This is for gameOver 
    public bool gameOver;


    //This is for the audio sounds in game, such as crash and jump
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    //This is for powerup
    public bool hasPowerUp = false;


    //This is the powerup indicator
    public GameObject powerupIndicator;


    //This is for the audio of the background
    public AudioSource[] audios;


    //This initialization of the rigidbody
    private Rigidbody playerRB;


    //Jumpforce of  player
    public float jumpForce = 10;


    //Modifying the gravity
    public float gravityModifier;    
    

    //To check if the player is on the ground or not 
    public bool isOnGround = true;

    


    // Start is called before the first frame update
    void Start()
    {



        
        //These are refernces before we can use them
        //1. rigidbody for applying physics to the game
        playerRB = GetComponent<Rigidbody>();

        //2. This is for referencing the audi for the main camera, so that we can use it to play or pause
        audios = FindObjectsOfType<AudioSource>();

        //2. This is for the aniamtion for game
        playerAnim = GetComponent<Animator>();

        //3. THis is for the audio of the game
        playerAudio = GetComponent<AudioSource>();







        Physics.gravity *= gravityModifier; //We are getting all the physics of the game, and we are 
                                            //A short form of saying "Physics.gravity = gravityModifier * Physics.gravity


        //Updating the score
        score = 0;
        updateScore(0);



    }

    // Update is called once per frame
    void Update()
    {

        //This is the movement method 
        Movement();



    }




    public void Movement()
    {
        


            //We have to prevent the player from going off the side of the screen with an if-then statement.
            if (transform.position.x < -xRange)
            {

                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);


            }
            //We have to prevent the player from going off the side of the screen with an if-then statement.
            if (transform.position.x > xRange)
            {

                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);


            }


            //We have to prevent the player from going off the front of the screen with an if-then statement.
            if (transform.position.z < -zForwardRange)
            {

                transform.position = new Vector3(transform.position.x, transform.position.y, -zForwardRange);


            }
            //We have to prevent the player from going off the backwards of the screen with an if-then statement.
            if (transform.position.z > zRange)
            {

                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);


            }

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");




            //This code is used to make the character (ROLEX) go left and right.
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


           
                
            //This is the animation for when we press the up arrow  
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {

                playerAnim.SetBool("Static_b", false);
                playerAnim.SetInteger("Speed_f", 1);
            


            }

            //This code is basically saying that if we press the key "SPACE" the player will jump up
            //Also, it will not allow us to double jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {

                    //ForceMode.Inpulse will immediately add force that we want to apply
                    playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    playerAnim.SetBool("Jump_b", false);
                    isOnGround = false;
                

                    playerAudio.PlayOneShot(jumpSound, 1.0f);       //JUMP SOUNDS  
                                                                    //The player audio will play in one go hence the name "One Shot" for jumpsounds



            }


            //This is used, so that when the powerup is aquired then the indicator will play and follow the player wherever you go 
             powerupIndicator.transform.position = transform.position;


        



    }



    //This is for when the player collides with the objects
    private void OnCollisionEnter(Collision collision)
    {


        //If we collide with the gameObject e.g. "VEG1" 
        //And we have poerup 
        //Then the method will play, which is used to handle the powerup when collided with
        //Or if we collide with the obstacle then this method will play
        //The same goes for every other tagged object

        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }
        else if (collision.gameObject.CompareTag("VEG1"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }


        }
        else if (collision.gameObject.CompareTag("VEG2"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }


        }
        else if (collision.gameObject.CompareTag("VEG3"))
        {

            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }

        }
        else if (collision.gameObject.CompareTag("VEG4"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }


        }
        else if (collision.gameObject.CompareTag("VEG5"))
        {

            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("VEG6"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("VEG7"))
        {

            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("VEG8"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("Obstacle1"))
        {

            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("Obstacle2"))
        {

            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("Obstacle3"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);
                

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }
        else if (collision.gameObject.CompareTag("Obstacle4"))
        {


            if (hasPowerUp)
            {
                HandlePowerUpCollision(collision.gameObject);

            }
            else
            {

                HandleObstacleCollision(collision.gameObject);

            }



        }



    }//END OF ONCOLLISION ENTER METHOD




    //This is method to handle the powerUps when we acquire it
    private void HandlePowerUpCollision(GameObject powerUp)
    {
        Debug.Log("Power-Up Collected!");
        hasPowerUp = true;
        Destroy(powerUp.gameObject);
        
        powerupIndicator.gameObject.SetActive(true);
        StartCoroutine(PowerupCountdownRoutine());
    }



    //This is a method to handle the Obstacle Collision when we Collide with the object
    private void HandleObstacleCollision(GameObject obstacle)
    {
        Debug.Log("GAME OVER!");
        gameOver = true;
        playerAudio.PlayOneShot(crashSound, 1.0f);
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }


        
        Destroy(obstacle);
        speed = 0;
        isOnGround = false;
        
    }





    //This is a method to handle the coins when we collide with the coins
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("COINS"))
        {
            Destroy(other.gameObject);          //To destroy
            updateScore(20); // each coin gives 10 points, modify this value accordingly
        }
    }


    //This is a method to update the score 
    void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;

        // Check if the score has reached the game over threshold
        if (score >= gameOverThreshold)
        {
            GameOver();
        }



    }


    //This is a method for game over when we reach the required points , which is 100
    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOver = true;
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }


        playerAnim.speed = 0;


        speed = 0;
        isOnGround = false;
        Invoke("win", 2f);
        // Add any other game over logic here...
    }






    public void win()

    {

        SceneManager.LoadSceneAsync(4);

    }

    //////////////
    // POWER UP //
    //////////////

    //This method is used to destroy the powerup object when collided with
    //Also, the powerup will be enabled
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("POWERUP"))
        {

            hasPowerUp = true;

            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());

        }





    }//END OF ONTRIGGERENTER METHOD




    //This is used to reset the player back to the original state when finishing the power up
    IEnumerator PowerupCountdownRoutine()
    {

        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerUp = false;

    }//END OF IENUMERATOR METHOD






}