using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlataform : MonoBehaviour
{
    // Start is called before the first frame update

    public bool canMove, playerIn, destroyBool;

    public float speed, destroyTime;

    public Material origMaterial, fallMaterial;

    public MeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = origMaterial;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            mesh.material = fallMaterial;
        }
        else
        {
            mesh.material = origMaterial;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIn = true;
            canMove = true;
            other.transform.SetParent(transform);
            StartCoroutine(destroy());
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        playerIn = false;
        other.transform.SetParent(null);
    }

    IEnumerator destroy()
    {

        yield return new WaitForSeconds(destroyTime);
        if (destroyBool)
        {
            if (playerIn)
            {
                gameManager.instance.PlayerDied();
            }
            Destroy(this.gameObject);
        }
        else
        {
            canMove = false;
        }
        

    }
}
