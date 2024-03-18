using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int score;
    public int scoreOut;

    [Header("En Düþük Süre")]
    public Text enDusukSureText;
    private float enDusukSure = Mathf.Infinity;

    [Header("Rekor Süre")]
    public Text rekorText;

    public static Score instance;
    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        score = 0;
        rekorText.text ="Rekor: "+ PlayerPrefs.GetFloat("RecordTime", 0.0f).ToString("F2") + " sn.";
        
    }

    private void Update()
    {
        scoreOut = score;
    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString()+" / 12";
    }

    

    public void YarisiBitir(float tamamlamaSuresi)
    {
        if (tamamlamaSuresi < enDusukSure)
        {
            enDusukSure = tamamlamaSuresi;
            enDusukSureText.text = "Tamamlanan Süre: " + enDusukSure.ToString("F2") + " sn."; //virgüleden sonra iki basamak yazmak için "F2" kullandýk

            if (tamamlamaSuresi < PlayerPrefs.GetFloat("RecordTime", Mathf.Infinity))
            {
                enDusukSure = tamamlamaSuresi;
                PlayerPrefs.SetFloat("RecordTime", enDusukSure);
                rekorText.text = "Rekor: " + enDusukSure.ToString("F2") + " sn.";
            }
        }

        
    }

    public void ResetPP()
    {
        PlayerPrefs.DeleteKey("RecordTime");
        rekorText.text = "Rekor: 0,00 sn.";
    }

}
