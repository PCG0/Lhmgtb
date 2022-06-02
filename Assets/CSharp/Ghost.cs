using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform m_playerTransform;


    void DestroyGhost()
    {
        Destroy(gameObject);
    }

    private void Update(){
        m_playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        if (m_playerTransform.position.x < 0)
        {
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            if (m_playerTransform.position.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
