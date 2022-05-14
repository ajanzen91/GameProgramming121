using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TMP_Text _textHealth;
    public TMP_Text _textPoints;
    public PlayerStats _player;

    public Image _spell1;
    public Image _spell2;
    public Image _spell3;
    public Image _spell4;
    public Image _spell5;

    private int _spellCount;
    private int prevSpells;

    public Sprite _fireSprite;
    public Sprite _iceSprite;
    public Sprite _lightSprite;
    public Sprite _waterSprite;

    // Start is called before the first frame update
    void Start()
    {
        _textHealth.text = _player._hp.ToString();
        _textPoints.text = _player._score.ToString();
        _spellCount = _player._activeSpell._remainingCasts;
        _spell1.enabled = false;
        _spell2.enabled = false;
        _spell3.enabled = false;
        _spell4.enabled = false;
        _spell5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _textHealth.text = _player._hp.ToString();
        _textPoints.text = _player._score.ToString();
        _spellCount = _player._activeSpell._remainingCasts;
        DisplaySpells();
    }

    void DisplaySpells()
    {
        //fire display
        if (_player._activeSpell._type == 1)
        {
            if (_spellCount > 0)
            {
                _spell1.enabled = true;
                _spell1.sprite = _fireSprite;

                if (_spellCount > 1)
                {
                    _spell2.enabled = true;
                    _spell2.sprite = _fireSprite;

                    if (_spellCount > 2)
                    {
                        _spell3.enabled = true;
                        _spell3.sprite = _fireSprite;

                        if (_spellCount > 3)
                        {
                            _spell4.enabled = true;
                            _spell4.sprite = _fireSprite;

                            if (_spellCount > 4)
                            {
                                _spell5.enabled = true;
                                _spell5.sprite = _fireSprite;
                            }
                            else
                            {
                                _spell5.enabled = false;
                            }
                        }
                        else
                        {
                            _spell4.enabled = false;
                        }
                    }
                    else
                    {
                        _spell3.enabled = false;
                    }
                }
                else
                {
                    _spell2.enabled = false;
                }
            }
            else
            {
                _spell1.enabled = false;
            }
        }

        //water
        if (_player._activeSpell._type == 2)
        {
            if (_spellCount > 0)
            {
                _spell1.enabled = true;
                _spell1.sprite = _waterSprite;

                if (_spellCount > 1)
                {
                    _spell2.enabled = true;
                    _spell2.sprite = _waterSprite;

                    if (_spellCount > 2)
                    {
                        _spell3.enabled = true;
                        _spell3.sprite = _waterSprite;

                        if (_spellCount > 3)
                        {
                            _spell4.enabled = true;
                            _spell4.sprite = _waterSprite;

                            if (_spellCount > 4)
                            {
                                _spell5.enabled = true;
                                _spell5.sprite = _waterSprite;
                            }
                            else
                            {
                                _spell5.enabled = false;
                            }
                        }
                        else
                        {
                            _spell4.enabled = false;
                        }
                    }
                    else
                    {
                        _spell3.enabled = false;
                    }
                }
                else
                {
                    _spell2.enabled = false;
                }
            }
            else
            {
                _spell1.enabled = false;
            }
        }

        //lightning
        if (_player._activeSpell._type == 3)
        {
            if (_spellCount > 0)
            {
                _spell1.enabled = true;
                _spell1.sprite = _lightSprite;

                if (_spellCount > 1)
                {
                    _spell2.enabled = true;
                    _spell2.sprite = _lightSprite;

                    if (_spellCount > 2)
                    {
                        _spell3.enabled = true;
                        _spell3.sprite = _lightSprite;

                        if (_spellCount > 3)
                        {
                            _spell4.enabled = true;
                            _spell4.sprite = _lightSprite;

                            if (_spellCount > 4)
                            {
                                _spell5.enabled = true;
                                _spell5.sprite = _lightSprite;
                            }
                            else
                            {
                                _spell5.enabled = false;
                            }
                        }
                        else
                        {
                            _spell4.enabled = false;
                        }
                    }
                    else
                    {
                        _spell3.enabled = false;
                    }
                }
                else
                {
                    _spell2.enabled = false;
                }
            }
            else
            {
                _spell1.enabled = false;
            }
        }
        //ice
        if (_player._activeSpell._type == 4)
        {
            if (_spellCount > 0)
            {
                _spell1.enabled = true;
                _spell1.sprite = _iceSprite;

                if (_spellCount > 1)
                {
                    _spell2.enabled = true;
                    _spell2.sprite = _iceSprite;

                    if (_spellCount > 2)
                    {
                        _spell3.enabled = true;
                        _spell3.sprite = _iceSprite;

                        if (_spellCount > 3)
                        {
                            _spell4.enabled = true;
                            _spell4.sprite = _iceSprite;

                            if (_spellCount > 4)
                            {
                                _spell5.enabled = true;
                                _spell5.sprite = _iceSprite;
                            }
                            else
                            {
                                _spell5.enabled = false;
                            }
                        }
                        else
                        {
                            _spell4.enabled = false;
                        }
                    }
                    else
                    {
                        _spell3.enabled = false;
                    }
                }
                else
                {
                    _spell2.enabled = false;
                }
            }
            else
            {
                _spell1.enabled = false;
            }
        }
    }
}