using UnityEngine;
using System.Collections;

public class MouseS : MonoBehaviour {

    private Vector3 OldMousePos = new Vector3(0, 0, 0);
    private bool MouseMove = false;
    private float MouseHideTime = -1;
    public float MouseHideTimer = 2;
    // Use this for initialization
    void Start () {
        InvokeRepeating("SearchMouseState", 1f, 0.3f);
    }
    
    // Update is called once per frame
    void Update () {
        if (!MouseMove && MouseHideTime >= 0)
        {
            MouseHideTime += Time.deltaTime;
            if (MouseHideTime >= MouseHideTimer)
            {
                Cursor.visible = false;
                MouseHideTime = -1;
            }
        }
    }

    void SearchMouseState()
    {
        if (Input.mousePosition != OldMousePos)
        {
            OldMousePos = Input.mousePosition;
            Cursor.visible = true;
            MouseMove = true;
            MouseHideTime = 0;
        }
        else
        {
            MouseMove = false;
        }
    }
}