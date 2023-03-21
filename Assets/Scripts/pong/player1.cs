using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{

    private float v;

    private Rigidbody2D player1_;

    // Start is called before the first frame update
    void Start()
    {
        player1_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            v = -1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v = 1;
        }

        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            v = 0;
        }
        player1_.velocity = new Vector2(0, v * 5);
    }
}
