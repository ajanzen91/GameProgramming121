//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollectObject : MonoBehaviour
//{
//    [SerializeField] private float card;

//    private void OnTriggerEnter(Collider collision)
//    {
//        if (collision.tag == "Player")
//        {
//            Debug.Log("[CARD AQUIRED]");
//            collision.GetComponent<PlayerHealth>().AddCard(card);
//            Destroy(gameObject);
//        }
//    }
//}