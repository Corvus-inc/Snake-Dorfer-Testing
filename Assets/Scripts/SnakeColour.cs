using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColour : MonoBehaviour
{
    public MeshRenderer partMesh;

    public void MakeColour(Material colour)
    {
        MeshRenderer[] meshMesh = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var item in meshMesh)
        {
            item.material = colour;
        }

    }
}
