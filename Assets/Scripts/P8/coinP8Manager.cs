using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class coinP8Manager : MonoBehaviour
{

    public TMP_Text P, O, N, G, Pi, Oi, Ni, Gi;

    public float coinsP, coinsO, coinsN, coinsG;

    public bool played2;

    /*
    public static coinP8Manager instance;

    private void Awake()
    {
        instance = this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        coinsP = 10;
        coinsO = 9;
        coinsN = 8;
        coinsG = 7;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        coinsP = GameObject.FindGameObjectsWithTag("P");
        coinsO = GameObject.FindGameObjectsWithTag("O");
        coinsN = GameObject.FindGameObjectsWithTag("N");
        coinsG = GameObject.FindGameObjectsWithTag("G");
        */

        if (coinsP == 0)
        {
            Pi.text = "";
            P.color = Color.Lerp(new Color(P.color.r, P.color.g, P.color.b, P.color.a), new Color(P.color.r, P.color.g, P.color.b, 1), 1f * Time.deltaTime);

            
        }
        if(coinsP > 0)
        {
            Pi.text = coinsP.ToString();
        }

        if (coinsN == 0)
        {
            Ni.text = "";
            N.color = Color.Lerp(new Color(N.color.r, N.color.g, N.color.b, N.color.a), new Color(N.color.r, N.color.g, N.color.b, 1), 1f * Time.deltaTime);

        }
        if (coinsN > 0)
        {
            Ni.text = coinsN.ToString();
        }

        if (coinsO == 0)
        {
            Oi.text = "";
            O.color = Color.Lerp(new Color(O.color.r, O.color.g, O.color.b, O.color.a), new Color(O.color.r, O.color.g, O.color.b, 1), 1f * Time.deltaTime);

        }
        if (coinsO > 0)
        {
            Oi.text = coinsO.ToString();
        }

        if (coinsG == 0)
        {
            Gi.text = "";
            G.color = Color.Lerp(new Color(G.color.r, G.color.g, G.color.b, G.color.a), new Color(G.color.r, G.color.g, G.color.b, 1), 1f * Time.deltaTime);

        }
        if (coinsG > 0)
        {
            Gi.text = coinsG.ToString();
        }

        if (coinsG <= 0 && coinsN <= 0 && coinsO <= 0 && coinsP <= 0)
        {
            StartCoroutine(waitEnd());
        }

    }

    IEnumerator waitEnd()
    {
        if (!played2)
        {
            audioManager.instance.playSFX(4);
            played2 = true;
        }

        yield return new WaitForSeconds(2);


        SceneManager.LoadScene("P8");
    }
}
