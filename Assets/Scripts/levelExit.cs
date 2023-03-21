using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelExit : MonoBehaviour
{
    public string nextLevel;

    public float waitEndLevel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameManager.instance.levelEnding = true;
            //AudioManage.instance.PlayVictory();

            StartCoroutine(EndLevelCo());
        }
    }

    private IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", ""); //reseta o checkpoint do próximo level
        PlayerPrefs.SetString("CurrentLevel", nextLevel); //save do level 

        //PlayerPrefs.SetInt("PlayerCoins", PlayerController.instance.coins);
        //PlayerPrefs.SetInt("PlayerScore", PlayerController.instance.scorePlayer);
        //PlayerPrefs.SetInt("PlayerHealth", PlayerHealthController.instance.currentHealth);
        //PlayerPrefs.SetFloat("PlayerTimer", PlayerController.instance.timer);

        yield return new WaitForSeconds(waitEndLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
