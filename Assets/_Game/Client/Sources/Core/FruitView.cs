using Game.Data;
using UnityEngine;

namespace Game.Core.Fruit
{
    public class FruitView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void UpdateView(FruitData newData)
        {
            _spriteRenderer.sprite = newData.MainTexture;
        }

        public void UpdateGateringValue(float newValue)
        {
            _spriteRenderer.material.SetFloat("_Scaler", newValue);
        }

    }
}