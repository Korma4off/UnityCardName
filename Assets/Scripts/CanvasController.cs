using UnityEngine.SceneManagement;

using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private float _timer = 0;
    [SerializeField] private Text _timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 4)
        {
            Yandex.Instance.Rate();
        }
        else if (scene > 4)
        {
            Yandex.Instance.Ad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _timerText.text = StringFormating(_timer / 60) + ":" + StringFormating(_timer % 60);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    private string StringFormating(float val)
    {
        val = Convert.ToInt32(val);
        string str = val.ToString();
        if (str.Length == 1)
        {
            str = "0" + str;
        }
        return str;
    }
}
