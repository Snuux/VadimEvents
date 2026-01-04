using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [SerializeField] private InventoryView _inventoryView;
    
    private Inventory _inventory;
    public Inventory Inventory => _inventory;
    
    private void Awake()
    {
        Debug.Log("Создаём инвентарь (макс 10 эл-тов)");
        _inventory = new Inventory(10);
        
        _inventoryView.Initialize(_inventory);
        
        Item itemApple = new Item("Яблоко");
        Item itemBread = new Item("Хлеб");
        
        Debug.Log("Добавляем 1 яблоко");
        _inventory.Add(itemApple);
        Debug.Log(_inventory.ToString());
        
        Debug.Log("Добавляем 3 хлеба.");
        _inventory.Add(itemBread, 3);
        Debug.Log(_inventory.ToString());
        
        AddItemBy(itemApple.Name, "Добавляем 20 яблок.", 20);
        GetItemBy(itemApple.Name, "Убираем 4 яблока.", 4);
        GetItemBy(itemBread.Name, "Убираем 2 хлеба.", 2);
        GetItemBy(itemBread.Name, "Добавляем 3 хлеба.", 3);
        GetItemBy(itemApple.Name, "Убираем 20 яблока.", 20);
    }

    private void AddItemBy(string name, string printMessage, int count)
    {
        Debug.Log(printMessage);
        _inventory.TryAddBy(name, out _, count);
        Debug.Log(_inventory.ToString());
    }
    
    private void GetItemBy(string name, string printMessage, int count)
    {
        Debug.Log(printMessage);
        _inventory.TryGetBy(name, out _, count);
        Debug.Log(_inventory.ToString());
    }
}