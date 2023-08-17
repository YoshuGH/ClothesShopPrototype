using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellingShop : ShopBase
{
    [SerializeField] private UIMenuShop menuShop;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _itemHolder;
    [SerializeField] private Button _btnSell;

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

        //Hardcode price value for the sake of simplicity, can be done better
        playerStatsRef.SetStat(StatType.Money, playerStatsRef.GetStat(StatType.Money) + Mathf.Abs(currentClickedItem.price * 0.8f));
        _playerMoneyTxt.SetText(playerStatsRef.GetStat(StatType.Money).ToString("f0"));

        // Remove the item to the inventory
        playerInventoryRef.RemoveItem(currentClickedItem, 1);
        ShowItems();

        //Check if the item exits in the inventory
        if(!playerInventoryRef.Contains(currentClickedItem))
        {
            _itemDisplay.sprite = null;
            _itemTxtPrice.SetText("0");
            _btnSell.interactable = false;
            currentClickedItem = null;
        }
    }

    public override void ShowItems()
    {
        //Delete all holders for simplicity, can do better by storing the references and just poping the values that doesn't exists in the player inventory anymore
        for(int i = 0; i < _container.transform.childCount; i++)
        {
            Destroy(_container.transform.GetChild(i).gameObject);
        }

        foreach (InventorySlot slot in menuShop.PlayerInventory.Inventory.InventorySlots)
        {
            GameObject currentItemHolder = Instantiate(_itemHolder, _container.transform);
            UIItemHolder uIItem = currentItemHolder.GetComponent<UIItemHolder>();
            uIItem.SetItemHolderImage(slot.item.itemSprite);
            uIItem.SetItemHolderText(slot.item.itemName);

            uIItem.btnItemRef.onClick.AddListener(delegate { HandleClickItem(slot.item); });
        }
    }

    private void OnEnable()
    {
        InitalSetup();
    }

    void Start()
    {
        InitalSetup();
    }

    void InitalSetup()
    {
        ShowItems();

        //Set the initial State
        if (menuShop.PlayerInventory.Inventory.InventorySlots.Count > 0)
        {
            UpdateItemDisplay(menuShop.PlayerInventory.Inventory.InventorySlots[0].item);
            currentClickedItem = menuShop.PlayerInventory.Inventory.InventorySlots[0].item;
        }
        else
        {
            _itemDisplay.sprite = null;
            _itemTxtPrice.SetText("0");
            _btnSell.interactable = false;
        }

        StatsManager playerStatsRef = menuShop.PlayerStats;
        _playerMoneyTxt.SetText(playerStatsRef.GetStat(StatType.Money).ToString("f0"));
    }

    void HandleClickItem(ItemBaseSO item)
    {
        UpdateItemDisplay(item);
        currentClickedItem = item;
    }

    void UpdateItemDisplay(ItemBaseSO item)
    {
        _itemDisplay.sprite = item.itemSprite;
        //Hardcode price value for the sake of simplicity, can be done better
        _itemTxtPrice.SetText(Mathf.Abs(item.price * 0.8f).ToString("f0"));
        _btnSell.interactable = true;
    }
}
