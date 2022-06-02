using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        if (moveX > 0){
            transform.localScale = new Vector3(1, 1, 1);
        } else{
            if (moveX < 0){
                transform.localScale = new Vector3(-1, 1, 1);
            } 
        } 
    }
}
