using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{

    public Portal caller;

    private void Awake()
    {
        DontDestroyOnLoad(this); //Tells unity this gameObject should not destroy the object


        if (caller.portalEntry == 2)
        {
            caller.portalEntry = 0;
            Destroy(this);
        }

    }
}