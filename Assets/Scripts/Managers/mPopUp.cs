using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mPopUp : MonoBehaviour
{
    [SerializeField] private Text popUpMSG;
    [SerializeField] private GameObject canvas;
    public static mPopUp inst;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        popUpMSG.text = "";
        canvas.SetActive(false);
    }

    public void showMessage(string msg)
    {
        canvas.SetActive(true);
        popUpMSG.text = msg;
        Invoke("hidePopUp", 2);
    }

    private void hidePopUp(){
        canvas.SetActive(false);
    }
}
