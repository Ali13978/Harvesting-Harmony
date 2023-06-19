using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperNPC : MonoBehaviour
{
    [SerializeField] private GameObject NPCCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        NPCCanvas.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        NPCCanvas.SetActive(false);
    }
}
