using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLine : MonoBehaviour
{
    public Material colour;

    private LayerMask layerIn;
    private SnakeColour colourMake;

    private void OnTriggerEnter(Collider col)
    {
        layerIn = col.gameObject.layer;
        if(layerIn == LayerMask.NameToLayer("Snake"))
        {
            colourMake = col.gameObject.GetComponentInParent<SnakeColour>();
            colourMake.MakeColour(colour);
        }
    }
}
