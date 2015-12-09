using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHuaRongDao
{
    public enum searchType : byte
    {
        BFS = 1,
        DFS = 2
    };

    struct operate
    {//共有10个人物，4个方向，共40个操作
        public byte PersonID;
        public Direction dir;
    }
    public enum Direction : int
    {
        UP = 1,
        down = 2,
        left = 3,
        right = 4,
    };
    //public enum PStyles : int
    //{
    //    P1 = 0,//口
    //    P4 = 1,//田
    //    P2V = 2,//日
    //    P2H = 3,//口口
    //};  
}
