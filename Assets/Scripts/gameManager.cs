using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    public GameObject blackobject, coinsObject;
    public Image black;

    public bool start = false, whyStart;

    private GameObject[] coins;

    public GameObject endLevel;

    public TMP_Text coinText, titleText;

    private bool played, fadeText, appearText, startCo;

    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        if(SceneManager.GetActiveScene().name == "P5" && PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " did") == 1)
        {
            start = true;
        }

        if (SceneManager.GetActiveScene().name == "P6" && PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " did") == 1)
        {
            start = true;
        }

        if (SceneManager.GetActiveScene().name == "P7" && PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " did") == 1)
        {
            start = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2") != 0)
        {
            blackobject.SetActive(false);
            titleText.text = "";
            start = true;
        }

        if (fadeText)
        {
            titleText.color = Color.Lerp(new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a), new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0), 3f * Time.deltaTime);

        }

        if (appearText)
        {
            titleText.color = Color.Lerp(new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a), new Color(titleText.color.r, titleText.color.g, titleText.color.b, 1), 3f * Time.deltaTime);

        }

        //start scene
        if (!start)
        {
            black.color = Color.Lerp(new Color(black.color.r, black.color.g, black.color.b, black.color.a), new Color(black.color.r, black.color.g, black.color.b, 0), .1f * Time.deltaTime);
            if(black.color.a == 0)
            {
                blackobject.SetActive(false);
                start = true;

            }

            if(SceneManager.GetActiveScene().name == "P1")
            {
                if (!startCo)
                {
                    StartCoroutine(wait1());
                    startCo = true;
                }
                
            }

            if (SceneManager.GetActiveScene().name == "P2")
            {
                if (!startCo)
                {
                    StartCoroutine(wait2());
                    startCo = true;
                }

            }

            if (SceneManager.GetActiveScene().name == "P3" || SceneManager.GetActiveScene().name == "P4")
            {
                if (!startCo)
                {
                    StartCoroutine(wait3());
                    startCo = true;
                }

            }

            if (SceneManager.GetActiveScene().name == "P5" || SceneManager.GetActiveScene().name == "P6" || SceneManager.GetActiveScene().name == "P7")
            {
                if (!startCo)
                {
                    StartCoroutine(wait5());
                    startCo = true;
                }

            }

        }
        else
        {
            blackobject.SetActive(false);
            if (SceneManager.GetActiveScene().name != "P5" && SceneManager.GetActiveScene().name != "P6" && SceneManager.GetActiveScene().name != "P7")
            {
                if (!whyStart)
                {
                    Behaviour.instance.canMove = true;
                    whyStart = true;
                }
                
            }
            
            if (SceneManager.GetActiveScene().name == "P2")
            {
                coinsObject.SetActive(true);
            }
            }


        //coins
        if (SceneManager.GetActiveScene().name == "P2")
        {
            coins = GameObject.FindGameObjectsWithTag("coin");

            coinText.text = "Collect " + coins.Length.ToString() + " balls!";
            if(coins.Length == 0)
            {
                audioManager.instance.StopBGM();
                
                endLevel.SetActive(true);

                if (!played)
                {
                    audioManager.instance.playSFX(4);
                    played = true;
                }
                
            }
        }
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Behaviour.instance.transform.position = Behaviour.instance.checkPoint.position;

        //Behaviour.instance.canMove = false;
       // StartCoroutine(dieWait());
    }

    IEnumerator dieWait()
    {


        yield return new WaitForSeconds(1);
        
        //Behaviour.instance.GetComponent<Transform>().position = Behaviour.instance.checkPoint.position;

        //Behaviour.instance.die();
        //Behaviour.instance.canMove = true;
    }

    IEnumerator wait1()
    {

        appearText = true;

        yield return new WaitForSeconds(4);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(3);

        fadeText = false;

    }

    IEnumerator wait2()
    {

        appearText = true;

        yield return new WaitForSeconds(4);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(3);

        fadeText = false;

        blackobject.SetActive(false);
        start = true;
        coinsObject.SetActive(true);
    }

    IEnumerator wait3()
    {

        appearText = true;

        yield return new WaitForSeconds(3);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(2);

        fadeText = false;

        blackobject.SetActive(false);
        start = true;
    }

    IEnumerator wait5()
    {

        appearText = true;

        yield return new WaitForSeconds(2);

        appearText = false;
        fadeText = true;

        yield return new WaitForSeconds(2);

        fadeText = false;

        blackobject.SetActive(false);
        start = true;
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + " did", 1);
    }
}
