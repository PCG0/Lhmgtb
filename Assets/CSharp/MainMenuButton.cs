using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private int ResoType = 1;
    private int OptiSet = 1;
    private int BkmSet = 1;
    private int LogSet = 1;

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

    public void Options()
    {
        
        
        if (OptiSet % 2 == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            OptiSet++;
            return;
        }
        if (OptiSet % 2 == 1)
        {
            
            transform.GetChild(0).gameObject.SetActive(true);
            OptiSet++;
            return;
        }
    }
    public void bkm()
    {
        if (BkmSet % 2 == 0)
        {
            GameObject.Find("backmusic").SetActive(false);
            BkmSet++;
            return;
        }
        if (BkmSet % 2 == 1)
        {
            
            GameObject.Find("backmusic").SetActive(true);
            BkmSet++;
            return;
        }
    }
    public void OptiCNM()
    {
        if (BkmSet % 2 == 0)
        {
            GameObject.Find("Canvas/MainMenu/UI/OptionCtrl/Options/CNM/cnm_audio").SetActive(false);
            BkmSet++;
            return;
        }
        if (BkmSet % 2 == 1)
        {
            
            GameObject.Find("Canvas/MainMenu/UI/OptionCtrl/Options/CNM/cnm_audio").SetActive(true);
            BkmSet++;
            return;
        }
    }
    public void OptiLog()
    {
        if (LogSet % 2 == 0)
        {
            GameObject.Find("Canvas/MainMenu/UI/OptionCtrl/Options/LogCtrl/Logs").SetActive(false);
            LogSet++;
            return;
        }
        if (LogSet % 2 == 1)
        {
            
            GameObject.Find("Canvas/MainMenu/UI/OptionCtrl/Options/LogCtrl/Logs").SetActive(true);
            LogSet++;
            return;
        }
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