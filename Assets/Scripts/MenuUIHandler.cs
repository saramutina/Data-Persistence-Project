using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour {
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInputField;

    private void Start() {
        if (SaveManager.Instance != null) {

            SaveManager.Instance.LoadHighScore();
            nameInputField.text = SaveManager.Instance.CurrentName;

            if (SaveManager.Instance.HighScore > 0) {
                bestScoreText.text = "Best Score: \n" + SaveManager.Instance.Name + " : " + SaveManager.Instance.HighScore;
            }
            else {
                bestScoreText.text = "Best Score: N/A";
            }
        }

    }

    public void SetPlayerName() {
        SaveManager.Instance.CurrentName = nameInputField.text;
    }

    public void StartNew() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}
