using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Human : MonoBehaviour
{
    public int humanTotal = 1;
    public DataHuman bonuses;
    public TextMeshProUGUI TextGUI;
    
    private int humanDevisor = 3;
    private SnakeMovement snakeMovement;


    private LayerMask layerIn;


    private void OnTriggerEnter(Collider col)
    {
        layerIn = col.gameObject.layer;
        if (layerIn == LayerMask.NameToLayer("Snake"))
        {
            snakeMovement = col.gameObject.GetComponentInParent<SnakeMovement>();
            if (bonuses.HumanCounter % humanDevisor == 0)
            {
                snakeMovement.AddBodyPart();
            }

            bonuses.AddHumanCount (humanTotal);
            TextGUI.text = bonuses.HumanCounter.ToString();
            Destroy(gameObject);
        }

    }
}
