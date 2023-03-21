using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public Transform enemy;

    public bool canDrop;

    public List<GameObject> dropModels = new List<GameObject>();

    public Transform dropPos;

    public string startDir;

    public float moveTime;

    public float moveSpeed;

    private float leftTime;

    private Vector3 direction;

    public bool invincible;

    public Transform pos1, pos2, posAtual;

    public int score = 5;

    public float deathIntensity;

    public Material moving, stop;

    public List<MeshRenderer> meshChanges = new List<MeshRenderer>();

    void Start()
    {

        if (score == 0)
        {
            score = 5;
        }

        leftTime = moveTime;

        if (startDir == "Left")
        {
            direction = Vector3.left;
        }
        if (startDir == "Right")
        {
            direction = Vector3.right;
        }
        if (startDir == "Up")
        {
            direction = Vector3.up;
        }
        if (startDir == "Down")
        {
            direction = Vector3.down;
        }

        if (startDir == "Forward")
        {
            direction = Vector3.forward;
        }

        if (startDir == "Follow")
        {
            posAtual = pos1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (startDir == "Rotate")
        {
            enemy.rotation = Quaternion.Euler(enemy.eulerAngles.x, enemy.eulerAngles.y + moveSpeed * Time.deltaTime, enemy.eulerAngles.z);

        }
        else
        {
            if (startDir == "Follow")
            {

                transform.position = Vector3.MoveTowards(transform.position, posAtual.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, pos1.position) < 0.5f)
                {
                    posAtual = pos2;
                }

                if (Vector3.Distance(transform.position, pos2.position) < 0.5f)
                {
                    posAtual = pos1;
                }

                if(posAtual == pos1)
                {
                    for (int i = 0; i < meshChanges.Count; i++)
                    {
                        meshChanges[i].material = moving;
                    }
                }

                if (posAtual == pos2)
                {
                    for (int i = 0; i < meshChanges.Count; i++)
                    {
                        meshChanges[i].material = stop;
                    }
                }


            }
            else
            {
                leftTime -= Time.deltaTime;
                enemy.position += direction * moveSpeed * Time.deltaTime;

                if (leftTime <= 0)
                {
                    //inverte a direção
                    direction *= -1;
                    //reinicia o tempo
                    leftTime = moveTime;

                }
            }

        }

    }

}
