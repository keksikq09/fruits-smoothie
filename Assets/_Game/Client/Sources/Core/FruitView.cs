using Game.Data;
using UnityEngine;

namespace Game.Core.Fruit
{
    public class FruitView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Animation _animator;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator= GetComponent<Animation>();
            _animator.Play("Enable");
        }

        public void UpdateView(FruitData newData)
        {
            _spriteRenderer.sprite = newData.MainTexture;
            _animator.Play("Enable");
        }

        public void UpdateGateringValue(float newValue)
        {
            _spriteRenderer.material.SetFloat("_Scaler", newValue);
        }

    }
}