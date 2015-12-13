using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHuaRongDao
{
    public enum SearchType : int 
    {
        BFS =1,
        DFS =2,
        HS=3
    }
    struct Operate
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
    /// 简单
    /// </summary>
    public enum SPanel :int 
    {
        easy_1= 1,
        easy_2 = 2,
        easy_3 = 3,
        medial_1 = 4,
        medial_2 = 5,
        medial_3 = 6,
        difficult_1 =7,
        difficult_2 = 8,
        difficult_3 = 9,        
    }
    /// <summary>
    /// 开时的布局
    /// </summary>
    /// 
    /* P1 = 0,//口
    P4 = 1,//田
    P2V = 2,//日
    P2H = 3,//口口
 * 1.曹操 田
 * 2.关羽 口口
 * 3.赵云  日
 * 4.张飞  日
 * 5.马超  日
 * 6.黄忠  日
 * 7.8.9.10 小兵 口
    */
    internal struct StartPanel 
    {
        public string name;//布局名称
        internal string level;//难度
        internal byte[,] PlState;//具体布局参数
        public StartPanel(SPanel SelectPanel) 
        {
            switch (SelectPanel)
            {
                //简单 3个
                case SPanel.easy_1:
                    this.name = "大意失荆州";
                    this.level = "简单";
                    this.PlState = new byte[5, 4]{ 
                        { 3, 5, 6, 0 },
                        { 3, 5, 6, 0 },
                        { 1, 1, 8, 4 },
                        { 1, 1, 9, 4 },
                        { 7, 10, 2, 2 } 

                        //{ 0, 3, 7, 6 },
                        //{ 4, 3, 0, 6 },
                        //{ 4, 1, 1, 8 },
                        //{ 5, 1, 1, 10 },
                        //{ 5, 9, 2, 2 }           
                    };
                    break;
                case SPanel.easy_2:
                    this.name = "整齐排列";
                    this.level = "简单";
                    this.PlState = new byte[5, 4]{ 
                        { 7, 3, 4, 8 },
                        { 5, 3, 4, 6 },
                        { 5, 9, 10,6 },
                        { 1, 1, 0, 0 },
                        { 1, 1, 2, 2 }           
                    };
                    break;
                case SPanel.easy_3:
                    this.name = "同步倒影";
                    this.level = "简单";
                    this.PlState = new byte[5, 4]{ 
                        { 0, 3, 0, 5 },
                        { 7, 3, 4, 5 },
                        { 8, 9, 4, 6 },
                        { 1, 1, 10,6 },
                        { 1, 1, 2, 2 }           
                    };
                    break;
                    //中等 3个
                case SPanel.medial_1:
                    this.name = "双头两尾";
                    this.level = "中等";
                    this.PlState = new byte[5, 4]{ 
                        { 2, 2, 3, 0 },
                        { 1, 1, 3, 0 },
                        { 1, 1, 4, 9 },
                        { 7, 5, 4, 6 },
                        { 8, 5, 10, 6 }           
                    };
                    break;
                case SPanel.medial_2:
                    this.name = "孔明扇乙";
                    this.level = "中等";
                    this.PlState = new byte[5, 4]{ 
                        { 3, 2, 2, 7 },
                        { 3, 1, 1, 6 },
                        { 4, 1, 1, 6 },
                        { 4, 5, 8, 9 },
                        { 0, 5, 10, 0 }           
                    };
                    break;
                case SPanel.medial_3:
                    this.name = "鞠躬尽瘁";
                    this.level = "中等";
                    this.PlState = new byte[5, 4]{ 
                        { 3, 4, 7, 8 },
                        { 3, 4, 1, 1 },
                        { 9, 10,1, 1 },
                        { 5, 2, 2, 6 },
                        { 5, 0, 0, 6 }           
                    };
                    break;
                //困难 3个
                case SPanel.difficult_1:
                    this.name = "横刀立马";
                    this.level = "困难";
                    this.PlState = new byte[5, 4]{ 
                        { 3, 1, 1, 5 },
                        { 3, 1, 1, 5 },
                        { 4, 2, 2, 6 },
                        { 4, 8, 9, 6 },
                        { 7, 0, 0, 10 }           
                    };
                    break;
                case SPanel.difficult_2:
                    this.name = "左右布兵";
                    this.level = "困难";
                    this.PlState = new byte[5, 4]{ 
                        { 7, 1, 1, 9 },
                        { 8, 1, 1, 10 },
                        { 3, 4, 5, 6 },
                        { 3, 4, 5, 6 },
                        { 0, 2, 2, 0 }           
                    };
                    break;
                case SPanel.difficult_3:
                    this.name = "围而不歼";
                    this.level = "困难";
                    this.PlState = new byte[5, 4]{ 
                        { 3, 1, 1, 7 },
                        { 3, 1, 1, 8 },
                        { 4, 2, 2, 9 },
                        { 4, 5, 6, 10 },
                        { 0, 5, 6, 0 }           
                    };
                    break;

                default: 
                     this.name = "组长快点发红包";
                    this.level = "2222";
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
