using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI.Animators
{
    public class ButtonAnimator : MonoBehaviour, 
        IPointerEnterHandler, IPointerExitHandler, 
        IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private float duration = 0.15f;
        [SerializeField] private Vector3 normalScale = new Vector3(1f, 1f, 1f);
        [SerializeField] private Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1f);
        [SerializeField] private Vector3 pressedScale = new Vector3(0.9f, 0.9f, 1f);

        private UniTask currentTask;
        private bool isAnimating;

        public void OnPointerEnter(PointerEventData eventData)
        {
            AnimateScale(hoverScale).Forget();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            AnimateScale(normalScale).Forget();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            AnimateScale(pressedScale).Forget();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            AnimateScale(hoverScale).Forget();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
        }

        private async UniTask AnimateScale(Vector3 targetScale)
        {
            if (isAnimating) return;
            isAnimating = true;

            Vector3 startScale = transform.localScale;
            float time = 0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                float t = time / duration;
                transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                await UniTask.Yield();
            }

            transform.localScale = targetScale;
            isAnimating = false;
        }
    }
}