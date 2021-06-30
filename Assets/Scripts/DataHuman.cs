using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHuman : MonoBehaviour
{
    private int _humaanCounter;

    public int HumanCounter
    {
        get
        {
            return _humaanCounter;
        }
        private set
        {
            _humaanCounter = value;
        }
    }

    public void AddHumanCount(int bonus)
    {
        _humaanCounter += bonus;
    }
}
