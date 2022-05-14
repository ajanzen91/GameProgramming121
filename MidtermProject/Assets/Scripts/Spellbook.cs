using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    public int _selectedSpell;
    public Spell _fireBase;
    public Spell _iceBase;
    public Spell _lightningBase;
    public Spell _waterBase;
    public PlayerStats _player;

    // Start is called before the first frame update
    void Start()
    {
        SelectSpell();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedSpell = _selectedSpell;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_selectedSpell >= transform.childCount - 1)
                _selectedSpell = 0;
            else
                _selectedSpell++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_selectedSpell <= 0)
                _selectedSpell = transform.childCount - 1;
            else
                _selectedSpell--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedSpell = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            _selectedSpell = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            _selectedSpell = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            _selectedSpell = 3;
        }
        if (previousSelectedSpell != _selectedSpell)
        {
            SelectSpell();
        }
    }

    void SelectSpell()
    {
        int i = 0;
        foreach (Transform spell in transform)
        {
            if (i == _selectedSpell)
            {
                spell.gameObject.SetActive(true);
                _player._activeSpell = spell.GetComponent<Spell>();
            }
            else
            {
                spell.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
