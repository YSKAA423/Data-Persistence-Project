using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainUiHandler : MonoBehaviour
{

    public TMP_InputField nameField;
    public TextMeshProUGUI score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DataMainManager.Instance != null)
        {
            score.text = $"Best Score: {DataMainManager.Instance.highScore}";
            nameField.text = DataMainManager.Instance.userName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveName()
    {
        if (DataMainManager.Instance != null)
        {
            DataMainManager.Instance.userName = nameField.text;
            DataMainManager.Instance.saveUserInfo();
        }

        SceneManager.LoadScene("main");
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit()
#endif

    }
}
