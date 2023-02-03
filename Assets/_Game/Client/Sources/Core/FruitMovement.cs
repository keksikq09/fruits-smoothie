using UnityEngine;

namespace Game.Core.FruitLogic
{
    public class FruitMovement : MonoBehaviour
    {
        private bool _isSelected;

        private void OnMouseDown()
        {
            _isSelected = true;
        }

        private void OnMouseUp()
        {
            _isSelected = false;
        }

        private void Update()
        {
            if (_isSelected)
            {
                Vector2 cursor = Input.mousePosition;
                cursor = Camera.main.ScreenToWorldPoint(cursor);

                transform.position = cursor;
            }
        }
    }
}