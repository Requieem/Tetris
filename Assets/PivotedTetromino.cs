using System;
using UnityEngine;

[Serializable]
public struct PivotedTetromino : ITetromino
{
    [SerializeField] private TetrominoData m_data;
    public TetrominoData Data { get => m_data; set => m_data = value; }
    private Vector2Int[] WallticksTests
    {
        get
        {
            switch(m_data.Rotation)
            {
                case RotationState.Up:
                    return new Vector2Int[] { new(0, 0), new(-1, 0), new(-1, 1), new(0, -2), new(-1, -2) };
                case RotationState.Right:
                    return new Vector2Int[] { new(0, 0), new(1, 0), new(1, -1), new(0, 2), new(1, 2) };
                case RotationState.Down:
                    return new Vector2Int[] { new(0, 0), new(1, 0), new(1, 1), new(0, -2), new(1, -2) };
                case RotationState.Left:
                    return new Vector2Int[] { new(0, 0), new(-1, 0), new(-1, -1), new(0, 2), new(-1, 2) };
                default:
                    return new Vector2Int[] { new(0, 0) };
            }
        }
    }
    public ITetromino Move(Vector2Int direction)
    {
        return new PivotedTetromino(MoveBehaviour.Instance.Move(Data, direction));
    }
    public ITetromino Rotate(bool clockwise)
    {
        return new PivotedTetromino(PivotedRotationBehaviour.Instance.Rotate(Data, clockwise));
    }
    public PivotedTetromino(TetrominoData data)
    {
        m_data = data;
    }
}