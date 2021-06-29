using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCrystal : MonoBehaviour
{
    private int _crystalCounter;

    public int CrystalCounter
    {
        get
        {
            return _crystalCounter;
        }
        private set
        {
            _crystalCounter = value;
        }
    }

    public void AddCrystalBonus(int bonus)
    {
        _crystalCounter += bonus;
    }
}
