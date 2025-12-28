using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public string loadSceneName;
    public TimeScript timeScript;
    // Start is called before the first frame update
    public Button button;
    void Start()
    {
        FadeOut();
        button.onClick.AddListener(SceneChange);
    }

    // Update is called once per fram
    private void SceneChange()
    {
        StartCoroutine(Fade(0, 1));
    }
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f;

    public void FadeOut()
    {
        StartCoroutine(Fade(1, 0));
    }



    IEnumerator Fade(float start, float end)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(start, end, t);
            yield return null;
        }
        canvasGroup.alpha = end;
        if (end == 1)
        {
            SceneManager.LoadScene(loadSceneName);
        }
        else if (end == 0)
        {
            Time.timeScale = 0;
            timeScript.isStart = true;
        }
    }

}

