using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject affectedObject;
    int inTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        affectedObject.SetActive(false);
        inTrigger++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger--;
        if (inTrigger == 0)
        { 
            affectedObject.SetActive(true);
        }
    }
}
