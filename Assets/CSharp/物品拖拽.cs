using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 物品拖拽 : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
    Vector2 dirVector;
    Vector2 direction;
    public GameObject circleObject;
    Rigidbody2D rb;

    public GameObject follow;
    public float scaleOffset;
    public bool isHorizontal = true;
    public bool isVertical = true;
    Vector2 pos;
    Vector2 followPos;




    //float offsetX;
    //float offsetY;
    

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        Instantiate(circleObject, transform.position, Quaternion.identity);
        if (follow != null){
            followPos = follow.transform.localPosition;
        } 
    }


    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void OnMouseDrag(){
        transform.position = mousePos + distance;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;


    }
    private void OnMouseUpAsButton(){
        rb.gravityScale = 0;
    }
/*
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "物品贴身判定")
        {
            rb.gravityScale = 0;
            Debug.Log("WWWW");

            if (follow != null)
            {
                pos = transform.localPosition;

                if (isHorizontal)
                {
                    offsetX = (follow.transform.localPosition.x - followPos.x) * scaleOffset;
                    pos.x += offsetX;
                }

                if (isVertical)
                {
                    offsetY = (follow.transform.localPosition.y - followPos.y) * scaleOffset;
                    pos.y += offsetY;
                }

                transform.localPosition = pos;
                followPos = follow.transform.localPosition;
            }
        }
    }*/
}
