using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour,IDragHandler,IEndDragHandler,IPointerDownHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private Vector3 originalPosition;
        private Vector3 originalAnchorPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

    

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            originalAnchorPosition =rectTransform.anchoredPosition;
            originalPosition =rectTransform.position;
        }
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(rectTransform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetPosition();
            owner.MonkeyDroppedAt(eventData.position);
        }

        
        void ResetPosition()
        {
            rectTransform.anchoredPosition = originalAnchorPosition;
            rectTransform.position =originalPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
            monkeyImage.color = new Color(1,1,1,1f);

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1,1,1,0.6f);
        }
    }
}