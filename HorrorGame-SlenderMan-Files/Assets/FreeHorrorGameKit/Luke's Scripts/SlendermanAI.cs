using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlendermanAI : MonoBehaviour
{
    public GameObject player;
    public Transform[] TeleportLocations;

    public bool SlendermanInView;
    public bool isChasing;

    private NavMeshAgent navAgent;

    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast to check if the player can see Slenderman
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Collider>().bounds))
        {
            SlendermanInView = true;
            Debug.Log("is in view");
        }
        else
        {
            SlendermanInView = false;
        }

        //If player looks at Slenderman: Slenderman stops moving
        if (SlendermanInView == true)
        {
            isChasing = false;
            navAgent.isStopped = true;

            // Slenderman attacks
            if (isAttacking == false) { StartCoroutine(SlenderManAttack()); }

        }
        // If Player looks away from SlenderMan: Teleport to random [Set] location, then start chasing the player.
        else if (isChasing == false)
        {
            Teleport();
        }
        else
        {
            isChasing = true;
            navAgent.isStopped = false;
        }

        // If isChasing, slenderman chases the player
        if (isChasing == true)
        {
            navAgent.destination = player.transform.position;
        }
    }

    // Teleports Slenderman, and then sets him to IsChasing
    public void Teleport()
    {
        int i = Random.Range(0, TeleportLocations.Length);
        this.gameObject.transform.position = TeleportLocations[i].position;

        isChasing = true;
    }

    IEnumerator SlenderManAttack()
    {
        isAttacking = true;
        player.GetComponent<PlayerHealth>().TakeDamage(1);

        yield return new WaitForSeconds(1);

        isAttacking = false;
    }




}