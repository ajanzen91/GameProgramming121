using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector3 _aimPoint;
    public float _accuracyRadius; // smaller # == more accurate
    public int _fireRate; // quickest time allowed (in seconds) between one call of Shoot and the next
    private float _cooldownCount;
    public Bullet _bullet; //possible expansion of ammo types ie, explosive, armor piercing, etc
    public int _maxAmmo; //What is full?
    public int _currAmmo;

    // Start is called before the first frame update
    void Start()
    {
        _currAmmo = (int)(_maxAmmo * .75f);
        _cooldownCount = (float)_fireRate;
        _bullet._fired = false;
        //aimPoint = mouse position
        //_aimPoint = new Vector3(Input.mousePosition);
        //_bullet = GameObject.FindGameObjectsWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        //Update aim point
        _aimPoint = Input.mousePosition;
    }

    public void Shoot()
    {
        if (_currAmmo > 0)
        {
            Bullet toFire;
            Vector2 aimJank = Random.insideUnitCircle * _accuracyRadius;
            Quaternion jankRotation = new Quaternion(_bullet.transform.rotation.y + aimJank.y, _bullet.transform.rotation.x + aimJank.x, 0, _bullet.transform.rotation.w);
            toFire = Instantiate(_bullet, _bullet.transform.position, jankRotation);

            StartCoroutine(CoolDown(toFire));
            --_currAmmo;
        }
    }

    private IEnumerator CoolDown(Bullet _round)
    {
        _round.transform.Translate(Vector3.forward * 100 * Time.deltaTime);
        //if (_cooldownCount >= 0f)
        //{
        //    _cooldownCount -= 1f;
        yield return new WaitForSeconds(0f);
        //}
        //else
        //{
        //    _cooldownCount = (float)_fireRate;
        //}
    }

}
