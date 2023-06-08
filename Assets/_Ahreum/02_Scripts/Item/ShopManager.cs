using TMPro;
using UnityEngine;
public class ShopManager : MonoBehaviour {
    public static ShopManager instance;

    public int coins; // ���� ������
    
    public TMP_Text coinsUI;
    public ItemSO[] shopItemSO;
    public GameObject[] shopPanelSO;
    public ShopTemplate[] shopPanels;
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
    private void MatchItems() { // �������� �ùٸ� ��ġ�� �ֱ�
        for (int i = 0; i < shopItemSO.Length; i++) {
            shopPanels[i].titleText.text = shopItemSO[i].itemName;
            shopPanels[i].iconSprite = shopItemSO[i].itemicon; // <<<<<<<<<<<<<<<<< �̰� ���� �ʿ�
            shopPanels[i].costText.text = "Coins : " + shopItemSO[i].itemCost.ToString();
        }
    }
   
    public void CheckPurchaseBtn() {
        for (int i = 0; i < shopItemSO.Length; i++) {
            if (coins >= shopItemSO[i].itemCost) { // ������ �� ���ٸ�
                purchaseBtn[i].interactable = true; // ��ư Ȱ��ȭ
            }
            else {
                purchaseBtn[i].interactable = false; // ��Ȱ��ȭ
            }
        }
    } // ���� �����ϸ� ��ư Ŭ���� ����
    public void PurchaseItem(int btnNum) {
        if (coins >= shopItemSO[btnNum].itemCost) {
            coins -= shopItemSO[btnNum].itemCost;
            coinsUI.text = "Coins : " + coins;
            CheckPurchaseBtn();
        }
    }
    public void GetCoins() {
        coins += 100;
        coinsUI.text = "Coinis : " + coins.ToString();
        CheckPurchaseBtn();
    }



    /*private void OffAllItemPanel() {
        allItemPanel.SetActive(false);
        foodPanel.SetActive(false);
        extensionPanel.SetActive(false);
    } // �ߵ�
    public void OnAllItemPanel() {
        if(onItemPanel == true) {
            OffAllItemPanel();
        }
        allItemPanel.SetActive(true);
        onItemPanel = true;
    }
    public void OnFoodPanel() {
        if (onItemPanel == true) {
            OffAllItemPanel();
        }
        foodPanel.SetActive(true);
        onItemPanel = true;
    }
    public void OnExtensionPanel() {
        if (onItemPanel == true) {
            OffAllItemPanel();
        }
        extensionPanel.SetActive(true);
        onItemPanel = true;
    }*/
}

// ������ ��� ���� ���Ű� �ȵ�