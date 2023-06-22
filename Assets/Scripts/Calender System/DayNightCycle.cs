using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private List<Color> colorList = new List<Color>();
    [SerializeField] private List<float> colorTransitionTime = new List<float>();

    private ColorGrading colorGrading;
    private int currentIndex;
    private int nextIndex;
    private float timer = 0f;

    #region Singleton
    public static DayNightCycle instance;
    private void Awake()
    {
        instance = this;
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }
    #endregion

    private void Start()
    {
        ResetDayNightCycle();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / colorTransitionTime[currentIndex]);

        colorGrading.colorFilter.value = Color.Lerp(colorList[currentIndex], colorList[nextIndex], t);
        

        if (t >= 1f)
        {
            currentIndex = nextIndex;
            nextIndex = (nextIndex + 1) % colorList.Count;

            timer = 0f;
        }
    }

    public void ResetDayNightCycle()
    {
        currentIndex = 0;
        nextIndex = 1;

        colorGrading.colorFilter.value = colorList[currentIndex];
    }

    public void UpdateSeasonalTemperature(List<int> Date)
    {
        if (Date[1] == 1)
            colorGrading.temperature.value = 40f;

        else if (Date[1] == 2)
            colorGrading.temperature.value = 0f;

        else if (Date[1] == 3)
            colorGrading.temperature.value = 100f;

        else if (Date[1] == 4)
            colorGrading.temperature.value = -60f;

    }
}
