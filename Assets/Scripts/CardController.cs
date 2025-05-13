using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private List<Sprite> _states;
    [SerializeField] private Color _color;

    private Animator _animator;
    private Image _image;

    private float _closedTimer = 0;
    private bool _closing = false;

    private bool _active = false;
    private bool _paired = false;

    public bool paired => _paired;

    private GameController _controller;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _image.sprite = _states[_active ? 1 : 0];
    }

    private void Update()
    {
        if (_closing)
        {
            if (_closedTimer > 0)
            {
                _closedTimer -= Time.deltaTime;
            }
            else
            {
                _closing = false;
                _animator.SetTrigger("Flip");
            }
        }

    }
    public Sprite getCardType => _states[1];

    public void SetCard(Sprite sprite, GameController controller)
    {
        _states[1] = sprite;
        _controller = controller;
    }
    public void SwitchState()
    {
        _active = !_active;
        _image.sprite = _states[_active ? 1 : 0];
        if (_active)
        {
            _controller.FlipCard(this);
        }

    }

    public void IsPaired()
    {
        _image.color = _color;
        _paired = true;
    }

    public void OpenCard()
    {
        if (!_active) _animator.SetTrigger("Flip");
    }

    public void CloseCard()
    {
        if (_active)
        {
            _closedTimer = 0.5f;
            _closing = true;
        }
    }
}
