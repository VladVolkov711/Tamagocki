using UnityEngine;

[CreateAssetMenu(fileName = "Product")]
public class Product : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _image;
    [SerializeField] private string _name;
    [SerializeField] private int _count;

    public int ID { get { return _id; } set { _id = value; } }
    public int Price { get { return _price; } set { value = _price; } }
    public Sprite Image { get { return _image; } set { value = _image; } }
    public string Name { get { return _name; } set { value = _name; } }
    public int Count { get { return _count; } set { value = _count; } }
}
