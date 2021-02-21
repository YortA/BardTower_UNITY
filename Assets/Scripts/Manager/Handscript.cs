using UnityEngine;

public class Handscript : MonoBehaviour
{
    [SerializeField] private GameObject Player2;        //Drag your player game object here for its position
    [SerializeField] private float radius;              //Set radius here


    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector3 playerPos = Player2.transform.position;

        Vector3 playerToCursor = cursorPos - playerPos;
        Vector3 dir = playerToCursor.normalized;
        Vector3 cursorVector = dir * radius;
        Vector3 finalPos = playerPos + cursorVector;

        if (playerToCursor.magnitude < cursorVector.magnitude) // detect if mouse is in inner radius
        {
            cursorVector = playerToCursor;
            Cursor.visible = true;
        }
        transform.position = playerPos + cursorVector;
    }




#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.DrawWireDisc(transform.parent.position, Vector3.up, radius); // draw radius
    }
#endif
}
