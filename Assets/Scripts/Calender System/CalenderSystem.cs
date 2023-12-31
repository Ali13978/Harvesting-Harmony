using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalenderSystem : MonoBehaviour
{
    [SerializeField] AllTilesManager allTilesManager;
    [SerializeField] float secondsInEachDay = 300f;

    private float time = 0;
    private List<int> Date = new List<int> { 1, 1, 2016 };    // Day-Month-Year
    

    // Start is called before the first frame update
    void Start()
    {
        if (!ES3.KeyExists("Date"))
            ES3.Save("Date", Date);

        else
            Date = ES3.Load("Date", new List<int> { 1, 1, 2016 });

        CalenderUI.instance.UpdateDate(Date);
        CalenderUI.instance.UpdateSeason(Date);
        DayNightCycle.instance.UpdateSeasonalTemperature(Date);
        Rain20Percent();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        CalenderUI.instance.UpdateTime(time);

        if (time > secondsInEachDay)
        {
            time = 0f;
            allTilesManager.GrowPlants();
            IncrementDate();
            CalenderUI.instance.UpdateDate(Date);
            CalenderUI.instance.UpdateSeason(Date);
            DayNightCycle.instance.ResetColorFilter(Color.white);
            PlayerFood.instance.ResetStrength();
            GameSaveManager.instance.SaveGame();
            DayNightCycle.instance.UpdateSeasonalTemperature(Date);

            Rain20Percent();
        }
    }

    private void Rain20Percent()
    {
        List<bool> willRainList = new List<bool> { true, false, false, false, false };
        bool willRain = willRainList[Random.Range(0, willRainList.Count)];
        RainManager.instance.SetRaining(willRain);
    }
    
    private void IncrementDate()
    {
        Date[0]++;
        if (Date[0] > 30)
        {
            Date[0] = 1;
            Date[1]++;

            if (Date[1] > 4)
            {
                Date[1] = 1;
                Date[2]++;
            }
        }
    }

    public void SkipDay()
    {
        time = secondsInEachDay - 2;
    }

    public List<int> GetDate()
    {
        return Date;
    }
}
