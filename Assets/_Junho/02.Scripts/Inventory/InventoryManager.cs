using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager Instance;

    public InventoryGrid selectedItemGrid;

    [SerializeField] List<ItemSO> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform canvasTransform;

    [SerializeField] GameObject inventoryPanel;
    [Header("inventory Select Panel"), Space(10)]
    [SerializeField] GameObject inventorySelectPanel;
    [SerializeField] Image inventorySelectImage;
    [SerializeField] UnityEngine.UI.Button inventoryMoveBtn;
    [SerializeField] UnityEngine.UI.Button inventoryLooseBtn;
    [SerializeField] UnityEngine.UI.Button inventoryDeleteBtn;

    [Header("inventory Move Panel")]
    [SerializeField] UnityEngine.UI.Button inventoryRightRotateBtn;
    [SerializeField] UnityEngine.UI.Button inventoryLeftRotateBtn;
    [SerializeField] Image inventoryMoveImage;

    private InventoryItem selectedItem;
    private InventoryItem overlapItem;
    private RectTransform rectTransform;

    private bool isMove = false;
    private bool isActive = false;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Multy InventoryManager");
        }
        Instance = this;
    }

    private void Start() {
        inventoryLeftRotateBtn.onClick.AddListener(() => RotateItem(-1));
        inventoryRightRotateBtn.onClick.AddListener(() => RotateItem(1));

        inventoryDeleteBtn.onClick.AddListener(() => {
            inventorySelectPanel.SetActive(false);
            Vector2Int select = new Vector2Int(selectedItem.onGridPositionX, selectedItem.onGridPositionY);
            PlaceItem(select);
            selectedItem = null;
        });

        inventoryLooseBtn.onClick.AddListener(LooseItem);
        inventoryMoveBtn.onClick.AddListener(MoveItem);

        // isActive = inventoryPanel.activeSelf;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Q)) {
            CreateRandomItem();
        }

        if (selectedItemGrid == null) return; // 인벤토리 칸이 없다면 실행 안시키기 위함

        if (Input.GetMouseButtonDown(0)) {
            LeftMouseButtonPress();
            SelectItem(selectedItem);
        }

        // isActive = !inventoryPanel.activeSelf;
    }

    private void OnInventory() => inventoryPanel.SetActive(isActive);

    private void RotateItem(int clockwise = 1) // 아이템 회전
    {
        Vector2Int before = new Vector2Int(selectedItem.onGridPositionX, selectedItem.onGridPositionY);
        InventoryItem beforeItem = selectedItem;

        if (selectedItem == null) { return; } // 집은 아이템이 없다면 실행 안함
        selectedItemGrid.OverlapCheck(selectedItem.onGridPositionX, selectedItem.onGridPositionY, selectedItem.HEIGHT, selectedItem.WIDTH, ref overlapItem);

        if (overlapItem != null) {
            print("겹침");
            return;
        }
        else {
            selectedItem.Rotate(clockwise);
            print("안겹침");
        }

        PlaceItem(before);
        selectedItem = beforeItem;
        PickUpItem(before);

        MoveItem();
    }

    private void CreateRandomItem() // 랜덤 아이템 생성 테스트용
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem; // 아이템 집었다 판정

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);

        int selectedItemID = UnityEngine.Random.Range(0, items.Count);
        inventoryItem.Set(items[selectedItemID]);
    }

    private void LeftMouseButtonPress() {
        Vector2 position = Input.mousePosition;

        if (selectedItem != null) // 아이템을 집었다면
        {
            position.x -= (selectedItem.WIDTH - 1) * InventoryGrid.tileSizeWidth / 2;
            position.y += (selectedItem.HEIGHT - 1) * InventoryGrid.tileSizeHeight / 2;
        }

        Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(position); // 마우스 위치 받아오기 

        print(tileGridPosition);

        if (selectedItem == null) // 아이템을 안집었다면
        {
            PickUpItem(tileGridPosition); // 아이템 집기
        }
        else // 아이템을 집었다면
        {
            if (isMove) {
                PlaceItem(tileGridPosition); // 아이템 위치 정하기
            }
        }
    }

    private void PlaceItem(Vector2Int tileGridPosition) // 아이템 위치 두기
    {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem); // 집은 아이템을 두었는가

        if (complete) // 집은 아이템을 뒀다면
        {
            selectedItem = null; // 집은 아이템 없애기

            isMove = false;
            inventoryMoveImage.sprite = null;

            if (overlapItem != null) // 중복된 위치에 아이템이 있다면
            {
                selectedItem = overlapItem; // 손에 집기
                overlapItem = null; // 중복될 아이템 없애기
                rectTransform = selectedItem.GetComponent<RectTransform>(); // 이동 시키도록 transform 받아오기

                // 놓았을 때 겹친 아이템 select창 띄우고 이미지 띄우기 
            }
        }

    }

    private void PickUpItem(Vector2Int tileGridPosition) // 아이템 집기 만약 집었다면 이동을 위한 transform 가져오기
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem != null) {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    private void SelectItem(InventoryItem select) {
        if (selectedItem != null && isMove == false) {
            inventorySelectPanel.SetActive(true);
            selectedItem = select;
            inventorySelectImage.sprite = selectedItem.itemData.itemicon;
        }
    }

    private void LooseItem() {
        inventorySelectPanel.SetActive(false);
        Destroy(selectedItem.gameObject);
    }

    private void MoveItem() {
        isMove = true;
        inventorySelectPanel.SetActive(false);
        inventoryMoveImage.sprite = selectedItem.itemData.itemicon;

        // 밖을 누르면 loose 시키기
    }
}
