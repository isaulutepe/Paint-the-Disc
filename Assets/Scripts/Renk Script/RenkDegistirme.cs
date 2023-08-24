using System.Collections;
using System.Collections.Generic;
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
            base.GetComponent<Rigidbody>().AddForce(Vector3.down *50, ForceMode.Impulse);//Topa aþaðý dogru kuvvet uygular.
            Destroy(base.gameObject); //Top silinir.
            Debug.Log("GameOver");
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.name = "renk";
            collision.gameObject.tag = "kýrmýzý"; //Tag' ini kýrmýzý yapar.
            StartCoroutine(RenkDegistirr(collision.gameObject));
        }
    }
    IEnumerator RenkDegistirr(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.01f); //Bekleme süresi
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().material.color = TopIsleyici.renk; //renk deðitirme iþlemi.
        Destroy(base.gameObject); // Üretilen top silinir.
    }
}
