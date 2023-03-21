using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public string cpName;

    public static CheckPoint instance;

    public Transform p, c;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_cp"))
        {

            if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName)
            {

                Behaviour.instance.transform.position = transform.position; //se, ao resetar a cena, esse foi o último cp, inicie aqui

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", ""); //reseta as coordenadas caso você clique L em cima do checkpoint
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reseta as coordenadas caso você clique L em cima do checkpoint
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioManager.instance.playSFX(2);
            if(PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") != cpName){
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", cpName);
            }
            

        }
    }

    public void check()
    {
        if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName)
        {
            //Behaviour.instance.transform.position = transform.position; //se, ao resetar a cena, esse foi o último cp, inicie aqui
            p.position = c.position;
        }
        else
        {
            print("2");
            gameManager.instance.PlayerDied();
        }
    }
}
