using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIHuaRongDao
{
    class MultiThreading
    {
        //每次并行计算多个状态的下一个状态，然后一次性加入open表中
        //输入：一个open列表 和 
        //输出：新的open列表
        public List<state> OpenList;
        List<state> MultiOne;
        List<state> MultiNext;

        public int MultiNum { get; private set; }

        MultiThreading(List<state> list)
        {//初始化
            OpenList = new List<state>(list);
            if (list.Count <= 3)
            {
                MultiNum = list.Count;
            }
            else            
                 MultiNum = 4;
            
            for (int i=0;i<MultiNum;i++)
            {
                MultiOne[i] = list[i];
            }
            
        }
        internal static void multiCalNextState(List<state> list)
        {
            //多个线程同时进行
            ThreadStart NextState = new ThreadStart(MultiThreading.findNextState());
            //Thread a = new Thread(findNextState());
            //Thread a = new Thread(findNextState());
            //Thread a = new Thread(findNextState());
            //Thread a = new Thread(findNextState());
            for (int i = 0; i < MultiNum; i++)
            {
                MultiOne[i] = list[i];
            }
        }

        internal static List<state> findNextState(state stateNow)
        {
            //
            List<state> a = new List<state>();
            return a;
        }
    }
}
