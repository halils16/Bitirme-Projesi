using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Sayaç")]
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;

    [Header("Geri Sayým")]
    public float countdown;
    public Text countdownText;
    public GameObject GeriSayimEkrani;

    [Header("Bitiþ")]
    public GameObject ScorePanel;

    [SerializeField] private int lap;
    [SerializeField] private int scoreIn;


    public static Timer instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
        //countdown = 4f;
 
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (timeIsRunning)
        {
            if (countdown <= -1)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
            }
            
        }

        CountdownToRace();

        scoreIn = Score.instance.scoreOut;
        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lap++;           

            if (lap >= 2 & scoreIn==12)
            {
                timeIsRunning = false;
                ScorePanel.SetActive(true);
                Score.instance.YarisiBitir(timeRemaining);
            }

        }
    }

    private void CountdownToRace()
    {
        countdownText.text = countdown.ToString("F0");

        if (countdown < 0.5f)
        {
            countdownText.text = "BAÞLA!";

            if (countdown <= -0.5f) 
                GeriSayimEkrani.SetActive(false);
        }
        
    }


}
