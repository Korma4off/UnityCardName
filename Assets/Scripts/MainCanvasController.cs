using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{

    [SerializeField] private GameObject _newGameButton;
    [SerializeField] private GameObject _resumeButton;

    [SerializeField] private Text _lvlText;

    private void Start()
    {
        UpdateCanvas();
    }
    public void UpdateCanvas()
    {
        if (PlayerData.Instance.lvl == 0) 
        { 
            _resumeButton.SetActive(false); 
        }
        else
        {
            _resumeButton.SetActive(true);
        }
        _lvlText.text = (PlayerData.Instance.lvl + 1).ToString();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerData.Instance.NewGame();
    }

    public void ResumeGame()
    {
        int lvl = PlayerData.Instance.lvl + 1;
        lvl = lvl < 7 ? lvl : 6;

        SceneManager.LoadScene(lvl);
    }
}
