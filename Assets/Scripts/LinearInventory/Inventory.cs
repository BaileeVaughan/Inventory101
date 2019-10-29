using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

        public ScrollRect view;
        public RectTransform content;
        public GameObject invButton;
        #endregion

        private void Start()
        {
            content.sizeDelta = new Vector2(292, 30);

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            for (int i = 0; i < inv.Count; i++)
            {
                Instantiate(invButton, content);
            }
        }
        
        //        for (int i = 0; i<inv.Count; i++)
        //        {
        //            GameObject clone = Instantiate(invButton, content);
        //            clone.name = inv[i].Name;
        //            clone.GetComponentInChildren<Text>().text = inv[i].Name;
        //        }

    void Update()
        {
            content.sizeDelta = new Vector2(292, 30 * inv.Count);
            if (Input.GetKey(KeyCode.I))
            {
                inv.Add(ItemData.CreateItem(Random.Range(1, 999)));
                Instantiate(invButton, content);
                GameObject clone = Instantiate(invButton, content);
                clone.name = inv[inv.Count - 1].Name;
                clone.GetComponentInChildren<Text>().text = inv[inv.Count - 1].Name;
            }
        }  
    }
}




