using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public List<MeshRenderer> meshChanges = new List<MeshRenderer>();
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = birdBehaviour.instance.waitTimerPipe;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += Vector3.left * birdBehaviour.instance.pipeSpeed * Time.deltaTime;

        if (birdBehaviour.instance.points >= birdBehaviour.instance.minPoints)
        {
            if(timer>= birdBehaviour.instance.waitTimerPipe)
            {
                for (int i = 0; i < meshChanges.Count; i++)
                {
                    Material wow, wow2;
                    wow = materials[Random.Range(0, materials.Count)];
                    meshChanges[0].material = wow;
                    meshChanges[2].material = wow;
                    wow2 = materials[Random.Range(0, materials.Count)];
                    meshChanges[3].material = wow2;
                    meshChanges[1].material = wow2;
                }
                timer = 0;
            }
        }
    }
}
