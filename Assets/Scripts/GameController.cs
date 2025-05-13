using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<CardController> _cardControllers;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<Sprite> _activeSprites;
    [SerializeField] private GameObject _card;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    private CardController _flipedCard;
    private bool _win = false;
    private float _endTimer = 0f;

    private void Start()
    {
        int counter = _columns * _rows;
        for(int i  = 0; i < counter / 2; i++)
        {
            Sprite sprite = _sprites[Random.Range(0, _sprites.Count)];
            _sprites.Remove(sprite);
            _activeSprites.Add(sprite);
            _activeSprites.Add(sprite);
        }

        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        grid.constraintCount = _columns;
        for (int i = 0; i < counter; i++)
        {
            Sprite sprite = _activeSprites[Random.Range(0, _activeSprites.Count)];
            _activeSprites.Remove(sprite);
            CardController card = GameObject.Instantiate(_card, transform).GetComponent<CardController>();
            card.SetCard(sprite, this);
            _cardControllers.Add(card);
        }
    }

    public void FlipCard(CardController card)
    {
        if(_flipedCard == null)
        {
            _flipedCard = card;
        }
        else
        {
            if (_flipedCard.getCardType == card.getCardType)
            {
                _flipedCard.IsPaired();
                card.IsPaired();
                bool win = true;
                foreach(CardController controller in _cardControllers)
                {
                    win &= controller.paired;
                }
                if(win)
                {
                    _win = win;
                }
            }
            else
            {
                _flipedCard.CloseCard();
                card.CloseCard();
            }
            _flipedCard = null;
        }
    }
    void Update()
    {
        if (_win)
        {
            if(_endTimer > 0)
            {
                _endTimer -= Time.deltaTime;
            }
            else
            {
                PlayerData.Instance.LvlUp();
            }
        }
    }
}
