using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;

public class Data
{
    public int lvl;
}
public class Yandex : MonoBehaviour
{
    public static Yandex Instance;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern void Ready();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void WatchAd();

    [DllImport("__Internal")]
    private static extern void WatchReward();

    [DllImport("__Internal")]
    private static extern void GetLang();
    public string lang = "";

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
    private void Start()
    {
        Ready();
        LoadExtern();
        GetLang();
    }
    public void Save(int lvl)
    {
        Data obj = new Data();
        obj.lvl = lvl;
        SaveExtern(JsonUtility.ToJson(obj));
    }

    public void LoadData(string data)
    {
        Data obj = JsonUtility.FromJson<Data>(data);
        PlayerData.Instance.LoadData(obj.lvl);
    }

    public void Rate()
    {
        RateGame();
    }
    public void Ad()
    {
        WatchAd();
    }

    public void EndOfAd()
    {
    }

    public void RewardAd()
    {
        WatchReward();
    }

    public void Reward()
    {
    }

    public void NotReward()
    {
    }

    public void SetLang(string _lang)
    {
        lang = _lang;
    }
}
