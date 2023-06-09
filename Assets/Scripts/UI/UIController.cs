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
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        initialFontSize = textMeshPro.fontSize;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        textMeshPro.fontSize -= 10;
        SoundManager.Instance.PlaySFX("Click", false);        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textMeshPro.fontSize = initialFontSize;
    }
}
