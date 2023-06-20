using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSkipDay : MonoBehaviour
{
    [SerializeField] private Button skipDayButton;
    [SerializeField] private CalenderSystem calenderSystem;

    private void Start()
    {
        skipDayButton.onClick.AddListener(() => {
            calenderSystem.SkipDay();
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
