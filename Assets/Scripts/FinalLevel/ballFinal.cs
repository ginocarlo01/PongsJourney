﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballFinal : MonoBehaviour
{

    private Rigidbody2D ball_;

    private int h, v;

    private float control = 0;

    public AudioClip touch, point;

    public AudioSource touchSource, pointSource;

    // Start is called before the first frame update
    void Start()
    {
        ball_ = GetComponent<Rigidbody2D>();

        h = Random.Range(1, 3);
        v = Random.Range(1, 3);

        if (h == 2)
        {
            h = -1;
        }

        if (v == 2)
        {
            v = -1;
        }

        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);

        control = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ball_.velocity = new Vector2(h * control, v * control);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7) //horizontal
        {
            v *= -1;

            control += .3f;

            audioManager.instance.playSFX(0);
        }

        if (collision.gameObject.layer == 8) //vertical
        {
            h *= -1;

            control += .3f;

            audioManager.instance.playSFX(0);
        }

        if (collision.gameObject.layer == 9) //player2
        {

            final.instance.points1 += 1;
            final.instance.death = 1;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.layer == 10) //player1
        {
            
            final.instance.points2 += 1;
            final.instance.death = 1;
            Destroy(this.gameObject);
        }
    }
}
