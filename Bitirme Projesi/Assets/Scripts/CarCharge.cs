using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarCharge : MonoBehaviour
{
    public TextMeshProUGUI ChargeText;
    public TextMeshProUGUI sarjYuzde;

    public AudioSource ChargeSound;

    public GameObject engel;

    public float sayac;
    public Slider sarj;
    

    public static CarCharge instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sayac = sarj.value;
    }

    private void Update()
    {
        if (sarj.value >= 15)
        {
            sayac -= Time.deltaTime;
            sarj.value = sayac;
            sarjYuzde.color = Color.green;
            sarjYuzde.text = "Araba Þarjý: %" + ((int)(sarj.value/3)).ToString();
        }

        if (sarj.value < 15)
        {
            sayac -= Time.deltaTime*0.5f;
            sarj.value = sayac;           
            sarjYuzde.color = Color.red;
            sarjYuzde.text = "Düþük Güç Modu: %" + ((int)(sarj.value / 3)).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChargeSound.Play();
            ChargeText.gameObject.SetActive(true);
            ChargeText.text = "Þarj Ediliyor";           
            StartCoroutine(anim());
            StartCoroutine(Charging());
        }
    }


    IEnumerator Charging()
    {
        yield return new WaitForSecondsRealtime(4.6f);
        ChargeText.text = "Þarj Edildi";
        sayac = 303;
        engel.SetActive(false);        
        yield return new WaitForSecondsRealtime(3f);
        ChargeText.gameObject.SetActive(false);
        
    }

    IEnumerator anim()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor.";
        sayac = 70;
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor..";
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor...";
        sayac = 140;
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor.";
        yield return new WaitForSecondsRealtime(0.5f);
        sayac = 210;
        ChargeText.text = "Þarj Ediliyor..";
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor...";
        yield return new WaitForSecondsRealtime(0.5f);
        sayac = 280;
        ChargeText.text = "Þarj Ediliyor.";
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor..";
        yield return new WaitForSecondsRealtime(0.5f);
        ChargeText.text = "Þarj Ediliyor...";
        sayac = 303;
    }


}
