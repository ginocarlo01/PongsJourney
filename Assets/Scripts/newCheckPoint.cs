using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newCheckPoint : MonoBehaviour
{
    public int cpName;

    public static newCheckPoint instance;



    private void Awake()
    {
        instance = this;
    }

    public void check() { 
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_cp2"))
        {

            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2") == cpName)
            {

                Behaviour.instance.transform.position = transform.position; //se, ao resetar a cena, esse foi o último cp, inicie aqui

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2"));

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_cp2", 0); //reseta as coordenadas caso você clique L em cima do checkpoint
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
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2") != cpName)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_cp2", cpName);
            }


        }
    }

}
