using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class birdBehaviour : MonoBehaviour
{
    public float speed, pipeSpeed, maxTimePipe, waitTimerPipe;
    private float originalWaitTimerPipe;
    Rigidbody rig;
    public int points, minPoints, minPoints2, maxPoints;
    public static birdBehaviour instance;
    public bool played = false, played2 = false;
    public TMP_Text scoreText;


    public bool canMove;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        originalWaitTimerPipe = waitTimerPipe;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = gameManager.instance.start;

        if (canMove)
        {
            rig.useGravity = true;
            scoreText.text = points.ToString() + " / " + maxPoints.ToString() ;

            if (waitTimerPipe <= 0.8f)
            {
                waitTimerPipe = originalWaitTimerPipe;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioManager.instance.playSFX(1);
                rig.velocity = Vector2.up * speed;
            }

            if (points % 10 == 0 && points != 0 && !played)
            {
                audioManager.instance.playSFX(3);
                played = true;
            }

            if(points == maxPoints)
            {
                StartCoroutine(waitEnd());
            }
        
        }
        else
        {
            rig.useGravity = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "badWall" && points != maxPoints)
        {
            audioManager.instance.playSFX(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    IEnumerator waitEnd()
    {
        if(!played2)
        {
            audioManager.instance.playSFX(4);
            played2 = true;
        }
        
        yield return new WaitForSeconds(2);


        SceneManager.LoadScene("P6");
    }
}
