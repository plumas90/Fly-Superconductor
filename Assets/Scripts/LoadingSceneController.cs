using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;
    [SerializeField] Image progressBar;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess() 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false ; // �ε��� 90�۶� ���߰��� = �ε�ȭ�� �����ֱ� �ʹ� ª���� �ִ� �ǹ̰� ���ٰ��� ,
                                          // ���¹��� ���ҽ� �޾ƿ��� �ð�Ȯ�� (���� �ε��� �������� ����)

        float timer = 0f;
        while (!op.isDone) // op�� ������������ �ݺ�
        {
            yield return null; //������� �����༭ �ε��ٰ� ��������
            if (op.progress < 0.9f) //�ε��� 90% �̸��̸� �ε��� ������Ʈ����    
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer); // 0.9���� 1�� 1�ʿ�����ä��
                if (progressBar.fillAmount >= 1f) 
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
