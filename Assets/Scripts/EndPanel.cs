using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score;
    public TextMeshProUGUI BestScore;

    public GameObject rank;
    public TextMeshProUGUI rankText;
    private Image image;

    private int languageType;

    private void OnEnable()
    {
        image = rank.GetComponent<Image>();
        score.text = GameManager.Instance.score.ToString();
        if (PlayerPrefs.HasKey("Best"))
        {
            BestScore.text = PlayerPrefs.GetInt("Best").ToString();
            if (GameManager.Instance.score > PlayerPrefs.GetInt("Best"))
            {
                PlayerPrefs.SetInt("Best", GameManager.Instance.score);
                PlayerPrefs.Save();
            }

        }
        else
        {
            BestScore.text = 0.ToString();
            if (GameManager.Instance.score > PlayerPrefs.GetInt("Best"))
            {
                PlayerPrefs.SetInt("Best", GameManager.Instance.score);
                PlayerPrefs.Save();
            }
        }

        if (PlayerPrefs.HasKey("Language"))
        {
            languageType = PlayerPrefs.GetInt("Language");
        }
        else
        {
            languageType = 1;
        }

        if (GameManager.Instance.score < 100)
        {
            if (languageType == 1)
            {
                rankText.text = "불안정한 초전도체";
            }
            else if (languageType == 2)
            {
                rankText.text = "Unstable\nSuperconductor";
            }
            image.color = Color.white;
        }
        else if (GameManager.Instance.score >= 100 && GameManager.Instance.score < 300)
        {
            if (languageType == 1)
            {
                rankText.text = "상온 초전도체";
            }
            else if (languageType == 2)
            {
                rankText.text = "temperature\nSuperconductor";
            }
            image.color = Color.gray;
        }
        else
        {
            int type = PlayerPrefs.GetInt("Language");
            if (languageType == 1)
            {
                rankText.text = "완벽한 초전도체";
            }
            else if (languageType == 2)
            {
                rankText.text = "Perpect\nSuperconductor";
            }
            image.color = Color.yellow;
        }
        rankText.text = rankText.text.Replace("\\n", "\n");
    }

    public void MainBTN() 
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ReBTN()
    {
        SceneManager.LoadScene("MainScene");
    }
}
