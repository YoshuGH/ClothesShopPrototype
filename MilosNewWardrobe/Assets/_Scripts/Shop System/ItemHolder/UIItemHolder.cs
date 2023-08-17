using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemHolder : MonoBehaviour
{
    [SerializeField] private Image _imgRef;
    [SerializeField] private TextMeshProUGUI _txtRef;

    public Button btnItemRef;
    public Button btnBuyRef;

    public void SetItemHolderImage(Sprite image)
    {
        _imgRef.sprite = image;
    }

    public void SetItemHolderText(string name)
    {
        _txtRef.SetText(name);
    }
}
