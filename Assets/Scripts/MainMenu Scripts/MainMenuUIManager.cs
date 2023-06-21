using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    bool firstTimeStarted;

    [SerializeField] private SceneLoadManager sceneManager;
    [SerializeField] private Color disabledBtnColor;
    [SerializeField] private Button continueGameBtn;
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button exitGameBtn;

    [Header("Default Values")]
    [SerializeField] private int defMoney = 10;
    [SerializeField] private int defNumberOfTiles = 1;

    private void Start()
    {
        firstTimeStarted = ES3.Load("FirstTimeStarted", true);

        if(firstTimeStarted)
        {
            continueGameBtn.interactable = false;
            continueGameBtn.GetComponent<Image>().color = disabledBtnColor;


        }

        continueGameBtn.onClick.AddListener(() => {
            sceneManager.LoadMainGameScene();
        });

        newGameBtn.onClick.AddListener(()=> {

            SetDefaultSaveValues();
            sceneManager.LoadMainGameScene();
        });

        exitGameBtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void SetDefaultSaveValues()
    {
        ES3.DeleteFile();

        ES3.Save("Current Money", defMoney);
        for (int i = 0; i < defNumberOfTiles; i++)
        {
            ES3.Save("Tile" + i + "isOwned", true);
        }
    }



}