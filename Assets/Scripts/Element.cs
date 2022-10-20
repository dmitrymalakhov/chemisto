using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Element : MonoBehaviour
{
    public TMP_Text label;
    public Hero hero;
    private string[] elements;
    private int typeOfElement;

    // Start is called before the first frame update
    void Start()
    {
        elements = new string[] {"H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne"};
        UpdateText();
    }

    public static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return chars[Random.Range(0, chars.Length)].ToString() + chars[Random.Range(0, chars.Length)].ToString().ToLower();
    }

    // Update is called once per frame
    void Update()
    {
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (this.gameObject.name == "Element(Clone)")
        {
            if (col.gameObject.name == "Hero")
            {
                hero.GetDamage(System.Array.IndexOf(elements, label.text) != -1);
                Destroy(this.gameObject);
            }
            else if (col.gameObject.name == "Tile")
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        if (this.gameObject.name == "Element(Clone)")
            Destroy(this.gameObject);
    }

    public void UpdateText()
    {
        if (Random.Range(0, 2) == 0)
        {
            label.text = RandomString();
        }
        else
        {
            label.text = elements[Random.Range(0, elements.Length)];
        }
    }
}
