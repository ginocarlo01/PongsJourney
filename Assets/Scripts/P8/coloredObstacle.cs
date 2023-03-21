using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coloredObstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float vel;

    public string color;

    public bool played;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1, -1) * vel * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (color == "P")
            {
                other.GetComponent<coinP8Manager>().coinsP--;

                if (!played)
                {
                    if (other.GetComponent<coinP8Manager>().coinsP == 0)
                    {
                        audioManager.instance.playSFX(3);
                        spawnObstacles.instance.objects[0] = spawnObstacles.instance.objects[4];
                    }
                    else
                    {
                        audioManager.instance.playSFX(0);
                    }

                    played = true;
                }
            }

            if (color == "O")
            {
                other.GetComponent<coinP8Manager>().coinsO--;

                if (!played)
                {
                    if (other.GetComponent<coinP8Manager>().coinsO == 0)
                    {
                        audioManager.instance.playSFX(3);
                        spawnObstacles.instance.objects[1] = spawnObstacles.instance.objects[4];
                    }
                    else
                    {
                        audioManager.instance.playSFX(0);
                    }

                    played = true;
                }
            }

            if (color == "N")
            {
                other.GetComponent<coinP8Manager>().coinsN--;

                if (!played)
                {
                    if (other.GetComponent<coinP8Manager>().coinsN == 0)
                    {
                        audioManager.instance.playSFX(3);
                        spawnObstacles.instance.objects[2] = spawnObstacles.instance.objects[4];
                    }
                    else
                    {
                        audioManager.instance.playSFX(0);
                    }

                    played = true;
                }
            }

            if (color == "G")
            {
                other.GetComponent<coinP8Manager>().coinsG--;

                if (!played)
                {
                    if (other.GetComponent<coinP8Manager>().coinsG == 0)
                    {
                        audioManager.instance.playSFX(3);
                        spawnObstacles.instance.objects[3] = spawnObstacles.instance.objects[4];
                    }
                    else
                    {
                        audioManager.instance.playSFX(0);
                    }

                    played = true;
                }
            }

            if (color == "B")
            {
                SideBehaviour.instance.die();
            }


            Destroy(this.gameObject);


        }

    }
}
