using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour {
    public TextMeshProUGUI bestScoreText;
   
    private void Start() {
        if (SaveManager.Instance != null) {
            SaveManager.Instance.LoadHighScore();
            if (SaveManager.Instance.HighScore > 0) {
                bestScoreText.text = "Best Score: " + SaveManager.Instance.Name + " : " + SaveManager.Instance.HighScore;
            }
            else {
                bestScoreText.text = "Best Score: N/A";
            }
        }

    }

    public void SetPlayerName(string name) {
        SaveManager.Instance.Name = name;
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
