using UnityEngine;
using UnityEngine.EventSystems;

public class ToolDragging : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform imageRectTransform;
    [SerializeField] Vector2 offset = Vector2.zero;

    private Vector3 initialImagePosition;
    private AudioSource audioSource;

    private void Start()
    {
        initialImagePosition = imageRectTransform.localPosition;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Input.mousePosition + (Vector3) offset;
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
        ToolsItem SelectedTool = ToolSelection.instance.GetSelectedTool();

        if (SelectedTool == null)
            return;
        if (!tile.isOwned)
            return;
        if (!(PlayerFood.instance.GetStrength() >= SelectedTool.strengthReq))
            return;

        PlayerFood.instance.UpdateStrength(-1 * SelectedTool.strengthReq);

        audioSource.clip = SelectedTool.SFX;
        audioSource.Play();

        if (SelectedTool.ToolType == ToolsItem.tool.Hoe)
        {
            if (!(tile.GetTileState() == TileManager.state.Basic))
                return;


            tile.HoeTile();
        }
        else
        {
            if (!(tile.GetTileState() == TileManager.state.Hoed))
                return;
            tile.WaterTile();
        }
        
    }

}
