using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIHuaRongDao
{ 
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
   /// <summary>
   /// 界面类，规定初始和结束状态
   /// </summary>

    class iPanel
    {
        public static  int plSize= 100;   //人物方格大小
        public static  int plX = 4;        //定义列
        public static  int plY = 5;       //定义行    
        //定义一个数组，用来记录各人物方格位置
        private static  int startX = 10;
        private static  int startY = 50;    
        //每个人物方格的位置
        public static Point[,] position;
        //标记索引位置是否可用
        public state FirstState;
        public state SuccessState;
        public iPanel(StartPanel StartPanelnow)
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
            //初始化开始状态和结束状态
            initStateStartEnd(StartPanelnow);
           
        
            //byte[,] PlState = new byte[5, 4] 
            //{ //初始化数表，即  
              
            //    //9步可行
            //    //{ 2, 2, 8, 0 },
            //    //{ 3, 7, 0, 4 },
            //    //{ 3, 1, 1, 4 },
            //    //{ 5, 1, 1, 6 },
            //    //{ 5, 9, 10, 6 }
            //};
           

            //byte[,] btemp = new byte[5, 4];
            //byte[,] bshow = new byte[5, 4];
            
            //ulong a= state.Plcomputer2Num(state.plShow2computer(PlState));
            //btemp = state.Num2Plcomputer(a);
            //bshow = state.plComputer2show(btemp);
            //byte id = state.correctSelectID(bshow,1);
        }

        public void initStateStartEnd(StartPanel StartPanelnow) 
        {
            FirstState.selectID = 1;
            FirstState.FatherID = 1;
            FirstState.sID = 1;
            //state0.plstateNum = state.Plcomputer2Num(state.plShow2computer(PlState));
            FirstState.plstateNum = state.Plcomputer2Num(state.plShow2computer(StartPanelnow.PlState));

            //初始化结束状态
            byte[,] finishState = new byte[5, 4] 
            { //初始化数表，即  
                { 11, 11, 11, 11}, 
                { 11, 11, 11, 11},
                { 11, 11, 11, 11}, 
                { 11, 1, 1, 11},
                { 11, 1, 1, 11} 
            };
            SuccessState.plstateNum = state.Plcomputer2Num(finishState);
            SuccessState.selectID = 1;
        }
    }   
}
