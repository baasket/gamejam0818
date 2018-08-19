using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    
    public GameObject mainCanvas;
    public GameObject howToCanvas;
    public GameObject creditCanvas;

    public void loadGameScene()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void displayCredit(){
        mainCanvas.active=false;
        howToCanvas.active=false;
        creditCanvas.active=true;
    }

    public void displayHowTo(){
        mainCanvas.active=false;
        creditCanvas.active=false;
        howToCanvas.active=true;
    }

    public void displayMainCanvas(){
        creditCanvas.active=false;
        howToCanvas.active=false;
        mainCanvas.active=true;
    }
}
