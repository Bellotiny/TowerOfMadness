using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    private Vector3 lastCheckpoint;
    private bool checkpointInitialized = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            lastCheckpoint = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
        //Debug.Log("Checkpoint set at: " + position);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpoint;
    }

    public bool HasCheckpoint()
    {
        return lastCheckpoint != Vector3.zero;
    }
    public void ClearCheckpointOnFirstLoad()
    {
        lastCheckpoint = Vector3.zero;
        checkpointInitialized = true;
        Debug.Log("Checkpoint cleared on first load.");
    }

    public void ResetCheckpointState()
    {
        checkpointInitialized = false;
    }
}
