using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenkDegistirme : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("k�rm�z�")) //Dokundu�u tag k�rm�z� ise
        {
            base.gameObject.GetComponent<Collider>().enabled = false; 
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; //Rengini k�rm�z� yapar.
            base.GetComponent<Rigidbody>().AddForce(Vector3.down *50, ForceMode.Impulse);//Topa a�a�� dogru kuvvet uygular.
            Destroy(base.gameObject); //Top silinir.
            Debug.Log("GameOver");
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.name = "renk";
            collision.gameObject.tag = "k�rm�z�"; //Tag' ini k�rm�z� yapar.
            StartCoroutine(RenkDegistirr(collision.gameObject));
        }
    }
    IEnumerator RenkDegistirr(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.01f); //Bekleme s�resi
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().material.color = TopIsleyici.renk; //renk de�itirme i�lemi.
        Destroy(base.gameObject); // �retilen top silinir.
    }
}
