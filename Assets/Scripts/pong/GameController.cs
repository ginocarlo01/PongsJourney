using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
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

    private float timer=0;

    public Image black;
    public GameObject blackImage;
    public TMP_Text titleText;
    public bool started = false, spawn = false, fading, fadeText, appearText;

    // Start is called before the first frame update
    void Start()
    {


        //Cursor.visible = false;
        titleText.text = "a game by ginocarlo01";
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
                if (timer < 30)
                {
                    audioManager.instance.playSFX(1);
                    GameObject ball_ = Instantiate(theBall) as GameObject;
                    ball_.transform.position = new Vector2(0, 0);

                    death = 0;
                }




            }

            if (timer >= 30)
            {
                if (!played)
                {
                    audioManager.instance.playSFX(2);
                    played = true;
                }


                //black.color = Color.Lerp(new Color(black.color.r, black.color.g, black.color.b, black.color.a), new Color(black.color.r, black.color.g, black.color.b, 1f), 5);

                players = GameObject.FindGameObjectsWithTag("Respawn");

                foreach (GameObject i in players)
                {
                    i.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(i.GetComponent<SpriteRenderer>().color.r, i.GetComponent<SpriteRenderer>().color.g, i.GetComponent<SpriteRenderer>().color.b, i.GetComponent<SpriteRenderer>().color.a), new Color(i.GetComponent<SpriteRenderer>().color.r, i.GetComponent<SpriteRenderer>().color.g, i.GetComponent<SpriteRenderer>().color.b, 0), 7 * Time.deltaTime);
                    if (i.GetComponent<SpriteRenderer>().color.a == 0)
                    {
                        Destroy(i.gameObject);
                    }

                }

                StartCoroutine(fadeIn());

                //ball_.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(ball_.GetComponent<SpriteRenderer>().color.r, ball_.GetComponent<SpriteRenderer>().color.g, ball_.GetComponent<SpriteRenderer>().color.b, ball_.GetComponent<SpriteRenderer>().color.a), new Color(ball_.GetComponent<SpriteRenderer>().color.r, ball_.GetComponent<SpriteRenderer>().color.g, ball_.GetComponent<SpriteRenderer>().color.b, 0), 10 * Time.deltaTime);
            }
        }
       

    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("P1");
        PlayerPrefs.SetString("P1_cp", "");
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(3);

        fadeText = true;

        yield return new WaitForSeconds(3);

        StartCoroutine(wait2());
    }

    IEnumerator wait2()
    {
        
        titleText.text = "Pong's Journey";
        fadeText = false;
        appearText = true;

        yield return new WaitForSeconds(3);

        fadeText = true;
        appearText = false;

        yield return new WaitForSeconds(3);

        StartCoroutine(wait3());
    }

    IEnumerator wait3()
    {
        titleText.text = "Level 1: PONG!";
        fadeText = false;
        appearText = true;
        

        yield return new WaitForSeconds(3);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(3f);
        blackObject.SetActive(false);
        started = true;
    }
}
