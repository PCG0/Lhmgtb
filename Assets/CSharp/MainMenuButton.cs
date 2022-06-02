using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private int ResoType = 1;

    public void Play()
    {
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Start()
    {
        //GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
        //SceneManager.LoadScene("MainMenu");
    }

    public void Options(){

    }

    public void ResolutionSet()
    {
        if (ResoType % 2 == 0)
        {
            Screen.SetResolution(1366, 768, false);
            ResoType++;
            return;
        }
        if (ResoType % 2 == 1)
        {
            //Screen.SetResolution(2160, 1440, true, 60);
            
            //获取设置当前屏幕分辩率 
            Resolution[] resolutions = Screen.resolutions;
            //设置当前分辨率 
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
            Screen.fullScreen = true;  //设置成全屏
            ResoType++;
            return;
        }
    }

}