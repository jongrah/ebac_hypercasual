using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    [Header("Art List")]
    public ArtManager.ArtType artType;

    [Header("Pieces List")]
    public List<LevelPieceBase> levelStartPieces;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelEndPieces;

    [Header("Pieces Configuration")]
    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}