using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;

    public AudioSource bgm, victory;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBGM()
    {
        bgm.Play();
    }


    public void StopBGM()
    {
        bgm.Stop();
    }

    public void PlayVictory()
    {
        StopBGM();
        victory.Play();

    }

    public void playSFX(int sfxNumber)
    {
        //soundEffects[sfxNumber].Stop(); //para o som antes de começar pra ter certeza 
        soundEffects[sfxNumber].Play();
    }

    public void stopSFX(int sfxNumber)
    {
        soundEffects[sfxNumber].Stop();

    }
}
