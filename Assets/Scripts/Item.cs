using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{

    public enum InteractionType {NONE, Pickup, Examine}
    public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    
    public UnityEvent customEvent;


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 8;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Pickup:
                GameObject item = gameObject;
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            default:
                break;
        }

        customEvent.Invoke();

    }
}
