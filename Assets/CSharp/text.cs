using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class text : MonoBehaviour
{
    public TMP_Text textText;
    
    IEnumerator TypeText(TMP_Text tMP_Text, string str, float interval)
    {
        int i = 0;
        while (i <= str.Length)
        {
            tMP_Text.text = str.Substring(0, i++);
            yield return new WaitForSeconds(interval); 
        }
    }
    
    private void Start()
    {
        StartCoroutine(TypeText(textText, "@CrosWuft 你好了没呀？", 0.15f));
    }
}
