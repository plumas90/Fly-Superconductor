using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBTN : MonoBehaviour
{
    public GameObject recordPanel;
    public TextMeshProUGUI BestScore;
    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RecordBtn()
    {
        recordPanel.SetActive(true);
        BestScoreUpdate();
    }
    public void RecordOffBtn()
    {
        recordPanel.SetActive(false);
    }
    public void BestScoreUpdate() 
    {
        if (PlayerPrefs.HasKey("Best"))
        {
            BestScore.text = PlayerPrefs.GetInt("Best").ToString();

        }
    }
}
