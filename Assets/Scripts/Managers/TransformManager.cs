using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class TransformManager : MonoBehaviour
{
    public static TransformManager Instance { get; private set; }

    public PlayerInputControl inputControl;

    public GameObject currentPlayer;
    public GameObject slimePrefab;
    public GameObject BoarPrefab;
    public GameObject soldierPrefab;
    public GameObject RangerPrefab;
    public float currentPlayerIndex = 0;
    private Transform currentTransform;

    public bool isLookingBoar;
    public bool isLookingSoldier;
    public bool isLookingRanger;

    public string hitTag;

    public CinemachineVirtualCamera cinemachineCamera;

    public float maxHealth = 100;
    public float currentHealth;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        inputControl = new PlayerInputControl();
        currentPlayer = FindObjectOfType<PlayerController>().gameObject;
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = currentPlayer.transform;
        }
        currentPlayer = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //     public void transformer(float order)
    // {
    //     currentTransform = currentPlayer.transform;
    //     GameObject oldPlayer = currentPlayer;

    //     if(order == currentPlayerIndex)
    //     {
    //         return;
    //     }
    //     oldPlayer.SetActive(false);
    //     Vector3 position = currentTransform.position;
    //     Quaternion rotation = currentTransform.rotation;


    //     if(order == 0)
    //     {
    //         Debug.Log("Slime");
    //         currentPlayer = Instantiate(slimePrefab, position, rotation);

    //     }
    //     else if(order == 1 && isLookingSoldier)
    //     {
    //         Debug.Log("Soldier");
    //         currentPlayer = Instantiate(soldierPrefab, position, rotation);
    //     }
    //     else if(order == 2 && isLookingBoar)
    //     {
    //         Debug.Log("Boar");
    //         currentPlayer = Instantiate(BoarPrefab, position, rotation);
    //     }
    //     else if(order == 3 && isLookingRanger)
    //     {
    //         Debug.Log("Ranger");
    //         currentPlayer = Instantiate(RangerPrefab, position, rotation);
    //     }

    //     Destroy(oldPlayer);

    //     currentPlayerIndex = order;
    //     if (cinemachineCamera != null)
    //     {
    //         cinemachineCamera.Follow = currentPlayer.transform;
    //     }
    // }

    public void transformer(float order)
    {
        currentTransform = currentPlayer.transform;
        if (order == 0)
        {
            if (currentPlayerIndex == 0)
            {
                return;
            }
            else
            {
                Debug.Log("Slime");
                Destroy(currentPlayer);
                currentPlayer = Instantiate(slimePrefab, currentPlayer.transform.position, currentPlayer.transform.rotation);

                currentPlayerIndex = order;
            }
        }
        else if (order == 1 && isLookingSoldier)
        {

            if (currentPlayerIndex == 1)
            {
                return;
            }
            else
            {
                Debug.Log("Soldier");
                currentPlayer.SetActive(false);
                currentPlayer = Instantiate(soldierPrefab, currentTransform.position, currentTransform.rotation);

                currentPlayerIndex = order;
            }
        }
        else if (order == 2 && isLookingBoar)
        {
            if (currentPlayerIndex == 2)
            {
                return;
            }
            else
            {
                Debug.Log("Boar");
                Destroy(currentPlayer);
                currentPlayer = Instantiate(BoarPrefab, currentPlayer.transform.position, currentPlayer.transform.rotation);

                currentPlayerIndex = order;
            }
        }
        else if (order == 3 && isLookingRanger)
        {

            if (currentPlayerIndex == 3)
            {
                return;
            }
            else
            {
                Debug.Log("Ranger");
                Destroy(currentPlayer);
                currentPlayer = Instantiate(RangerPrefab, currentPlayer.transform.position, currentPlayer.transform.rotation);
            
                currentPlayerIndex = order;
            }
        }

        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = currentPlayer.transform;
        }
    }

}
