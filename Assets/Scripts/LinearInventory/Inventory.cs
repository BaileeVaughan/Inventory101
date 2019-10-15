using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Linear
{
    public class Inventory : MonoBehaviour
    {
        #region Variables
        public List<Item> inv = new List<Item>();
        public Item selectedItem;
        public bool showInv;
        public Vector2 scr;
        public Vector2 scrollPos;
        public int money;
        public string sortType = "";
        public Transform dropLocation;
        [System.Serializable]
        public struct equiptment
        {
            public string name;
            public Transform location;
            public GameObject curItem;
        }
        public equiptment[] equiptmentSlots;
        #endregion

        private void Start()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inv.Add(ItemData.CreateItem(2));
                inv.Add(ItemData.CreateItem(300));
                inv.Add(ItemData.CreateItem(901));
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                showInv = !showInv;
                if (showInv)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    return;
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = false;
                    return;
                }
            }
        }

        void OnGUI()
        {
            if (showInv)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;

                GUI.Box(new Rect(0, 0, scr.x * 8, Screen.height), "");
                Display();
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(4.375f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.5f * scr.y), selectedItem.Name);
                    GUI.DrawTexture(new Rect(4.372f * scr.x, 1 * scr.y, 3f * scr.x, 3 * scr.y), selectedItem.Icon);
                    GUI.Box(new Rect(4.375f * scr.x, 4.25f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description);
                    GUI.skin = null;
                    ItemUse();
                }
                else { return; }
            }
        }

        void Display()
        {
            if (inv.Count <= 16)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.5f * scr.y), 3 * scr.x, 0.4f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);

                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.5f * scr.y), 3 * scr.x, 0.4f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                GUI.EndScrollView();
            }
        }

        void ItemUse()
        {
            switch (selectedItem.Type)
            {
                case ItemType.Weapon:
                    break;
                case ItemType.Armour:
                    break;
                case ItemType.Ingredient:
                    break;
                case ItemType.Food:
                    break;
                case ItemType.Potion:
                    break;
                case ItemType.Scroll:
                    break;
                case ItemType.Craftable:
                    break;
                case ItemType.Money:
                    break;
                case ItemType.Quest:
                    break;
                case ItemType.Misc:
                    break;
                default:
                    break;
            }
            if (GUI.Button(new Rect(4.375f * scr.x, 7.5f * scr.y, 3 * scr.x, 0.75f * scr.y), "Discard"))
            {
                for (int i = 0; i < equiptmentSlots.Length; i++)
                {
                    if (equiptmentSlots[0].curItem != null && selectedItem.ItemMesh.name == equiptmentSlots[0].name)
                    {
                        Destroy(equiptmentSlots[1].curItem);
                    }
                }
                GameObject droppedItem = Instantiate(selectedItem.ItemMesh, dropLocation.position, Quaternion.identity);
                droppedItem.name = selectedItem.Name;
                droppedItem.AddComponent<Rigidbody>().useGravity = true;
                if (selectedItem.Amount > 1)
                {
                    selectedItem.Amount--;
                }
                else
                {
                    inv.Remove(selectedItem);
                    selectedItem = null;
                    return;
                }
            }
        }
    }
}