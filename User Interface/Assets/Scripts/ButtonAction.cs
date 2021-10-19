using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static class AnimatorButtonAction
    {
        public static class Parameters
        {
            public const string MouseEnter = nameof(MouseEnter);
            public const string MouseClick = nameof(MouseClick);
        }
    }

    public void OnButtonClick()
    {
        _animator.SetTrigger(AnimatorButtonAction.Parameters.MouseClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetBool(AnimatorButtonAction.Parameters.MouseEnter, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetBool(AnimatorButtonAction.Parameters.MouseEnter, false);
    }
}
