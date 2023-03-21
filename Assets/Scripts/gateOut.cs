using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gateOut : MonoBehaviour
{

    public GameObject player;
    public Transform objective;
    public bool movement;
    public float turnSpeed;
    private float time;
    public gateMovementOut gateOutObj;
    public Transform newDestiny;
    public Image black;
    public GameObject blackObj;

    // Start is called before the first frame update
    void Start()
    {
        movement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            time += Time.deltaTime * turnSpeed;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, objective.rotation, time);
            
            black.color = Color.Lerp(new Color(black.color.r, black.color.g, black.color.b, black.color.a), new Color(black.color.r, black.color.g, black.color.b, 1), .5f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            blackObj.SetActive(true);
            movement = true;
            Behaviour.instance.canMove = false;
            gateOutObj.objective = newDestiny;
            gateOutObj.played = false;
            gateOutObj.movement = true;
            StartCoroutine(fadeIn());
        }
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(8);

        SceneManager.LoadScene("P5");
    }

}
