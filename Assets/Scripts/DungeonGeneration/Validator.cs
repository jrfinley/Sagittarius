using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class PathValidator
    {
        public static bool RoomInPath(Vector3 pointToCheck)
        {
            if (Physics.CheckSphere(pointToCheck, 0.1f))
                return true;

            return false;
        }

        public static bool ValidDirection(List<Vector3> directions, Vector3 directionToCheck)
        {
            directionToCheck *= -1;

            //prevent it from going backwards immediatly
            if (directionToCheck == directions[directions.Count - 1])
            {
                //Debug.Log("False: Went Backwards");
                return false;
            }

            //prevent it from making U-Turns
            if (directions.Count > 1 && directionToCheck == directions[directions.Count - 2])
            {
                //Debug.Log("False: U-Turn");
                return false;
            }

            //up, down, left, right
            Vector4 score = Vector4.zero;
            _GetScores(directions, out score);

            if (score.x > score.y)
            {
                if (!_DirectionScoreCheck(directionToCheck, directions, new Vector3(0f, 0f, -0.5f)))
                    return false;
            }
            else if (score.y > score.x)
            {
                if (!_DirectionScoreCheck(directionToCheck, directions, new Vector3(0f, 0f, 0.5f)))
                    return false;
            }
            if (score.z > score.w)
            {
                if (!_DirectionScoreCheck(directionToCheck, directions, new Vector3(-0.5f, 0f, 0f)))
                    return false;
            }
            else if (score.w > score.z)
            {
                if (!_DirectionScoreCheck(directionToCheck, directions, new Vector3(0.5f, 0f, 0.5f)))
                    return false;
            }

            return true;
        }

        private static bool _DirectionScoreCheck(Vector3 directionToCheck, List<Vector3> directions, Vector3 directionToCompare)
        {
            int tempScore = 0;
            foreach (Vector3 direction in directions)
                if (direction == directionToCheck)
                    tempScore++;
            if (tempScore > directions.Count / 3)
                return false;


            return true;
        }

        private static void _GetScores(List<Vector3> directions, out Vector4 score)
        {
            score = Vector4.zero;
            for (int i = 0; i < directions.Count / 2; i++)
            {
                if (directions[i] == new Vector3(0f, 0f, 0.5f))
                    score += new Vector4(1, 0, 0, 0);
                else if (directions[i] == new Vector3(0f, 0f, -0.5f))
                    score += new Vector4(0, 1, 0, 0);
                else if (directions[i] == new Vector3(0.5f, 0f, 0f))
                    score += new Vector4(0, 0, 1, 0);
                else if (directions[i] == new Vector3(-0.5f, 0f, 0f))
                    score += new Vector4(0, 0, 0, 1);
            }
        }
    }

    public class RoomValidator
    { 
        
    }
}
