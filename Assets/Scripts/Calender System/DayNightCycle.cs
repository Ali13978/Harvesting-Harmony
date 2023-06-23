using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DayNightCycle : MonoBehaviour
{
    #region Singleton
    public static DayNightCycle instance;
    private void Awake()
    {
        instance = this;
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }
    #endregion
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private List<Color> colorList = new List<Color>();
    [SerializeField] private List<float> transitionTimeList = new List<float>();

    private ColorGrading colorGrading;
    private int currentIndex = 0;
    private int nextIndex = 1;
    private float timer = 0f;
    private bool transitioning = true;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out colorGrading);
        
        colorGrading.colorFilter.value = colorList[currentIndex];
    }

    private void Update()
    {
        if (transitioning)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / transitionTimeList[currentIndex]);

            colorGrading.colorFilter.value = Color.Lerp(colorList[currentIndex], colorList[nextIndex], t);
            
            if (t >= 1f)
            {
                transitioning = false;
                currentIndex = nextIndex;
                nextIndex = (nextIndex + 1) % colorList.Count;

                timer = 0f;
            }
        }
    }

    public void ResetColorFilter(Color resetColor)
    {
        colorGrading.colorFilter.value = resetColor;

        Debug.Log("Day Night Cycle reseted");
        currentIndex = 0;
        nextIndex = 1;
        transitioning = true;
        timer = 0f;
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
