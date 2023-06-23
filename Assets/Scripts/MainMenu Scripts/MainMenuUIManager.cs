using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    bool firstTimeStarted;

    [SerializeField] private SceneLoadManager sceneManager;
    [SerializeField] private Color disabledBtnColor;
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button exitGameBtn;

    [Header("Continue Btn")]
    [SerializeField] private Button continueGameBtn;
    [SerializeField] private Image continueBtnUperKa;
    [SerializeField] private TMPro.TMP_Text continueBtnText;

    [Header("New-Game Pannel")]
    [SerializeField] private GameObject NewGamePannel;
    [SerializeField] private Button YesBtn;
    [SerializeField] private Button NoBtn;

    [Header("TutorialPannel")]
    [SerializeField] private Image TutorialPannel;
    [SerializeField] private List<Sprite> TutorialSprites;
    [SerializeField] private Button nextButton;
    private int currentIndex = 0;

    [Header("Default Values")]
    [SerializeField] private int defMoney = 10;
    [SerializeField] private int defNumberOfTiles = 1;

    private void Start()
    {
        firstTimeStarted = ES3.Load("FirstTimeStarted", true);

        if(firstTimeStarted)
        {
            continueGameBtn.interactable = false;
            continueBtnUperKa.color = disabledBtnColor;
            continueGameBtn.GetComponent<Image>().color = disabledBtnColor;
            continueBtnText.color = new Color(continueBtnText.color.r, continueBtnText.color.g, continueBtnText.color.b, disabledBtnColor.a);
        }

        continueGameBtn.onClick.AddListener(() => {
            sceneManager.LoadMainGameScene();
        });

        newGameBtn.onClick.AddListener(()=> {
            NewGamePannel.SetActive(true);
        });

        YesBtn.onClick.AddListener(() => {
            SetDefaultSaveValues();
            StartTutorial();
        });

        NoBtn.onClick.AddListener(() => {
            NewGamePannel.SetActive(false);
        });

        exitGameBtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void StartTutorial()
    {
        TutorialPannel.gameObject.SetActive(true);

        nextButton.onClick.AddListener(() => { ShowNextImage(); });
    }

    public void ShowNextImage()
    {
        currentIndex++;
        if (currentIndex >= (TutorialSprites.Count - 1))
            sceneManager.LoadMainGameScene();
        else
            TutorialPannel.sprite = TutorialSprites[currentIndex];

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
