using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public Text textHolder;
    public int killCount;

    private void Update()
    {
        textHolder.text = killCount.ToString();
    }
}
