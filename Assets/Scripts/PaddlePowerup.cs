using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePowerup : MonoBehaviour
{
    //public GameObject paddle;
    public Vector3 scaleSize = new Vector3(4, 0, 0);

    public BallScript ballScript;
    public GameObject ballObject;

    public bool isExtended = false;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Ball");
        ballScript = ballObject.GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballScript.hasExtenderPowerup == true && isExtended == false)
        {
            this.transform.localScale += scaleSize;
            isExtended = true;
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        ballScript.hasExtenderPowerup = false;
        this.transform.localScale -= scaleSize;
        isExtended = false;
    }
}
