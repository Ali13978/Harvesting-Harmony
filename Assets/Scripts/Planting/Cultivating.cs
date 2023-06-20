using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivating : MonoBehaviour
{
    [SerializeField] TileManager tile;
    [SerializeField] PlayerInventory playerInventory;

    Camera mainCamera;
    BoxCollider2D clickCollider;
    SpriteRenderer cropSpriteRenderer;

    private void Start()
    {
        mainCamera = Camera.main;
        clickCollider = GetComponent<BoxCollider2D>();
        cropSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!clickCollider.enabled)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                playerInventory.AddSeedInInventory(tile.plantedSeed.foodItWillGrow);
                clickCollider.enabled = false;
                tile.isGrown = false;
                tile.isPlanted = false;
                tile.plantedSeed = new SeedsItem();
                tile.BaseTile();
                cropSpriteRenderer.sprite = null;
            }
        }
    }



    public BoxCollider2D GetClickCollider()
    {
        return clickCollider;
    }
}
