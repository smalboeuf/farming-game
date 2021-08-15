using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationPoint : MonoBehaviour
{

    public ExplorationArea explorationArea;

    [SerializeField]
    private float radiusSize = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision triggered");
        if (collision.transform.tag == "Player")
        {
            print("Player entered exploration point");
            Manager.explorationManager.ExploreArea(explorationArea);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radiusSize);
    }
}
