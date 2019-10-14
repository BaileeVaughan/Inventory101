using UnityEngine;

public class Item : MonoBehaviour
{
    #region Variables
    private int _id;
    private int _amount;
    private int _value;
    private int _damage;
    private int _armour;
    private int _heal;
    private string _name;
    private string _description;

    private Texture2D _icon;
    private GameObject _mesh;
    private ItemType _type;
    #endregion
    #region Public Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject ItemMesh
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    #endregion

}

public enum ItemType
{
    Weapon,
    Armour,
    Ingredient,
    Food,
    Potion,
    Scroll,
    Craftable,
    Money,
    Quest,
    Misc
}
