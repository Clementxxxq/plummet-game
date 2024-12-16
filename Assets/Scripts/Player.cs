using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables de mouvement du joueur
    public float speed = 1.5f;
    private Rigidbody2D rigidBody2D;
    private Vector2 movement;
    private PlayerData playerData;
    private bool _isGameOver;

    // Question 6 : Ajout d'un mode AI
    private List<Vector2> path; // Chemin calculé par Djikstra
    private int currentPathIndex;
    private float pathRecalculationTime = 1f; // Fréquence de recalcul du chemin
    private float lastPathCalculationTime; // Dernière fois où le chemin a été calculé
    private float stuckCheckTime = 3.5f; // Fréquence de détection du blocage
    private float lastStuckCheckTime; // Dernière fois où la détection de blocage a été effectuée
    private Vector2 lastPosition; // Dernière position du joueur
    private int stuckCounter = 0; // Compteur de blocages
    private float backtrackDistance = 2f; // Distance de recul en cas de blocage

    public bool isAIControlled = false;
    void Start()
    {
        _isGameOver = false;
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerData = new PlayerData();
        playerData.plummie_tag = "nraboy";
        path = new List<Vector2>();
        lastPosition = transform.position;
    }

    // Méthode qui calcule le chemin à prendre en mode AI
    void CalculatePath()
    {
        if (Time.time - lastPathCalculationTime < pathRecalculationTime)
            return;

        lastPathCalculationTime = Time.time;
        Vector2 startPos = transform.position;

        // Ajouter un offset vertical aléatoire pour tester différents chemins
        float verticalOffset = Random.Range(-2f, 2f);
        Vector2 targetPos = new Vector2(25f, transform.position.y + verticalOffset);

        path = Dijkstra.FindPath(startPos, targetPos, stuckCounter);
        currentPathIndex = 0;
        stuckCounter = 0; // Réinitialiser le compteur de blocages
    }

    // Méthode pour vérifier si le joueur est bloqué en mode AI
    void CheckIfStuck()
    {
        if (Time.time - lastStuckCheckTime < stuckCheckTime)
            return;

        float distanceMoved = Vector2.Distance(transform.position, lastPosition);
        if (distanceMoved < 0.1f && !_isGameOver)
        {
            stuckCounter++;
            if (stuckCounter > 3) // Si bloqué pendant trop longtemps
            {
                BacktrackAndFindNewPath();
            }
        }
        else
        {
            stuckCounter = 0;
        }

        lastPosition = transform.position;
        lastStuckCheckTime = Time.time;
    }

    // Retour en arrière et recherche d'un nouveau chemin
    void BacktrackAndFindNewPath()
    {
        Vector2 backtrackPosition = transform.position;
        backtrackPosition.x -= backtrackDistance; // Recule le joueur
        transform.position = backtrackPosition;

        path.Clear();
        currentPathIndex = 0;
        lastPathCalculationTime = 0f; // Réinitialiser le délai de calcul du chemin
        CalculatePath();
    }

    void Update()
    {
        // Mode AI : le joueur est contrôlé par l'AI
        if (_isGameOver) return;

        if (isAIControlled)
        {
            UpdateAIMovement();
            CheckIfStuck();
        }
        else
        {
            // Contrôle manuel du joueur
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            movement = new Vector2(h * speed, v * speed);
        }
    }

    // Mise à jour du mouvement AI
    void UpdateAIMovement()
    {
        if (path == null || path.Count == 0 || currentPathIndex >= path.Count)
        {
            CalculatePath();
            return;
        }

        Vector2 currentTarget = path[currentPathIndex];
        Vector2 currentPosition = transform.position;
        Vector2 direction = (currentTarget - currentPosition);
        float distance = direction.magnitude;

        if (distance < 0.1f)
        {
            currentPathIndex++;
            if (currentPathIndex >= path.Count)
            {
                CalculatePath();
                return;
            }
        }

        movement = direction.normalized * speed;
    }

    void FixedUpdate()
    {
        if (!_isGameOver)
        {
            Vector2 newPosition = rigidBody2D.position + movement * Time.fixedDeltaTime;
            rigidBody2D.MovePosition(newPosition);
        }

        // Condition de fin du jeu (arrivée à la ligne d'arrivée)
        if (rigidBody2D.position.x > 24.0f && !_isGameOver)
        {
            _isGameOver = true;
            Debug.Log("Reached the finish line!");
        }
    }

    // Vérification des collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        playerData.collisions++;

        if (isAIControlled)
        {
            stuckCounter++;
            if (stuckCounter > 2) // Si trop de collisions, le joueur est bloqué
            {
                BacktrackAndFindNewPath();
            }
            else
            {
                CalculatePath();
            }
        }
    }
}
