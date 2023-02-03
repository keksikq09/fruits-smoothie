using UnityEngine;

public class Grater : MonoBehaviour
{
    [SerializeField]
    private float _rubbingValue;

    SpriteRenderer _spriteRenderer;

    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;

    Vector3 _oldPosition;

    private bool _inGrather;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _oldPosition= transform.position;
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
        _rubbingValue -= .0025f;
        _spriteRenderer.material.SetFloat("_Scaler", _rubbingValue);
    }

    public float stationaryTolerance = 0.005f;

    public bool IsStationary()
    {
        if (_rigidbody.velocity.magnitude != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _inGrather = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _inGrather = false;
    }
}