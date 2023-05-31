using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessTerrain : MonoBehaviour
{
    
    public const float maxViewDistance = 450;
    public Transform viewer;

    public GameObject chunk;

    public static Vector2 viewerPosition;

    private int chunkSize = 241;
    private int chunksVisibleInViewDistance;

    private Dictionary<Vector2, TerrainChunk> terrainDictionary = new Dictionary<Vector2, TerrainChunk>();
    private List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    private void Start()
    {
        chunksVisibleInViewDistance = Mathf.RoundToInt(maxViewDistance / chunkSize);
    }

    private void Update()
    {
        viewerPosition = new Vector2(viewer.position.x, viewer.position.y);
        UpdateVisibleChunks();
    }

    private void UpdateVisibleChunks()
    {

        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }

        terrainChunksVisibleLastUpdate.Clear();
        
        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);

        for (int yOffset = -chunksVisibleInViewDistance; yOffset <= chunksVisibleInViewDistance; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDistance; xOffset < chunksVisibleInViewDistance; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (terrainDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainDictionary[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, transform, chunk));
                }
            }
        }
    }

    public class TerrainChunk
    {
        private GameObject meshObject;
        Vector2 position;
        private Bounds bounds;

        public TerrainChunk(Vector2 coord, int size, Transform parent, GameObject chunk)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, position.y, 0);

            // Tạo một đối tượng hình vuông
            meshObject = Instantiate(chunk);
            
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size;
            meshObject.transform.parent = parent;
            SetVisible(false);
        }

        public void UpdateTerrainChunk()
        {
            float viewerDistanceFromNearestEdge = bounds.SqrDistance(viewerPosition);
            bool visible = viewerDistanceFromNearestEdge <= maxViewDistance;
            SetVisible(visible);
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }
    }
}