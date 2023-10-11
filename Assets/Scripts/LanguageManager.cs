using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public TextMeshProUGUI flytext;
    public TextMeshProUGUI Superconductortext;
    public GameObject LanguagePanel;
    LanguageManager Instance;
    void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            int type = PlayerPrefs.GetInt("Language");
            if (type==1)
            {
                flytext.text= "날아라";
                Superconductortext.text = "초전도체";
            }
            else if (type==2) 
            {
                flytext.text = "FLY";
                Superconductortext.text = "Superconductor";
            }

        }
        else
        {
            PlayerPrefs.SetInt("Language", 1);
            PlayerPrefs.Save();
        }
    }

    public void SeeLanguageBtn() 
    {
        LanguagePanel.SetActive(true);
    }

    public void ChoiceKorea()
    {
        PlayerPrefs.SetInt("Language", 1);
        flytext.text = "날아라";
        Superconductortext.text = "초전도체";
        PlayerPrefs.Save();
        LanguagePanel.SetActive(false);
    }
    public void ChoiceEnglish()
    {
        PlayerPrefs.SetInt("Language", 2);
        flytext.text = "FLY";
        Superconductortext.text = "Superconductor";
        PlayerPrefs.Save();
        LanguagePanel.SetActive(false);
    }

}
