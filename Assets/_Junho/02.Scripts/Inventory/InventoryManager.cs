using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
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


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multy InventoryManager");
        }
        Instance = this;
    }

    private void Start()
    {
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

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateRandomItem();
        }

        if (selectedItemGrid == null) return; // �κ��丮 ĭ�� ���ٸ� ���� �Ƚ�Ű�� ����

        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonPress();
            SelectItem(selectedItem);
        }

        // isActive = !inventoryPanel.activeSelf;
    }

    public void OnInventory(bool value) => inventoryPanel.SetActive(value);

    private void RotateItem(int clockwise = 1) // ������ ȸ��
    {
        Vector2Int before = new Vector2Int(selectedItem.onGridPositionX, selectedItem.onGridPositionY);
        InventoryItem beforeItem = selectedItem;

        if (selectedItem == null) { return; } // ���� �������� ���ٸ� ���� ����
        selectedItemGrid.OverlapCheck(selectedItem.onGridPositionX, selectedItem.onGridPositionY, selectedItem.HEIGHT, selectedItem.WIDTH, ref overlapItem);

        if (overlapItem != null)
        {
            print("��ħ");
            return;
        }
        else
        {
            selectedItem.Rotate(clockwise);
            print("�Ȱ�ħ");
        }

        PlaceItem(before);
        selectedItem = beforeItem;
        PickUpItem(before);

        MoveItem();
    }

    private void CreateRandomItem() // ���� ������ ���� �׽�Ʈ��
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem; // ������ ������ ����

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);

        int selectedItemID = UnityEngine.Random.Range(0, items.Count);
        inventoryItem.Set(items[selectedItemID]);
    }

    private void LeftMouseButtonPress()
    {
        Vector2 position = Input.mousePosition;

        if (selectedItem != null) // �������� �����ٸ�
        {
            position.x -= (selectedItem.WIDTH - 1) * InventoryGrid.tileSizeWidth / 2;
            position.y += (selectedItem.HEIGHT - 1) * InventoryGrid.tileSizeHeight / 2;
        }

        Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(position); // ���콺 ��ġ �޾ƿ��� 

        print(tileGridPosition);

        if (selectedItem == null) // �������� �������ٸ�
        {
            PickUpItem(tileGridPosition); // ������ ����
        }
        else // �������� �����ٸ�
        {
            if (isMove)
            {
                PlaceItem(tileGridPosition); // ������ ��ġ ���ϱ�
            }
        }
    }

    private void PlaceItem(Vector2Int tileGridPosition) // ������ ��ġ �α�
    {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem); // ���� �������� �ξ��°�

        if (complete) // ���� �������� �״ٸ�
        {
            selectedItem = null; // ���� ������ ���ֱ�

            isMove = false;
            inventoryMoveImage.sprite = null;

            if (overlapItem != null) // �ߺ��� ��ġ�� �������� �ִٸ�
            {
                selectedItem = overlapItem; // �տ� ����
                overlapItem = null; // �ߺ��� ������ ���ֱ�
                rectTransform = selectedItem.GetComponent<RectTransform>(); // �̵� ��Ű���� transform �޾ƿ���

                // ������ �� ��ģ ������ selectâ ���� �̹��� ���� 
            }
        }

    }

    private void PickUpItem(Vector2Int tileGridPosition) // ������ ���� ���� �����ٸ� �̵��� ���� transform ��������
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem != null)
        {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    private void SelectItem(InventoryItem select)
    {
        if (selectedItem != null && isMove == false)
        {
            inventorySelectPanel.SetActive(true);
            selectedItem = select;
            inventorySelectImage.sprite = selectedItem.itemData.itemicon;
        }
    }

    private void LooseItem()
    {
        inventorySelectPanel.SetActive(false);
        Destroy(selectedItem.gameObject);
    }

    private void MoveItem()
    {
        isMove = true;
        inventorySelectPanel.SetActive(false);
        inventoryMoveImage.sprite = selectedItem.itemData.itemicon;

        // ���� ������ loose ��Ű��
    }
}
