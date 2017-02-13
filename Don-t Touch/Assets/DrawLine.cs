using UnityEngine;
using System.Collections;
public class DrawLine : MonoBehaviour
{
    private LineRenderer line; // Reference to LineRenderer
    private GameObject LineObject;
    private Vector3 mousePos;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    void Update()
    {

        // On mouse down new line will be created
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
                createLine();
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(0, mousePos);
            startPos = mousePos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (line)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(1, mousePos);
                endPos = mousePos;
                addColliderToLine();
                line = null;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (line)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(1, mousePos);
            }
        }
    }
    // Following method creates line runtime using Line Renderer component
    private void createLine()
    {
        LineObject = new GameObject("Line");
        line = LineObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.sortingOrder = 0;
        line.SetVertexCount(2);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(Color.black, Color.black);
        line.useWorldSpace = true;
    }
    // Following method adds collider to created line
    private void addColliderToLine()
    {
        //LineObject.AddComponent<BoxCollider>();
        LineObject.AddComponent<CapsuleCollider>();
    }
}
