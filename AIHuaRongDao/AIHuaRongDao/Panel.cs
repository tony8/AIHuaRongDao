using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIHuaRongDao
{
   

    class iPanel
    {
        public static int plSize= 100;   //人物方格大小
        public static int plX = 4;        //定义列
        public static int plY= 5;       //定义行    
        //定义一个数组，用来记录各人物方格位置
        private static int startX = 10;
        private static int startY = 50;    
        //每个人物方格的位置
        public static Point[,] position;
        //定义每个人物方格的大小, 共有x*y(x=4, y=5)个人物方格

        ////标记索引位置是否可用
        //public bool[,] PlStateBool;
        public state state0;
        //public state stateNow;
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
        public iPanel()
        {
            //初始化每个方格的位置
            //定义每个人物方格的大小, 共有x*y(x=4, y=5)个人物方格
            position = new Point[plY,plX];
            for (int i = 0; i < plX; i++)
            {
                for (int j = 0; j < plY; j++)
                {
                    position[j, i] = new Point(startX + 100 * i, startY + 100 * j);
                }
            }              
        
            byte[,] PlState = new byte[5, 4] 
            { //初始化数表，即  
                //59k 347s
                //{ 3, 1, 1, 4 },
                //{ 3, 1, 1, 4 },
                //{ 5, 2, 2, 6 },
                //{ 5, 7, 8, 6 },
                //{ 9, 0, 0, 10 } 
                //20 298s 54K
                //{ 3, 1, 1, 4 }, 
                //{ 3, 1, 1, 4 },
                //{ 7, 8, 5, 6 }, 
                //{ 2, 2, 5, 6 },
                //{ 0, 0, 9, 10 } 
                //40 206s 40k
                //{ 7, 1, 1, 4 },
                //{ 8, 1, 1, 4 },
                //{ 9, 0, 0, 5 },
                //{ 6, 3, 10, 5 },
                //{ 6, 3, 2, 2 } 

                 //50
                //{ 7, 8, 4, 0 },
                //{ 3, 9, 4, 0 },
                //{ 3, 1, 1, 5 },
                //{ 6, 1, 1, 5 },
                //{ 6, 10, 2, 2 } 
                  //55
                //{ 0, 8, 4, 5 }, 
                //{ 3, 9, 4, 5 },
                //{ 3, 0, 1, 1 }, 
                //{ 6, 7, 1, 1 },
                //{ 6, 10, 2, 2 } 


                //60
                 //{ 3, 7, 5, 4 },
                 //{ 3, 8, 5, 4 },
                 //{ 6, 1, 1, 0 },
                 //{ 6, 1, 1, 0 },
                 //{ 9, 10, 2, 2 } 
              

                //70成功
                { 3, 5, 6, 0 },
                { 3, 5, 6, 0 },
                { 1, 1, 8, 4 },
                { 1, 1, 9, 4 },
                { 7, 10, 2, 2 } 
                
                //13步可行
                //{ 3, 4, 5, 6 }, 
                //{ 3, 4, 5, 6 },
                //{ 1, 1, 7, 8 }, 
                //{ 1, 1, 2, 2 },
                //{ 9, 10, 0, 0 } 


                //9步可行
                //{ 2, 2, 8, 0 },
                //{ 3, 7, 0, 4 },
                //{ 3, 1, 1, 4 },
                //{ 5, 1, 1, 6 },
                //{ 5, 9, 10, 6 }



            };
            state0.selectID = 1;
            state0.FatherID = 1;
            state0.sID = 1;            
            state0.plstateNum = state.Plcomputer2Num(state.plShow2computer(PlState));

            //byte[,] btemp = new byte[5, 4];
            //byte[,] bshow = new byte[5, 4];
            
            //ulong a= state.Plcomputer2Num(state.plShow2computer(PlState));
            //btemp = state.Num2Plcomputer(a);
            //bshow = state.plComputer2show(btemp);
            //byte id = state.correctSelectID(bshow,1);
        }
        //public void setTheLocation(state s0) 
        //{//输入一个状态，将该状态在界面上显示出来
        //    //1.设置位置 

        //}

    }   


    
           
}
