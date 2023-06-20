using UnityEngine;
using UnityEngine.EventSystems;

public class SeedDragging : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform imageRectTransform;
    [SerializeField] Vector2 offset = Vector2.zero;
    private Vector3 initialImagePosition;

    private void Start()
    {
        initialImagePosition = imageRectTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Input.mousePosition + (Vector3)offset;
        imageRectTransform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        imageRectTransform.localPosition = initialImagePosition;

        // Check if the image is dropped onto any object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider == null)
            return;
        if (!hit.collider.CompareTag("FarmTile"))
            return;

        TileManager tile = hit.collider.GetComponent<TileManager>();
        SeedsItem SelectedSeed = SeedSelection.instance.GetSelectedSeed();

        if (SelectedSeed == null)
            return;
        if (!tile.isOwned)
            return;

        if(tile.GetTileState() == TileManager.state.Hoed || tile.GetTileState() == TileManager.state.Watered)
        {
            if (tile.GetIsPlanted())
                return;

            tile.PlantSeed(SelectedSeed);
        }

    }

}
