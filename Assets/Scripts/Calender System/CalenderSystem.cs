using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderSystem : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        CalenderUI.instance.UpdateTime(time);

        if (time > secondsInEachDay)
        {
            time = 0f;
            IncrementDate();
            CalenderUI.instance.UpdateDate(Date);
            GameSaveManager.instance.SaveGame();
        }
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


    public List<int> GetDate()
    {
        return Date;
    }
}
