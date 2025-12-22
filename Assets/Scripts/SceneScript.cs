using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public string loadSceneName;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SceneChange);
    }

    // Update is called once per fram
    private void SceneChange()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}

