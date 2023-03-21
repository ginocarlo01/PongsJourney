using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinLevelManager : MonoBehaviour
{

    public TMP_Text P, O, N, G, Pi, Oi, Ni, Gi;

    private GameObject[] coinsP, coinsO, coinsN, coinsG;

    public bool playedP, playedO, playedN, playedG;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coinsP = GameObject.FindGameObjectsWithTag("P");
        coinsO = GameObject.FindGameObjectsWithTag("O");
        coinsN = GameObject.FindGameObjectsWithTag("N");
        coinsG = GameObject.FindGameObjectsWithTag("G");

        if (coinsP.Length == 0)
        {
            Pi.text = "";
            P.color = Color.Lerp(new Color(P.color.r, P.color.g, P.color.b, P.color.a), new Color(P.color.r, P.color.g, P.color.b, 1), 1f * Time.deltaTime);
            if (!playedP)
            {
                audioManager.instance.playSFX(5);
                playedP = true;
            }
            
        }

        if (coinsN.Length == 0)
        {
            Ni.text = "";
            N.color = Color.Lerp(new Color(N.color.r, N.color.g, N.color.b, N.color.a), new Color(N.color.r, N.color.g, N.color.b, 1), 1f * Time.deltaTime);
            if (!playedN)
            {
                audioManager.instance.playSFX(5);
                playedN = true;
            }
        }

        if (coinsO.Length == 0)
        {
            Oi.text = "";
            O.color = Color.Lerp(new Color(O.color.r, O.color.g, O.color.b, O.color.a), new Color(O.color.r, O.color.g, O.color.b, 1), 1f * Time.deltaTime);
            if (!playedO)
            {
                audioManager.instance.playSFX(5);
                playedO = true;
            }
        }

        if (coinsG.Length == 0)
        {
            Gi.text = "";
            G.color = Color.Lerp(new Color(G.color.r, G.color.g, G.color.b, G.color.a), new Color(G.color.r, G.color.g, G.color.b, 1), 1f * Time.deltaTime);
            if (!playedG)
            {
                audioManager.instance.playSFX(5);
                playedG = true;
            }
        }

    }
}
