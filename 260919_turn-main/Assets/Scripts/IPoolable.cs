using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public Transform Tr { get; }
    
    // public void Take();
    public void Return();
}
