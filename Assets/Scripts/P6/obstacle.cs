using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float vel;

    public bool good;

    public bool played;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (0, -1, -1) * vel * Time.deltaTime;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (good)
            {
                SideBehaviour.instance.GetCoin();

                if (!played)
                {
                    if (SideBehaviour.instance.coins % 10 == 0)
                    {
                        audioManager.instance.playSFX(3);
                    }
                    else
                    {
                        audioManager.instance.playSFX(0);
                    }

                    played = true;
                }
            }
            else
            {
                SideBehaviour.instance.die();
            }

            Destroy(this.gameObject);

            
        }

    }
}
