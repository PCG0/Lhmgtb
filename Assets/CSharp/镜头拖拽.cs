using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 镜头拖拽 : MonoBehaviour
{
    Vector2 mouseWorldPos, mouseStartPos;
    Vector3 cameraStartPos;
    float distance;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        mouseWorldPos = GetMouseWorldPos(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)){
            mouseStartPos = mouseWorldPos;
            cameraStartPos = transform.position;
        }
        if (Input.GetMouseButton(0)){
            distance = mouseWorldPos.x - mouseStartPos.x;
            transform.position = new Vector3(cameraStartPos.x - distance, transform.position.y, transform.position.z);
        }
    }
    Vector2 GetMouseWorldPos(Vector3 mousePos){
        float factor = Screen.height / cam.orthographicSize / 2;
        float X = (mousePos.x - Screen.width / 2) / factor;
        float Y = (mousePos.y - Screen.width / 2) / factor;
        return new Vector2(X, Y);
    }
}
