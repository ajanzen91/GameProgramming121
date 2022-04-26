using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MESSSui : MonoBehaviour
{
    //Player Health variables
    public TMP_Text _textHealth;
    private int _health;
    public KnightMovement _playerRef;

    //Gun-related variables
    public TMP_Text _fullAmmo;
    public TMP_Text _remainingAmmo;
    private int _fullCount, _remainCount;


    // Start is called before the first frame update
    void Start()
    {
        _health = _playerRef._hp;
        _textHealth.text = _health.ToString();

        _fullCount = _playerRef._activeGun._maxAmmo;
        _remainCount = _playerRef._activeGun._currAmmo;
        _fullAmmo.text = _fullCount.ToString();
        _remainingAmmo.text = _remainCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _health = _playerRef._hp;
        _textHealth.text = _health.ToString();

        _fullCount = _playerRef._activeGun._maxAmmo;
        _remainCount = _playerRef._activeGun._currAmmo;
        _fullAmmo.text = _fullCount.ToString();
        _remainingAmmo.text = _remainCount.ToString();
    }
}
