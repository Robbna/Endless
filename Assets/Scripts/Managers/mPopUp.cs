using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mPopUp : MonoBehaviour
{
    private Text popUpMSG;

    void Start()
    {
        gameObject.SetActive(false);
        popUpMSG = GetComponentInChildren<Text>();
    }

    public void showMessage(string msg, float time)
    {
        gameObject.SetActive(true);
        StartCoroutine(messageCoroutine(msg, time));
    }

    private IEnumerator messageCoroutine(string msg, float time)
    {
        popUpMSG.text = msg;
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
