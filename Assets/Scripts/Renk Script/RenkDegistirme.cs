using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenkDegistirme : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("kýrmýzý")) //Dokunduðu tag kýrmýzý ise
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; //Rengini kýrmýzý yapar.
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);//Topa aþaðý dogru kuvvet uygular.
            Destroy(base.gameObject, 0.5f); //Top silinir.
            Debug.Log("GameOver");
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.name = "color";
            collision.gameObject.tag = "kýrmýzý"; //Tag' ini kýrmýzý yapar.
            StartCoroutine(RenkDegistirr(collision.gameObject));
        }
    }

    IEnumerator RenkDegistirr(GameObject g)
    {
        yield return new WaitForSeconds(0.01f); //Bekleme süresi
        g.GetComponent<MeshRenderer>().enabled = true;
        g.GetComponent<MeshRenderer>().material.color = TopIsleyici.color; //renk deðitirme iþlemi.
        Destroy(base.gameObject); // Üretilen top silinir.
    }
}
