using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CSpellHoverComponent : MonoBehaviour
{
	public TextMeshProUGUI ToolTipText;
	public RectTransform BackgroundRect;

	[SerializeField]
	private Camera uiCamera;

	private void Update()
	{
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
		transform.localPosition = localPoint;
	}

	public void ShowToolTip(string ToolTipString)
	{
		gameObject.SetActive(true);
		ToolTipText.text = ToolTipString;
		float TextPaddingSize = 4f;
		Vector2 BackgroundSize = new Vector2(ToolTipText.preferredWidth + TextPaddingSize * 2f, ToolTipText.preferredHeight + TextPaddingSize * 2f);
		BackgroundRect.sizeDelta = BackgroundSize;
		//LayoutRebuilder.ForceRebuildLayoutImmediate(BackgroundRect);
	}

	public void HideToolTip()
	{
		gameObject.SetActive(false);
	}
}