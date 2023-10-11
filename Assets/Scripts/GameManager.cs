using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score=0;
    public TextMeshProUGUI ScoreText;

    public float regenTime = 2f;
    public float minHeight = -2.5f;
    public float maxHeight = 1.1f;

    public GameObject wall;
    public static GameManager Instance;

    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject EndPanel;

    public bool IsDead=false;
    // Start is called before the first frame update
    void Start()
    {    
        Instance = this;
        score= 0;
        StartCoroutine(MakeWall());
        playerSkill.SetActive(true);
    }
    public void End()
    {
        playerSkill.SetActive(false);
        EndPanel.SetActive(true);
    }

    public void ScoreUpdate()
    {
        score++;
        if (score >= 999) { score = 999; }
        ScoreText.text = score.ToString();
    }
    IEnumerator MakeWall() 
    {
        while (!GameManager.Instance.IsDead)
        {
            new WaitForSeconds(regenTime);
            Instantiate(wall, new Vector3(4f, Random.Range(minHeight, maxHeight), 0), Quaternion.identity);

            yield return new WaitForSeconds(regenTime);
        }
    }
}
