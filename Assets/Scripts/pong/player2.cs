using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{

    private float v;

    private Rigidbody2D player2_;

    // Start is called before the first frame update
    void Start()
    {
        player2_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //v = Input.GetAxisRaw("Horizontal"); //lê os valores do teclado vertical

        if (Input.GetKey(KeyCode.S))
        {
            v = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            v = 1;
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            v = 0;
        }

        player2_.velocity = new Vector2(0, v * 5);
    }
}
