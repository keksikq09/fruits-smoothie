using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New FruitData", menuName = "Fruit/FruitData")]
    public class FruitData : ScriptableObject
    {
        [SerializeField]
        private Sprite _mainTexture;

        [SerializeField]
        private MaskFormat _maskFormat;

        [SerializeField]
        private Sprite _maskTexture;

        [SerializeField]
        private float _startGraterValue;

        [SerializeField]
        private Color _particleColor;

        public Sprite MainTexture { get => _mainTexture; }

        public MaskFormat MaskFormat { get => _maskFormat; }

        public Sprite MaskTexture { get => _maskTexture; }

        public float StartGraterValue { get => _startGraterValue; }

        public Color ParticleColor { get => _particleColor; }
    }

    public enum MaskFormat
    {
        left,
        right,
        top,
        down,
        leftDown,
        leftTop,
        rightDown,
        rightTop,
    }
}