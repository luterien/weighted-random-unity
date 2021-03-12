using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weighted<T>
{
    public int Weight = 1;
    public T Key;
}