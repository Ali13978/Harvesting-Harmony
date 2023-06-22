using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSkipDay : MonoBehaviour
{
    [SerializeField] private Button skipDayButton;
    [SerializeField] private CalenderSystem calenderSystem;

    [Header("Transition-Image")]
    [SerializeField] private ManageTransition transitionImage;

    private void Start()
    {
        skipDayButton.onClick.AddListener(() => {
            calenderSystem.SkipDay();
            transitionImage.StartTransition();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            skipDayButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            skipDayButton.gameObject.SetActive(false);
        }
    }
}
