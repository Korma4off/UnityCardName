using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    [SerializeField] private int _lvl;
    public int lvl => _lvl;


    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadData(int lvl)
    {
        _lvl = lvl;
        GameObject.Find("MainCanvas").GetComponent<MainCanvasController>().UpdateCanvas();
    }

    public void SaveData()
    {
        Yandex.Instance.Save(_lvl);
    }

    public void NewGame()
    {
        _lvl = 0;
        SaveData();
    }

    public void LvlUp()
    {
        _lvl++;
        SaveData();

        int lvl = _lvl + 1;
        lvl = lvl < 7 ? lvl : 6;

        SceneManager.LoadScene(lvl);
    }

}
