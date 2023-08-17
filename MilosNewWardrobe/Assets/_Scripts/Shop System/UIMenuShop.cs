using UnityEngine;

public class UIMenuShop : MonoBehaviour
{
    [SerializeField, Header("Panels")] private GameObject _pnlMainShop;
    [SerializeField] private GameObject _pnlButtons;
    [SerializeField] private GameObject _pnlShopBuy;
    [SerializeField] private GameObject _pnlShopSell;

    [SerializeField, Space] private InputReader _inputReader;

    [Header("Events")]
    [SerializeField] private ShopEventChannelSO _onOpenShop;

    private InventoryManager playerInventoryRef;
    private StatsManager playerStatsRef;

    public StatsManager PlayerStats { get => playerStatsRef; }
    public InventoryManager PlayerInventory { get => playerInventoryRef; }

    private void OnEnable()
    {
        _onOpenShop.OnEventRaised += HandleOpenShop;
    }

    private void OnDisable()
    {
        _onOpenShop.OnEventRaised -= HandleOpenShop;
    }

    private void Awake()
    {
        _pnlMainShop.SetActive(false);
    }

    #region Button Funtions

    public void OpenMainShop()
    {
        _inputReader.SetMenusInput();
        _pnlMainShop.SetActive(true);
        DisableAllPanels();
        _pnlButtons.SetActive(true);
    }

    public void CloseMainShop()
    {
        _inputReader.SetGameplayInput();
        _pnlMainShop.SetActive(false);
        playerInventoryRef = null;
        playerStatsRef = null;
    }

    public void OpenBuyPage()
    {
        DisableAllPanels();
        _pnlShopBuy.SetActive(true);
    }

    public void OpenSellPage()
    {
        DisableAllPanels();
        _pnlShopSell.SetActive(true);
    }

    public void ReturnMainShop()
    {
        DisableAllPanels();
        _pnlButtons.SetActive(true);
    }

    #endregion

    void HandleOpenShop(InventoryManager inventory, StatsManager stats)
    {
        OpenMainShop();
        playerInventoryRef = inventory;
        playerStatsRef = stats;
    }

    void DisableAllPanels()
    {
        _pnlButtons.SetActive(false);
        _pnlShopBuy.SetActive(false);
        //_pnlShopSell.SetActive(false);
    }
}
