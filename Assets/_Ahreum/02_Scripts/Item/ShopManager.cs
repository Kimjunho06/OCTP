using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    public static ShopManager instance;

    public int coins; // 현재 보유량
    
    public TMP_Text coinsUI;
    public ItemSO[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelSO;
    public GameObject[] shopItemImage;
    public UnityEngine.UI.Button[] purchaseBtn;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        for (int i = 0; i < shopItemSO.Length; i++) {
            shopPanelSO[i].SetActive(true);
        }
        coinsUI.text = "Coins : " + coins.ToString();
        MatchItems();
        CheckPurchaseBtn();
    }
    private void MatchItems() { // 아이템을 올바른 위치에 넣기
        for (int i = 0; i < shopItemSO.Length; i++) {
            shopPanels[i].titleText.text = shopItemSO[i].itemName;
            shopItemImage[i].GetComponent<Image>().sprite = shopItemSO[i].itemicon;
            shopPanels[i].costText.text = "Coins : " + shopItemSO[i].itemCost.ToString();
        }
    }
   
    public void CheckPurchaseBtn() { // 가격확인하기
        for (int i = 0; i < shopItemSO.Length; i++) {
            if (coins >= shopItemSO[i].itemCost) { // 코인이 더 많다면
                purchaseBtn[i].interactable = true; // 버튼 활성화
            }
            else {
                purchaseBtn[i].interactable = false; // 비활성화
            }
        }
    } 

    public void PurchaseItem(int btnNum) { // 구매하기
        if (coins >= shopItemSO[btnNum].itemCost) {
            coins -= shopItemSO[btnNum].itemCost;
            coinsUI.text = "Coins : " + coins;
            CheckPurchaseBtn();
        }
    }

    /*private void OffAllItemPanel()
    {
        allItemPanel.SetActive(false);
        foodPanel.SetActive(false);
        extensionPanel.SetActive(false);
    } // 잘됨
    public void OnAllItemPanel()
    {
        if (onItemPanel == true)
        {
            OffAllItemPanel();
        }
        allItemPanel.SetActive(true);
        onItemPanel = true;
    }
    public void OnFoodPanel()
    {
        if (onItemPanel == true)
        {
            OffAllItemPanel();
        }
        foodPanel.SetActive(true);
        onItemPanel = true;
    }
    public void OnExtensionPanel()
    {
        if (onItemPanel == true)
        {
            OffAllItemPanel();
        }
        extensionPanel.SetActive(true);
        onItemPanel = true;
    }*/
}