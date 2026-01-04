using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private Inventory _inventory;
    
    private string _input = "Яблоко";
    
    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }
    
    void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2f);
        
        const float width = 260f;
        const float padding = 10f;

        Rect panelRect = new Rect(10, 10, width, 180);
        GUI.Box(panelRect, "Inventory Debug");

        GUILayout.BeginArea(new Rect(
            panelRect.x + padding,
            panelRect.y + 25,
            panelRect.width - padding * 2,
            panelRect.height - padding * 2
        ));

        GUILayout.Label(_inventory != null 
            ? _inventory.ToString() 
            : "Inventory is null");

        GUILayout.Space(5);
        _input = GUILayout.TextField(_input);
        
        GUILayout.Space(5);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            Item item = new Item(_input);
            _inventory?.Add(item);
        }

        if (GUILayout.Button("Get"))
            _inventory?.TryGetBy(_input, out _);

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
