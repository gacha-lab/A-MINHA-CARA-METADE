using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    //Referência a pontos de passagem do enemy
    public List<Transform> points;
    //valor do proximo ponto
    public int nextID = 0;
    //valor do ID
    int idChangeValue = 1;
    //velocidade de movimento 
    public float speed = 2;


    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //criar boxcollider já trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //novo obj 
        GameObject root = new GameObject(name + "_Root");
        //Redefinir a posição do root para o enemy
        root.transform.position = transform.position;
        //definir como filho
        transform.SetParent(root.transform);
        //criar obj para pontos
        GameObject waypoints = new GameObject("Waypoints");
        //Redefinir a posição dos waypoints para root       
        //Tornar o objeto waypoints filho do root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Criar dois pontos obj e redefina sua posição para obj waypoints
        //pontos filhos para obj waypoint
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Iniciar a lista de pontos e adicionar os pontos a ela
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Obter o transform para o ponto
        Transform goalPoint = points[nextID];
        //Virar o enemy atraves do transform para olhar na direção do ponto
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //Mova o enemy em direção ao ponto
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Verificar a distância entre o enemy e o ponto para acionar o próximo
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            //Verificar o ponto final
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Verificar o ponto inicial
            if (nextID == 0)
                idChangeValue = 1;
            
            nextID += idChangeValue;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<LifeCount>().LoseLife();
        }

        if (collision.tag == "Player2")
        {
            FindObjectOfType<LifeCount2>().LoseLife2();
        }
    }

}
