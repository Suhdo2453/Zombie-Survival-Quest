using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI  textMeshPro;
    private float initialFontSize;

    private void Start()
    {
        initialFontSize = textMeshPro.fontSize;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        textMeshPro.fontSize -= 10;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textMeshPro.fontSize = initialFontSize;
    }
}
