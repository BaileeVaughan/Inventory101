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
            inv.Add(ItemData.CreateItem(0));
        }

        private void Update()
        {
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
    }
}
