using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    public Element element;
    private GameObject refParent;
    private GameObject refChild;
    float timer=0;

    // Start is called before the first frame update
    void Start()
    {
        refParent = GameObject.Find("Elements");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>2f)
        {
            CreateElement();
            timer = 0;
        }
    }

    private void CreateElement() {
        var newElement = Instantiate(element);
        newElement.transform.position = new Vector2(Random.Range(-7.5f, 7.5f), 6);
        newElement.transform.SetParent(refParent.transform);
    }
}
