using Game.Core.Fruit;
using Game.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Core.FruitLogic
{
    public class FruitGraterLogic : MonoBehaviour
    {
        [Header("Fruit Settings")]
        [SerializeField]
        private FruitData[] _fruits;

        [SerializeField]
        private FruitView _objectView;

        [SerializeField]
        private Transform _resetGamePosition;

        [Header("On Game Reset")]
        [SerializeField]
        private UnityEvent _onGameReset;


        private FruitData _currentFruit;

        private BoxCollider2D _boxCollider;

        private Vector3 _oldPosition;

        private float _rubbingValue;

        private bool _inGrather;


        private void Start()
        {
            _currentFruit = SetNewFruit();
            _boxCollider = GetComponent<BoxCollider2D>();
            _rubbingValue = _currentFruit.StartGraterValue;
            _oldPosition = transform.position;
            _objectView.UpdateView(_currentFruit);
        }

        private void Update()
        {
            if (_inGrather && _oldPosition != transform.position)
            {
                Grathing();
                _oldPosition = transform.position;
            }
        }

        private void Grathing()
        {
            _rubbingValue -= .005f;
            _objectView.UpdateGateringValue(_rubbingValue);
            _boxCollider.offset = new Vector2(_boxCollider.offset.x + .0015f, _boxCollider.offset.y + .0015f);

            //if 80 % fruit was mashed, reset game
            if (_rubbingValue < -0.45f)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            _onGameReset?.Invoke();
            transform.position = _resetGamePosition.position;
            _rubbingValue = 1f;
            _currentFruit = SetNewFruit();
            _boxCollider.offset = Vector2.zero;
            _objectView.UpdateView(_currentFruit);
            _objectView.UpdateGateringValue(_rubbingValue);
        }

        private FruitData SetNewFruit()
        {
            return _fruits[Random.Range(0, _fruits.Length)];
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Grater"))
            {
                _inGrather = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Grater"))
            {
                _inGrather = false;
            }
        }
    }
}