using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pathRequestManager : MonoBehaviour
{

    Queue<PathRequest> PathRequestQueue = new Queue<PathRequest>();
    PathRequest currnetPathRequest;

    static pathRequestManager instance;
    Pathfinding pathfinding;

    bool isProcessingPath;
    
    private void Update()
    {
       
    }



    private void Awake()
    {
        instance = this;
        pathfinding = GetComponent<Pathfinding>();
    }

    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[],Boolean> callback)
    {
        //print("pathstart"+pathStart);
        //print("pathend"+pathEnd);
        PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
        instance.PathRequestQueue.Enqueue(newRequest);
        instance.TryProcessNext();
    }

    void TryProcessNext()
    {
        if(!isProcessingPath && PathRequestQueue.Count > 0)
        {
            currnetPathRequest = PathRequestQueue.Dequeue();
            isProcessingPath = true;
            pathfinding.StartFindPath(currnetPathRequest.pathStart, currnetPathRequest.pathEnd);
        }
    }


    public void FinishedProcessignPath(Vector3[] path, bool sucess)
    {
        currnetPathRequest.callback(path,sucess);//
        isProcessingPath = false;
        TryProcessNext();
    }


    struct PathRequest
    {
        public Vector3 pathStart;
        public Vector3 pathEnd;
        public Action<Vector3[], Boolean> callback;

        public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], Boolean> _callback)
        {
            pathStart = _start;
            pathEnd = _end;
            callback = _callback;
        }
    }
    
}
