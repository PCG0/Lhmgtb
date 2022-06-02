using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightCRTL : MonoBehaviour
{
    //public GameObject PlayerLight;
    private int ResoType = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            ResoType++;
            Debug.Log("w");
        }

        if (ResoType % 2 == 0)
        {
            gameObject.SetActive(false);
            ResoType++;
            return;
        }

        if (ResoType % 2 == 1)
        {
            gameObject.SetActive(true);
            ResoType++;
            return;
        }
    }
}
