using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupCoin: MonoBehaviour
{
    public bool collected;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !collected)
        {
            //PlayerController.instance.activeGun.GetAmmo(pickupCollor);

            Behaviour.instance.GetCoin();

            audioManager.instance.playSFX(0);

            collected = true;

            Destroy(this.gameObject);
        }
    }
}
