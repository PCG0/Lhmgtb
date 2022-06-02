using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 镜头拉伸 : MonoBehaviour
{
    //速度    
    public float   ChangeSpeed = 1f;    
    private float maximum =   9;
    private float minmum =   6;
    
    void Update()
    {   
        /* 
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {    
            //限制size大小    
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minmum, maximum);
            //滚轮改变    
            Camera.main.orthographicSize = Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * ChangeSpeed;
        }   
        */

        if (Input.GetKeyDown("1"))
        {
            //限制size大小    
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minmum, maximum);
            //滚轮改变    
            Camera.main.orthographicSize = Camera.main.orthographicSize - ChangeSpeed;
        }
        else if (Input.GetKeyDown("2"))
        {
            //限制size大小    
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minmum, maximum);
            //滚轮改变    
            Camera.main.orthographicSize = Camera.main.orthographicSize + ChangeSpeed;

            
        }

        
    }   
}
