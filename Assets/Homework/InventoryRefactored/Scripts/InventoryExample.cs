using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homework.InventoryRefactored.Scripts
{
    public class InventoryExample : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            Debug.Log("Создаём инвентарь (макс 10 эл-тов)");

            List<IReadOnlyItem> items = new();
            items.Add(new Item("Яблоко"));
            items.Add(new Item("Груша"));
            items.Add(new Item("Виноград"));

            _inventory = new Inventory(items, 10);
            Debug.Log(_inventory.ToString());
            
            Item itemApple = new Item("Яблоко");
            Item itemBread = new Item("Хлеб");
        
            Debug.Log("Добавляем 1 яблоко");
            _inventory.Add(itemApple);
            Debug.Log(_inventory.ToString());
        
            Debug.Log("Добавляем 3 хлеба.");
            _inventory.Add(itemBread, out _, 3);
            Debug.Log(_inventory.ToString());
            
            List<IReadOnlyItem> returnedItems = new();
            returnedItems = _inventory.GetItemsBy("Хлеб", 3);
            Debug.Log("Проверяем метод _inventory.GetItemsBy. Найдем весь хлеб:");
            returnedItems.ForEach(item => Debug.Log(item.Name));
        
            AddItemBy(itemApple.Name, "Добавляем 20 яблок.", 20);
            GetItemBy(itemApple.Name, "Убираем 4 яблока.", 4);
            GetItemBy(itemBread.Name, "Убираем 2 хлеба.", 2);
            GetItemBy(itemBread.Name, "Добавляем 3 хлеба.", 3);
            GetItemBy(itemApple.Name, "Убираем 20 яблока.", 20);
        }
        
        private void AddItemBy(string name, string printMessage, int count)
        {
            Debug.Log(printMessage);
            _inventory.Add(new Item(name), out _, count);
            Debug.Log(_inventory.ToString());
        }
    
        private void GetItemBy(string name, string printMessage, int count)
        {
            Debug.Log(printMessage);
            _inventory.TryGet(new Item(name), out _, count);
            Debug.Log(_inventory.ToString());
        }
    }
}