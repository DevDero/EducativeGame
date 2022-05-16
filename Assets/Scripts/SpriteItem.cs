using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteItem : MonoBehaviour
{
    [SerializeField] UnityEvent ClickEvent;
    
    private void OnCollisionEnter(Collision collision)
    {
        ClickEvent.Invoke();
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
