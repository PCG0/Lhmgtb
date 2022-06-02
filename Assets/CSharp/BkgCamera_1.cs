using UnityEngine;

public class BkgCamera_1 : MonoBehaviour
{
    public GameObject follow;
    public float scaleOffset;
    public bool isHorizontal = true;
    public bool isVertical = true;
    Vector2 pos;
    Vector2 followPos;
    float offsetX;
    float offsetY;

    private void Start()
    {
        if (follow != null){
            followPos = follow.transform.localPosition;
        }  
    }

    void LateUpdate()
    {
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
}

