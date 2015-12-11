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
    public enum PStyles : int
    {
        P1 = 0,//口
        P4 = 1,//田
        P2V = 2,//日
        P2H = 3,//口口
        P0 = 5//空格
    };
    /// <summary>
    /// 开时的布局
    /// </summary>
    internal struct StartPanel 
    {
        public string name;//布局名称
        internal string level;//难度
        internal byte[,] PlState;//具体布局参数
        public StartPanel(string Sname) 
        {
            switch(Sname)
            {
                //
                case "尼玛":
                    this.name = Sname;
                    this.level = "";
                    this.PlState = new byte[5, 4]{ 
                        { 2, 2, 8, 0 },
                        { 3, 7, 0, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 1, 1, 6 },
                        { 5, 9, 10, 6 }           
                    };
                    break;
                default: 
                     this.name = Sname;
                    this.level = "";
                    this.PlState = new byte[5, 4]{ 
                        { 2, 2, 8, 0 },
                        { 3, 7, 0, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 1, 1, 6 },
                        { 5, 9, 10, 6 }           
                    };
                    break;
            }
        }
    }
}
