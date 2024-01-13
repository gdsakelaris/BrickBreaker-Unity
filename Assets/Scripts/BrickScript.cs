using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickScript : MonoBehaviour
{
    public float brickPoints = 20;
    public float currentHits = 0;
    public float maxHits = 1;

    public LevelController levelController;
    public GameObject levelObject;

    private SpriteRenderer spriteRenderer;

    private GameMaster gameMaster;

    public AudioClip hitSound;
    //public AudioClip destroySound;

    private AudioSource brickAudio;

    public ParticleSystem explosion;
    public ParticleSystem brickBounceVFX;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelObject = GameObject.Find("LevelController");
        levelController = levelObject.GetComponent<LevelController>();

        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        brickAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHits >= maxHits)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            //brickAudio.PlayOneShot(destroySound, 1.0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            currentHits++;
            levelController.currentScore = levelController.currentScore + brickPoints;
            gameMaster.UpdateScore(20);
            //brickAudio.PlayOneShot(hitSound, 1.0f);
            Instantiate(brickBounceVFX, transform.position, transform.rotation);

            // color change
            //spriteRenderer.color = Color.green;
        }
    }
}
