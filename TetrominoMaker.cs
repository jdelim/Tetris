using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoMaker : MonoBehaviour
{
    public Tetromino Line;
    public TextAsset TetrominoData;
    // Start is called before the first frame update
    void Start()
    {
        GetTetrominons();
    }
    Tetromino[] GetTetrominons()
    {
        string[] Data = TetrominoData.text.Split("\n");
        List<Tetromino> Tetrominos = new List<Tetromino>();
        for(int i = 0; i < Data.Length; i += 17)
        {
            Tetromino output = new Tetromino();
            output.Origin = getPlacement(Data[i]);
            output.Rotations = new Rotation[4];
            string[] RData = { Data[i + 1], Data[i + 2], Data[i + 3], Data[i + 4]};
            output.Rotations[0] = MakeRotation(RData);
            RData = new string[]{Data[i + 5], Data[i + 6], Data[i + 7], Data[i + 8]};
            output.Rotations[1] = MakeRotation(RData); 
            RData = new string[] {Data[i + 9], Data[i + 10], Data[i + 11], Data[i + 12]};
            output.Rotations[2] = MakeRotation(RData); 
            RData = new string[] {Data[i + 13], Data[i + 14], Data[i + 15], Data[i + 16]};
            output.Rotations[3] = MakeRotation(RData);
            Tetrominos.Add(output);
        }
        return Tetrominos.ToArray();
    }
    Rotation MakeRotation(string[] Placements)
    {
        Rotation rotation = new Rotation();
        rotation.Placement = new Vector2Int[4];
        for(int i = 0; i < Placements.Length; i++)
        {
            rotation.Placement[i] = getPlacement(Placements[i]);
        }
        return rotation;
    }
    Vector2Int getPlacement(string Placement)
    {
        string[] Data = Placement.Split(",");
        Vector2Int output = new Vector2Int(int.Parse(Data[0]), int.Parse(Data[1]));
        return output;
    }
}
[System.Serializable]
public class Tetromino
{
    public Vector2Int Origin;
    public Rotation[] Rotations;
    //TODO: CREATE CONSTRUCTOR
}
[System.Serializable]
public class Rotation
{
    public Vector2Int[] Placement;
    //TODO: CREATE CONSTRUCTOR
}
