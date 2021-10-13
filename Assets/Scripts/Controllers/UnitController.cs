using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public int Speed { get; set; } = 4;

    private void Start()
    {
        Debug.Log("unit");
    }
}