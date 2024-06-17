using System;
using UnityEngine;

[Serializable]
public struct SymmetricTetromino : ITetromino
{
    [SerializeField] private TetrominoData m_data;
    public TetrominoData Data { get => m_data; set => m_data = value; }
    private Vector2Int[] WallticksTests => new Vector2Int[0];
    public ITetromino Move(Vector2Int direction)
    {
        return new SymmetricTetromino(MoveBehaviour.Instance.Move(Data, direction));
    }
    public ITetromino Rotate(bool clockwise)
    {
        return new SymmetricTetromino(StandardRotationBehaviour.Instance.Rotate(Data, clockwise));
    }
    public SymmetricTetromino(TetrominoData data)
    {
        m_data = data;
    }
}