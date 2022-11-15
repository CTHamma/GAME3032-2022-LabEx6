using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public string targetPortal = "";
    public int portalEntry = 0;
    [SerializeField]
  //  string targetScene = "Overworld";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Portal Triggered with " + collision.gameObject.name);

        Traveler traveller = collision.GetComponent<Traveler>();

        if (traveller != null)
        {
            Debug.Log("Portal Warping " + traveller.gameObject.name);
            SceneManager.LoadScene(tag, LoadSceneMode.Single);

            portalEntry++;
        }
    }
}
