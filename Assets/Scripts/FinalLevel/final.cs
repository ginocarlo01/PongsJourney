using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public GameObject theBall;

    public GameObject player1;

    public GameObject player2;

    public TextMeshProUGUI txtPlayer1;

    public TextMeshProUGUI txtPlayer2;

    public GameObject[] players;

    public int death;

    public int points2;

    public int points1;

    public GameObject blackObject;

    private bool played = false;

    private float timer = 0;

    public Image black;
    public GameObject blackImage;
    public TMP_Text titleText;
    public bool started = false, spawn = false, fading, fadeText, appearText;

    public static final instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


        //Cursor.visible = false;
        titleText.text = "Thanks for playing";
        StartCoroutine(wait1());


    }

    // Update is called once per frame
    void Update()
    {
        if (fadeText)
        {
            titleText.color = Color.Lerp(new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a), new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0), 3f * Time.deltaTime);

        }

        if (appearText)
        {
            titleText.color = Color.Lerp(new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a), new Color(titleText.color.r, titleText.color.g, titleText.color.b, 1), 3f * Time.deltaTime);

        }

        if (started)
        {

            if (!spawn)
            {
                GameObject ball_ = Instantiate(theBall) as GameObject;
                ball_.transform.position = new Vector2(0, 0);

                GameObject player1_ = Instantiate(player1) as GameObject;
                player1_.transform.position = new Vector2(7.56f, 0);

                GameObject player2_ = Instantiate(player2) as GameObject;
                player2_.transform.position = new Vector2(-7.56f, 0);
                spawn = true;
            }
            timer += Time.deltaTime;

            txtPlayer1.text = points1.ToString();

            txtPlayer2.text = points2.ToString();

            if (death == 1)
            {
                /*players = GameObject.FindGameObjectsWithTag("Respawn");

                foreach(GameObject i in players)
                {
                    Destroy(i.gameObject);
                }



                GameObject player1_ = Instantiate(player1) as GameObject;
                player1_.transform.position = new Vector2(7.56f, 0);

                GameObject player2_ = Instantiate(player2) as GameObject;
                player2_.transform.position = new Vector2(-7.56f, 0);*/

                audioManager.instance.playSFX(1);
                GameObject ball_ = Instantiate(theBall) as GameObject;
                ball_.transform.position = new Vector2(0, 0);

                death = 0;



            }

        }


    }



    IEnumerator wait1()
    {
        yield return new WaitForSeconds(5);

        fadeText = true;

        yield return new WaitForSeconds(3);

        StartCoroutine(wait2());
    }

    IEnumerator wait2()
    {

        titleText.text = "Pong's Journey is finished. He is at home now";
        fadeText = false;
        appearText = true;

        yield return new WaitForSeconds(3);

        fadeText = true;
        appearText = false;

        yield return new WaitForSeconds(7);

        StartCoroutine(wait3());
    }

    IEnumerator wait3()
    {
        titleText.text = "The end.";
        fadeText = false;
        appearText = true;


        yield return new WaitForSeconds(3);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(7f);
        blackObject.SetActive(false);
        started = true;
    }
}
