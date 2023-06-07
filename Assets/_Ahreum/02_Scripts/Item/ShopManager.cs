using TMPro;
using UnityEngine;
public class ShopManager : MonoBehaviour {
    public int coins; // ���� ������
    public TMP_Text coinsUI;
    public static ShopManager instance;

    public ShopItemSO[] shopItemSO;
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
            Debug.Log(i);
            shopPanelSO[i].SetActive(true);
        }
        coinsUI.text = "Coins : " + coins.ToString();
        MatchItems();
        CheckPurchaseBtn();
    }
    private void MatchItems() { // �������� �ùٸ� ��ġ�� �ֱ�
        for (int i = 0; i < shopItemSO.Length; i++) {
            shopPanels[i].titleText.text = shopItemSO[i].title;
            shopPanels[i].descriptionText.text = shopItemSO[i].description;
            shopPanels[i].costText.text = "Coins : " + shopItemSO[i].baseCost.ToString();
        }
    }
    public void CheckPurchaseBtn() {
        for (int i = 0; i < shopItemSO.Length; i++) {
            if (coins >= shopItemSO[i].baseCost) { // ������ �� ���ٸ�
                purchaseBtn[i].interactable = true; // ��ư Ȱ��ȭ
            }
            else {
                purchaseBtn[i].interactable = false; // ��Ȱ��ȭ
            }
        }
    }
    public void PurchaseItem(int btnNum) {
        if (coins >= shopItemSO[btnNum].baseCost) {
            coins -= shopItemSO[btnNum].baseCost;
            coinsUI.text = "Coins : " + coins;
            CheckPurchaseBtn();
        }
    }



    /* public void BuyItems() {
        coins += 100;
        coinsUI.text = "Coinis : " + coins.ToString();
    }*/
}
