using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SoldierCommandScript : MonoBehaviour {
    public GameObject Target;
    private NavMeshAgent agent;
    private Animation anim;

    public AnimationState Shooting;
    public AnimationState Idle;
    public AnimationState Runing;

    public GameObject BulletPrefab;
    public GameObject Bullet;

    int counter = 0;
    float cooldown = 0;

    // Use this for initialization
    void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animation>();
        
        foreach(AnimationState state in anim)
        {
            counter++;
            Debug.Log(state.name);
            switch (counter)
            {
                case 1:
                    Runing = state;
                    break;
                case 2:
                    Idle = state;
                    break;
                case 3:
                    Shooting = state;
                    break;
            }  
        }

	}

    // Update is called once per frame
    void Update() {
            Target = GameObject.FindGameObjectWithTag("Ennemy");
        
        if (Target != null)
        {
            anim.Play(Runing.name);
            agent.SetDestination(Target.GetComponent<Transform>().localPosition);
            agent.stoppingDistance = this.GetComponent<SoldierScript>().Range/2;
            if (agent.remainingDistance <= this.GetComponent<SoldierScript>().Range)
            {
                //anim.Play(Shooting.name);
                Shoot();
            }
            {

            }
        }
        else
        {
            anim.Play(Idle.name);
        }
	}

    void Shoot()
    {
        cooldown += Time.deltaTime;

        if(cooldown >= 5/ this.GetComponent<SoldierScript>().FireRate)
        {
            cooldown = 0;
            Debug.Log("Fire");
            Bullet = Instantiate(BulletPrefab, this.GetComponent<Transform>());
            Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 6;
        }

    }
}
