using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    public Transform container;
    public List<GameObject> levels;
    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [Header("Pieces Settings")]
    public float timeBetweenPieces = .3f;
    public Transform pieceContainer;
    public List<LevelPieceBaseSetup> levelPieceBaseSetups;
    private LevelPieceBaseSetup _currentSetup;
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private void Awake()
    {
        //SpawnNextLevel();
        GenerateLevelPieces();
    }
    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            
            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GenerateLevelPieces();
        }
    }

    #region PIECES
    private void GenerateLevelPieces()
    {
        CleanSpawnedPieces();

        if (_currentSetup != null)
        {
            _index++;

            if(_index >= levelPieceBaseSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentSetup = levelPieceBaseSetups[_index];

        for (int i = 0; i < _currentSetup.piecesStartNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelStartPieces);
        }
        
        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
        }   
        
        for (int i = 0; i < _currentSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelEndPieces);
        }

        ColorManager.Instance.ChangeColorByType(_currentSetup.artType);
        //StartCoroutine(CreateLevelPiecesCoroutine());
    }
   


    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawedPiece.transform.position = lastPiece.endPiece.position;
        }

        else
        {
            spawedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var p in spawedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawedPiece);

        
    }

    public void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    /* IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    } */


    #endregion
}
