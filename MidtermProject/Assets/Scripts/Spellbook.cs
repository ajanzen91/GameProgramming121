using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    public int _selectedSpell;

    // Start is called before the first frame update
    void Start()
    {
        _selectedSpell = 0;

        SelectSpell();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSpell = _selectedSpell;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_selectedSpell >= transform.childCount - 1)
            {
                _selectedSpell = 0;
            }
            else
            {
                ++_selectedSpell;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_selectedSpell <= 0)
            {
                _selectedSpell = transform.childCount - 1;
            }
            else
            {
                --_selectedSpell;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedSpell = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            _selectedSpell = 1;
        }

        if (previousSpell != _selectedSpell)
        {
            SelectSpell();
        }
    }

    void SelectSpell()
    {
        int i = 0;
        foreach(Transform spell in transform)
        {
            if(i == _selectedSpell)
            {
                spell.gameObject.SetActive(true);
            }
            else
            {
                spell.gameObject.SetActive(false);
            }
            ++i;
        }
    }
}
