using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Human : MonoBehaviour
{
    public int humanTotal = 5;
    public DataHuman bonuses;
    public TextMeshProUGUI TextGUI;


    private LayerMask layerIn;


    private void OnTriggerEnter(Collider col)
    {
        layerIn = col.gameObject.layer;
        if (layerIn == LayerMask.NameToLayer("Snake"))
        {
            //bonuses.AddCrystalBonus(crustalTotal);
            //TextGUI.text = bonuses.CrystalCounter.ToString();
            Destroy(gameObject);
        }

    }
}
