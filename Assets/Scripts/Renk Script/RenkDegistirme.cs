using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenkDegistirme : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("k�rm�z�")) //Dokundu�u tag k�rm�z� ise.Bunu b�t�n renk de�i�tiren child objeleri i�in kullan�m herhangi bir �ey de olabilir.
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; //Rengini k�rm�z� yapar.
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);//Topa a�a�� dogru kuvvet uygular.
            HeartsFun(collision.gameObject);
            
            Destroy(base.gameObject, 0.5f); //Top silinir.
            Debug.Log("GameOver");
        }
        else
        {
            GameObject.Find("hitSound").GetComponent<AudioSource>().Play();
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.name = "color";
            collision.gameObject.tag = "k�rm�z�"; //Tag' ini k�rm�z� yapar.
            StartCoroutine(RenkDegistirr(collision.gameObject));
        }
    }

    IEnumerator RenkDegistirr(GameObject g)
    {
        yield return new WaitForSeconds(0.01f); //Bekleme s�resi
        g.GetComponent<MeshRenderer>().enabled = true;
        g.GetComponent<MeshRenderer>().material.color = TopIsleyici.color; //renk de�itirme i�lemi.
        Destroy(base.gameObject); // �retilen top silinir.
    }

    void HeartsFun(GameObject g)
    {
        int @int = PlayerPrefs.GetInt("hearts");
        if (@int == 1)
        {
            FindObjectOfType<TopIsleyici>().FailGame();
            FindObjectOfType<TopIsleyici>().HeartsLow();
        }
    }
}
