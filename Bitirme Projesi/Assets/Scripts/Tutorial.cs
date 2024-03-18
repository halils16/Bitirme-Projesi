using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject birinci, birObj;
    public GameObject ikinci, ikiObj;
    public GameObject ucuncu, ucObj;
    public GameObject dorduncu,dortObj;
    public GameObject besinci;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            birinci.SetActive(false);
            ikinci.SetActive(true);

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "1Obj")
        {
            ikinci.SetActive(false);
            ucuncu.SetActive(true);
            Destroy(ikinci);
            Destroy(birObj);
            Destroy(birinci);

        }

        if (other.gameObject.name == "2Obj")
        {
            ucuncu.SetActive(false);
            Destroy(ucuncu);
            Destroy(ikiObj);

        }

        if (other.gameObject.name == "3Obj")
        {
            dorduncu.SetActive(true);
            StartCoroutine(bekle());
            Destroy(ucObj);
            
        }

        if (other.gameObject.name == "4Obj")
        {
            besinci.SetActive(true);          
            Destroy(dortObj);
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSeconds(6f);
        dorduncu.SetActive(false);
    }
}
