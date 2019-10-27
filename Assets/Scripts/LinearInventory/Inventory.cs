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
                inv.Add(ItemData.CreateItem(101));
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
                if (GUI.Button(new Rect(4.25f * scr.x, 0, scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = "All";
                }
                if (GUI.Button(new Rect(5.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(6.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Craftable"))
                {
                    sortType = "Craftable";
                }
                if (GUI.Button(new Rect(7.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Food"))
                {
                    sortType = "Food";
                }
                if (GUI.Button(new Rect(8.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Ingredient"))
                {
                    sortType = "Ingredient";
                }
                if (GUI.Button(new Rect(9.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Misc"))
                {
                    sortType = "Misc";
                }
                if (GUI.Button(new Rect(10.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Money"))
                {
                    sortType = "Money";
                }
                if (GUI.Button(new Rect(11.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Potion"))
                {
                    sortType = "Potion";
                }
                if (GUI.Button(new Rect(12.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Quest"))
                {
                    sortType = "Quest";
                }
                if (GUI.Button(new Rect(13.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Scroll"))
                {
                    sortType = "Scroll";
                }
                if (GUI.Button(new Rect(14.25f * scr.x, 0, scr.x, 0.25f * scr.y), "Weapon"))
                {
                    sortType = "Weapon";
                }

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
            if (!(sortType == "All" || sortType == ""))
            {
                ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
                int a = 0; //amount of type
                int s = 0; //slot position

                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type) //find the type
                    {
                        a++; //increase for each item it finds
                    }
                }
                if (a < 16)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.5f * scr.y), 3 * scr.x, 0.4f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                }
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.5f * scr.y), 3 * scr.x, 0.4f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                }
            }
            else
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
        }
        void ItemUse()
        {
            switch (selectedItem.Type)
            {
                case ItemType.Weapon:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Equip"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                Destroy(equiptmentSlots[1].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.ItemMesh, equiptmentSlots[1].location);
                            equiptmentSlots[1].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Unequip"))
                        {
                            Destroy(equiptmentSlots[1].curItem);
                        }
                    }
                    break;
                case ItemType.Armour:
                    if (equiptmentSlots[0].curItem == null || selectedItem.Name != equiptmentSlots[0].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Equip"))
                        {
                            if (equiptmentSlots[0].curItem != null)
                            {
                                Destroy(equiptmentSlots[0].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.ItemMesh, equiptmentSlots[0].location);
                            equiptmentSlots[0].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Unequip"))
                        {
                            Destroy(equiptmentSlots[0].curItem);
                        }
                    }
                    break;
                case ItemType.Ingredient:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Eat"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                Destroy(equiptmentSlots[1].curItem);
                            }

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
                    break;
                case ItemType.Food:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Eat"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                Destroy(equiptmentSlots[1].curItem);
                            }

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
                    break;
                case ItemType.Potion:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Drink"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                Destroy(equiptmentSlots[1].curItem);
                            }

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
                    break;
                case ItemType.Scroll:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Cast"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                Destroy(equiptmentSlots[1].curItem);
                            }

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
                    break;
                case ItemType.Craftable:
                    if (equiptmentSlots[1].curItem == null || selectedItem.Name != equiptmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Craft"))
                        {
                            if (equiptmentSlots[1].curItem != null)
                            {
                                inv.Add(ItemData.CreateItem(901));
                                inv.Remove(selectedItem);
                            }

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
            if (GUI.Button(new Rect(6 * scr.x, 8 * scr.y, scr.x, 0.75f * scr.y), "Discard"))
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