using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float ballForce = 500;
    
    public int randomNumber;

    public GameObject spawnPoint;
    public GameMaster gameMaster;

    public bool readyToStart;

    public bool hasExtenderPowerup = false;

    public AudioClip deathSound;
    public AudioClip extenderSound;
    public AudioClip lifeSound;
    public AudioClip launchSound;
    public AudioClip bounceSound;
    public AudioClip speedSound;

    //public AudioClip destroySound;


    public AudioSource ballAudio;

    public ParticleSystem ballReset;

    private Vector2 storedVelocity;

    //public GameObject paddle;
    //public Vector3 scaleSize = new Vector3(5, 0, 0);


    // Start is called before the first frame update
    void Start()
    {

        ballRb = GetComponent<Rigidbody2D>();
        //ballRb.AddForce(Vector2.up * ballForce);
        readyToStart = true;

        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        //Grab ball's audio source
        ballAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (readyToStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetBall();
                //Debug.Log("Ball has been reset.");
                readyToStart = false;
                ballAudio.PlayOneShot(launchSound, 1.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ballRb.velocity = Vector2.zero;
            transform.position = spawnPoint.transform.position;
            Instantiate(ballReset, transform.position, transform.rotation);

            readyToStart = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "killZone")
        {

            gameMaster.playerLife--;
            Debug.Log("Ball hit the bottom");

            ballRb.velocity = Vector2.zero;
            transform.position = spawnPoint.transform.position;
            Instantiate(ballReset, transform.position, transform.rotation);


            readyToStart = true;

            gameMaster.UpdateLives(-1);
            ballAudio.PlayOneShot(deathSound, 1.5f);
        }

        //extender powerup
        if (collision.gameObject.tag == "ExtenderPowerup")
        {
            hasExtenderPowerup = true;
            Destroy(collision.gameObject);
            ballAudio.PlayOneShot(extenderSound, 1.0f);
        }

        if (collision.gameObject.tag == "LifePowerup")
        {
            gameMaster.playerLife++;
            Debug.Log("Player Lives: " + gameMaster.playerLife);
            Destroy(collision.gameObject);
            gameMaster.UpdateLives(1);
            ballAudio.PlayOneShot(lifeSound, 1.0f);
        }

        if (collision.gameObject.tag == "SpeedPowerup")
        {
            storedVelocity = ballRb.velocity;
            ballRb.AddForce(ballRb.velocity * 50);
            StartCoroutine(SpeedPowerupCountdownRoutine());
            ballAudio.PlayOneShot(speedSound, 1.0f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Etc")
        {
            ballAudio.PlayOneShot(bounceSound, 1.5f);
        }
    }

    void ResetBall()
    {
        //random spawn

        randomNumber = Random.Range(1, 3);
        //randomNumber = 3;

        if (randomNumber == 1)
        {
            ballRb.AddForce(Vector2.up * ballForce);
            ballRb.AddForce(Vector2.right * ballForce);
        }
        else if (randomNumber == 2)
        {
            ballRb.AddForce(Vector2.up * ballForce);
            ballRb.AddForce(Vector2.left * ballForce);
        }
        else if (randomNumber == 3)
        {
            ballRb.AddForce(Vector2.up * ballForce);

        }
    }

    IEnumerator SpeedPowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(2);

        ballRb.velocity = storedVelocity;
    }


}
