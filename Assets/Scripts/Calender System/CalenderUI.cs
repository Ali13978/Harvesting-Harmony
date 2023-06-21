using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalenderUI : MonoBehaviour
{
    #region singleton
    public static CalenderUI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] TMP_Text Time;
    [SerializeField] TMP_Text Date;
    [SerializeField] TMP_Text Season;

    public void UpdateDate(List<int> date)
    {
        Date.text = "Date: " + date[0] + "-" + date[1] + "-" + date[2];
    }

    public void UpdateTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        Time.text = "Time: " + formattedTime;
    }

    public void UpdateSeason(List<int> date)
    {
        string season = null;

        if (date[1] == 1)
            season = "Summer";
        else if (date[1] == 2)
            season = "Spring";
        else if (date[1] == 3)
            season = "Autumn";
        else if(date[1] == 4)
            season = "Winter";

        Season.text = "Season: " + season;
    }
}
