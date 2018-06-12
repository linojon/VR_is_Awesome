#if UNITY_EDITOR
using System;
using System.Collections;
using UnityEditor.Experimental.EditorVR;
using UnityEditor.Experimental.EditorVR.Extensions;
using UnityEditor.Experimental.EditorVR.UI;
using UnityEditor.Experimental.EditorVR.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorPickerActivator : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Transform m_TargetScale;

    [SerializeField]
    Transform m_Icon;

    [SerializeField]
    GameObject m_Undo;

    [SerializeField]
    GameObject m_Redo;

    [SerializeField]
    float m_PickerOffset = 0.045f;

    Coroutine m_HighlightCoroutine;
    GradientButton m_UndoButton;
    GradientButton m_RedoButton;

    public Transform rayOrigin { private get; set; }
    public Action<Transform> showColorPicker { private get; set; }
    public Action hideColorPicker { private get; set; }
    public Node node { private get; set; }

    public event Action undoButtonClick
    {
        add { m_UndoButton.click += value; }
        remove { m_UndoButton.click -= value; }
    }

    public event Action redoButtonClick
    {
        add { m_RedoButton.click += value; }
        remove { m_RedoButton.click -= value; }
    }

    void Awake()
    {
        m_UndoButton = m_Undo.GetComponentInChildren<GradientButton>();
        m_UndoButton.normalGradientPair = UnityBrandColorScheme.grayscaleSessionGradient;
        m_UndoButton.highlightGradientPair = UnityBrandColorScheme.sessionGradient;
        m_RedoButton = m_Redo.GetComponentInChildren<GradientButton>();
        m_RedoButton.normalGradientPair = UnityBrandColorScheme.grayscaleSessionGradient;
        m_RedoButton.highlightGradientPair = UnityBrandColorScheme.sessionGradient;
    }

    void Start()
    {
        m_UndoButton.UpdateMaterialColors();
        m_RedoButton.UpdateMaterialColors();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.Use();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        showColorPicker(rayOrigin);
        this.RestartCoroutine(ref m_HighlightCoroutine, Highlight(true));

        m_Undo.SetActive(false);
        m_Redo.SetActive(false);

        eventData.Use();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hideColorPicker();
        this.RestartCoroutine(ref m_HighlightCoroutine, Highlight(false));

        m_Undo.SetActive(true);
        m_Redo.SetActive(true);
    }

    IEnumerator Highlight(bool transitionIn)
    {
        var amount = 0f;
        var currentScale = m_Icon.localScale;
        var targetScale = transitionIn ? m_TargetScale.localScale : Vector3.one;
        var currentPosition = m_Icon.localPosition;
        var targetPosition = transitionIn ? (node == Node.LeftHand ? Vector3.left : Vector3.right) * m_PickerOffset : Vector3.zero;
        var speed = (currentScale.x + 0.5f / targetScale.x) * 4;

        while (amount < 1f)
        {
            amount += Time.unscaledDeltaTime * speed;
            var t = Mathf.SmoothStep(0f, 1f, amount);
            m_Icon.localScale = Vector3.Lerp(currentScale, targetScale, t);
            m_Icon.localPosition = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }

        m_Icon.localScale = targetScale;
    }
}
#endif
