using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateEnter : MonoBehaviour
{
    // Start is called before the first frame update

    public gateMovementOut outMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            outMovement.movement = true;
            Behaviour.instance.canMove = false;
        }
    }
}
