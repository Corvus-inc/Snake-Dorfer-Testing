using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crystal : MonoBehaviour
{
    public int crustalTotal = 5;
    public DataCrystal bonuses;
    public TextMeshProUGUI TextGUI;


    private LayerMask layerIn;


    private void OnTriggerEnter(Collider col)
    {
        layerIn = col.gameObject.layer;
        if (layerIn == LayerMask.NameToLayer("Snake"))
        {
            bonuses.AddCrystalBonus(crustalTotal);
            TextGUI.text = bonuses.CrystalCounter.ToString();
            Destroy(gameObject);
        }
         
    }
}
