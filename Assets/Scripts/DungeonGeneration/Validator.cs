using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class RoomValidator
    {
        
    }

    public class NodeValidator
    {
        public static bool NodePlaceable(float posX, float posY)
        {
            if (posX % 1 != 0)
                if (posY % 1 == 0)
                    return true;
            if (posY % 1 != 0)
                if (posX % 1 == 0)
                    return true;

            return false;
        }
    }
}
