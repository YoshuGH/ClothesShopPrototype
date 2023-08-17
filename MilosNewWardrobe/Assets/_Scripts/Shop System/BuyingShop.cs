using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyingShop : ShopBase
{
    [SerializeField] private UIMenuShop menuShop;
    [SerializeField] private InventorySO _storeStock;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _itemHolder;

    [Header("Item Visualizer"), SerializeField]
    private Image _itemDisplay;
    [SerializeField] private TextMeshProUGUI _itemTxtPrice;

    [Header("Player Money Display"), SerializeField]
    private TextMeshProUGUI _playerMoneyTxt;

    private ItemBaseSO currentClickedItem;

    public override void TryPerformTransction()
    {
        StatsManager playerStatsRef = menuShop.PlayerStats;
        InventoryManager playerInventoryRef = menuShop.PlayerInventory;
        if (playerStatsRef.GetStat(StatType.Money) >= currentClickedItem.price)
        {
            playerStatsRef.SetStat(StatType.Money, playerStatsRef.GetStat(StatType.Money) - currentClickedItem.price);
            _playerMoneyTxt.SetText(playerStatsRef.GetStat(StatType.Money).ToString("f0"));

            // Add the item to the inventory
            playerInventoryRef.AddItem(currentClickedItem, 1);
        }
        else
        {
            // Do some feedback
        }
    }

    public override void ShowItems()
    {
        foreach(InventorySlot slot in _storeStock.InventorySlots)
        {
            GameObject currentItemHolder = Instantiate(_itemHolder, _container.transform);
            UIItemHolder uIItem = currentItemHolder.GetComponent<UIItemHolder>();
            uIItem.SetItemHolderImage(slot.item.itemSprite);
            uIItem.SetItemHolderText(slot.item.itemName);

            uIItem.btnItemRef.onClick.AddListener(delegate { HandleClickItem(slot.item); });
            uIItem.btnBuyRef.onClick.AddListener(delegate { HandleBuyClickItem(slot.item); });
        }
    }

    void Start()
    {
        ShowItems();
        UpdateItemAvailability();

        //Set the initial State
        _itemDisplay.sprite = _storeStock.InventorySlots[0].item.itemSprite;
        _itemTxtPrice.SetText(_storeStock.InventorySlots[0].item.price.ToString("f0"));
        StatsManager playerStatsRef = menuShop.PlayerStats;
        _playerMoneyTxt.SetText(playerStatsRef.GetStat(StatType.Money).ToString("f0"));

        currentClickedItem = _storeStock.InventorySlots[0].item;
    }

    void HandleClickItem(ItemBaseSO item)
    {
        UpdateItemDisplay(item);
        currentClickedItem = item;
    }

    void HandleBuyClickItem(ItemBaseSO item)
    {
        currentClickedItem = item;
        UpdateItemDisplay(item);
        TryPerformTransction();
    }

    void UpdateItemAvailability()
    {
        StatsManager playerStatsRef = menuShop.PlayerStats;
        for (int i = 0; i < _container.transform.childCount; i++)
        {
            if(playerStatsRef.GetStat(StatType.Money) < _storeStock.InventorySlots[i].item.price)
            {
                Transform currentChild = _container.transform.GetChild(i);
                currentChild.gameObject.GetComponent<UIItemHolder>().btnBuyRef.interactable = false;
            }
        }
    }

    void UpdateItemDisplay(ItemBaseSO item)
    {
        _itemDisplay.sprite = item.itemSprite;
        _itemTxtPrice.SetText(item.price.ToString("f0"));
    }
}
