using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SideBehaviour : MonoBehaviour
{
    public float speed = 10;

    public Vector3 velocity;

    public CharacterController controller;

    public bool jumping;

    public float wallMaxDistance = 5;

    public bool isGrounded;

    public LayerMask GroundMask;

    public Transform GroundCheck;

    public float jumpForce;

    public float gravityModifier;

    public float gravity;

    public Camera cam;

    public Transform Right, Left, Zero, rotCamDir;

    public float rotVelocity;

    

    public static SideBehaviour instance;

    public int coins;

    public bool canMove = false;

    public TMP_Text scoreText;

    public bool endByCoin;

    public int maxCoins;

    private bool played2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        canMove = gameManager.instance.start;
        if (canMove)
        {

            velocity.x = Input.GetAxis("Horizontal") * speed;

            controller.Move(velocity * Time.deltaTime);
        } 
    }

    public void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetCoin()
    {
        coins++;
        if(scoreText != null)
        {
            scoreText.text = coins.ToString() + " / " + maxCoins.ToString();
        }
        
        if(coins == maxCoins && endByCoin)
        {
            StartCoroutine(waitEnd());
        }

    }

    IEnumerator waitEnd()
    {
        if (!played2)
        {
            audioManager.instance.playSFX(4);
            played2 = true;
        }

        yield return new WaitForSeconds(3);


        SceneManager.LoadScene("P7");
    }


}