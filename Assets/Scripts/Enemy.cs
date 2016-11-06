using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    void Update()
    {

        //transform.Rotate(Vector3.Lerp(transform.position, new Vector3(1f, 1f, 1f), 10f));
        transform.Rotate(new Vector3(1f, 1f, 1f));
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Player")
        {
            //destroy
            Destroy(gameObject);
            //gameObject.SetActive(false);
            Debug.Log("Puan");
        }
    }
}
