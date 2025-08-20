using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.UI.Popups
{
    public class CardPopupUIPresenter : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private RectTransform _cardRoot;
        [SerializeField] private Image _itemImage;
        [SerializeField] private RectTransform _maskRect;
        [SerializeField] private TextMeshProUGUI _itemNameTmp;
        [SerializeField] private TextMeshProUGUI _itemCountTmp;
        [SerializeField] private TextMeshProUGUI _itemIdTmp;
    
        [Header("Item Data")]
        private string _itemId;
        private int _itemCount;

        [Header("Anim")]
        [SerializeField] private float _dur = 1.2f;
        [SerializeField] private float _maskMoveTargetX = 150f;
        [SerializeField] private float _itemMaxScale = 4f;
        [SerializeField] private float _cardMaxScale = 2f;



        private Quaternion _defaultRotation;
        private Vector3 _defaultScale;
        private Vector2 _defaultMaskPosX;
        private Sequence _cardSeq;

        // Initialize default values and subscribe to events
        void Awake()
        {
            _defaultRotation = _cardRoot.localRotation;
            _defaultScale = _itemImage.rectTransform.localScale;
            _defaultMaskPosX = _maskRect.anchoredPosition;

            GlobalBus.Instance.Subscribe<ShowCardPopupEvent>(OnShowCard);
        }

        // Unsubscribe from events to prevent memory leaks
        private void OnDestroy()
        {
            GlobalBus.Instance.Unsubscribe<ShowCardPopupEvent>(OnShowCard);
        }

        // Display the card popup with the provided data
        private void OnShowCard(ShowCardPopupEvent evt)
        {
            _cardRoot.gameObject.SetActive(true);
            SetItemData(evt.Icon, evt.Name,evt.RewardCount,evt.ItemId);
            PlaySequence();
        }

        // Reset the card and publish related events
        private void OnHideCard()
        {
            _cardRoot.localRotation = _defaultRotation;
            _itemImage.rectTransform.localScale = _defaultScale;
            _maskRect.anchoredPosition = _defaultMaskPosX;

            if (int.Parse(_itemId) == 9)
            {
                GlobalBus.Instance.Publish(new OpenBombPanelEvent(true));
            }
            else
            {
                GlobalBus.Instance.Publish(new RouletteItemDataEvent(_itemId,_itemCount,_itemImage.sprite));
                GlobalBus.Instance.Publish(new AddZoneNumberEvent(1));
            }
            _cardRoot.gameObject.SetActive(false);

        }

        // Assign the item data to UI elements
        public void SetItemData(Sprite itemIcon, string itemName,int itemCount,string itemId)
        {
            _itemCount = itemCount;
            _itemImage.sprite = itemIcon;
            _itemNameTmp.text = itemName;
            _itemCountTmp.text = "x" + itemCount;
            _itemId = itemId;
            _itemIdTmp.text = "ID:" + itemId;
        }

        // Play the card popup animation sequence
        public void PlaySequence()
        {
            _cardSeq?.Kill();

            _cardSeq = DOTween.Sequence()
                .Append(_cardRoot.DORotate(new Vector3(0, 0, 720f), _dur, RotateMode.FastBeyond360).SetEase(Ease.OutCubic))
                .Join(_cardRoot.transform.DOScale(_cardMaxScale, _dur).SetEase(Ease.OutBack).SetLoops(2, LoopType.Yoyo))
                .Append(_itemImage.rectTransform.DOScale(_itemMaxScale, _dur * 0.5f).SetEase(Ease.OutBack))
                .Append(_maskRect.DOAnchorPosX(_maskMoveTargetX, _dur).SetEase(Ease.OutQuad))
                .OnComplete(OnHideCard);
        }
    }
}