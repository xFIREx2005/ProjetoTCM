using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    
        
        NavMeshAgent agent;
        public GameObject enemyMinimap;
        public SpriteRenderer sprEnemy;
        public Transform m_Position;
        private Transform m_PositionPlayer;
        private Animator myAnim;

        float timer, xMax, xMin, yMax, yMin, posX, posY;
        public bool patrol, followPlayer;
        public float timeStop, speedFollow, speedPatrol, disPatrol, disFollow, stopDis;


        Enemy enemy; 

        void Start()
        {
            Enemy.QtdInstancias();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            myAnim = GetComponent<Animator>();
            sprEnemy = GetComponent<SpriteRenderer>();
            m_PositionPlayer = GameObject.Find("Player").transform;

            PosMove();
            m_Position.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            timer = timeStop;

            enemy = new Enemy(posX,posY,speedPatrol,speedFollow,disPatrol,disFollow,0,false,0);
        }


        void Update()
        {
            PosMove();
            CheckMove();
            CheckSpr();
        }

        void CheckSpr()
        {

        }

        void CheckMove()
        {
            float _dist = Vector2.Distance(transform.position, m_Position.position);
            float _distPlayer = Vector2.Distance(transform.position, m_PositionPlayer.position);

            if (followPlayer == true)
            {
                if (_distPlayer <= disFollow)
                {
                    MovePlayer();
                    m_Position.position = transform.position;
                    enemyMinimap.SetActive(true);
                    if (_distPlayer <= 1.2)
                    {
                        agent.speed = 0f;
                    }
                }
                else if (patrol == true)
                {
                    MovePatrol();
                    enemyMinimap.SetActive(false);
                    if (_dist <= 0.1f)
                    {
                        agent.speed = 0f;
                    }
                }
            }
            else if (patrol == true) MovePatrol();

            if (_dist <= 2f)
                if (timer <= 0)
                {
                    m_Position.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                    timer = timeStop;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            if (agent.speed <= 0)
            {
                myAnim.SetBool("IsMoving", false);
            }
        }

        void MovePlayer()
        {
            agent.SetDestination(m_PositionPlayer.transform.position);
            agent.stoppingDistance = stopDis;
            agent.speed = speedFollow;

            myAnim.SetBool("IsMoving", true);
            myAnim.SetFloat("MoveX", (m_PositionPlayer.transform.position.x - transform.position.x));
            myAnim.SetFloat("MoveY", (m_PositionPlayer.transform.position.y - transform.position.y));
        }

        void MovePatrol()
        {
            agent.SetDestination(m_Position.transform.position);
            agent.stoppingDistance = 0.1f;
            agent.speed = speedPatrol;

            myAnim.SetBool("IsMoving", true);
            myAnim.SetFloat("MoveX", (m_Position.transform.position.x - transform.position.x));
            myAnim.SetFloat("MoveY", (m_Position.transform.position.y - transform.position.y));
        }
        void PosMove()
        {
            posX = transform.position.x;
            posY = transform.position.y;

            xMin = posX - disPatrol;
            xMax = posX + disPatrol;
            yMin = posY - disPatrol;
            yMax = posY + disPatrol;
        }
    
}
