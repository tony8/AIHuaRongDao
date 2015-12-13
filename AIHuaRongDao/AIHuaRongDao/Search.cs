using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIHuaRongDao
{   
    //System.Threading.Tasks a = new System.Threading.Tasks();
    
    //使用多线程减少计算时间，启发式算法时不能使用多线程并行计算
    //对于状态表open中的前4个状态，同时计算4个状态的下一个状态
    // 然后按照前后顺序添加成小集合，再一次性加入大集合
    //方法1：找一个状态的一下个状态
    //方法二：将一个状态集合不重复的添加到另一个集合中
    //3.判断是否成功
    //初始化时输入状态遍历的方法
    //即对状态表添加时方法不同
    //做一个分析界面，输出广度优先遍历方法和启发式算法的性能优缺点

    class Search
    {
        public List<state> OpenList;//待展开的结点列表
        public List<state> ClosedList;//已展开过的结点列表       

        //输入：
        state startState;//开始状态
        state finishS;//结束状态 曹操位置为【3，1】
        SearchType mySearchType;

        //结果：
        public bool isSucess;
        public int searchCount;
        public double searchTime;   
        public List<state> sucStateList;//记录成功路径
        public Search(iPanel myP)
        {
            //初始化输入
            startState = myP.FirstState; //初始化开始状态
            finishS = myP.SuccessState;  //初始化终结状态
            //初始化结果
            SearchInit();
        }
        //初始化
        private void SearchInit()
        {
            //初始化结果
            isSucess = false;
            searchCount = 0;
            searchTime = 0;

            sucStateList = new List<state>();
            OpenList = new List<state>();
            ClosedList = new List<state>();
        }

        public void searchAnswer(SearchType ST)
        {
            //设置搜索方式
            mySearchType = ST;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (ST)
            {
                case SearchType.BFS:
                    isSucess = BFS(); break;
                case SearchType.DFS:
                    isSucess = DFS(); break;
                case SearchType.HS:
                    isSucess = HS(); break;
            }
            sw.Stop();
            searchTime = sw.ElapsedMilliseconds / 1000.0;
        }

        //广度优先
        public bool BFS()
        {//广度优先搜索，即先将某层次的所有点出列    
            //将s0压入表
            //对s0的ID和父亲ID赋值           
            uint SID = 0;
            OpenList.Add(startState);
            //开始循环
            while (OpenList.Count != 0)
            {//取出第一个点   
                //拓展一个点时赋予状态ID，并给其子节点赋值fatherID
                SID++;
                state oneS = OpenList[0];
                //更新SID的数值
                oneS.sID = SID;
                ClosedList.Add(oneS);

                //打开opened表的一个节点,，判断是否成功.成功则返回成功
                if (isSuccess(oneS))
                {//成功找到
                    //从closedList 中找到最优解  
                    searchCount = OpenList.Count + ClosedList.Count;
                    findSucessList(oneS);
                    return true;
                }
                else
                { //不成功则扩展该节点，将新节点加入open列表
                    //addStateToListBFS(oneS);
                    List<state> temp = new List<state>();
                    List<state> tempNext = new List<state>();
                    tempNext = findNextState(oneS);

                    foreach (state s1 in tempNext)
                    {
                        temp.Add(s1);
                    }

                    if (temp.Count != 0)
                    {
                        for (int k = 0; k < temp.Count; k++)
                        {
                            state kone = temp[k];
                            OpenList.Add(kone);
                        }
                    }

                    OpenList.RemoveAt(0);
                }

                //if (ClosedList.Count > 30000) break;
            }
            return false;//搜索失败
        }
        public bool DFS()
        {//广度优先搜索，即先将某层次的所有点出列    
            //将s0压入表
            //对s0的ID和父亲ID赋值           
            uint SID = 0;
            OpenList.Add(startState);
            //开始循环
            while (OpenList.Count != 0)
            {//取出第一个点   
                //拓展一个点时赋予状态ID，并给其子节点赋值fatherID
                SID++;
                state oneS = OpenList[0];
                //更新SID的数值
                oneS.sID = SID;
                OpenList.RemoveAt(0);
                ClosedList.Add(oneS);
                //打开opened表的一个节点,，判断是否成功.成功则返回成功
                if (isSuccess(oneS))
                {//成功找到
                    //从closedList 中找到最优解                   
                    findSucessList(oneS);
                    return true;
                }
                else
                { //不成功则扩展该节点，将新节点加入open列表
                    //addStateToListBFS(oneS);
                    List<state> temp = new List<state>();
                    List<state> tempNext = new List<state>();
                    tempNext = findNextState(oneS);

                    byte[,] showones = new byte[5, 4];
                    showones = state.Num2Plcomputer(oneS.plstateNum);

                    for (int i = 0; i < tempNext.Count; i++)
                    {
                        byte[,] showhaha = new byte[5, 4];
                        showhaha = state.Num2Plcomputer(tempNext[i].plstateNum);
                    }

                    if (tempNext.Count != 0)
                    {
                        tempNext.AddRange(OpenList);
                        OpenList = tempNext;
                        //OpenList.Reverse();
                    }
                }
                if (ClosedList.Count > 200) { return true; }
                //if (ClosedList.Count > 30000) break;
            }
            return false;//搜索失败
        }
        private bool HS()
        {
            //
            return true;
        }
        //public bool myserach(searchType ST)
        //{//广度优先搜索，即先将某层次的所有点出列    
        //    //将s0压入表
        //    //对s0的ID和父亲ID赋值           
        //    uint SID = 0;
        //    OpenList.Add(startState);
        //    //开始循环
        //    if (ST == searchType.BFS)
        //    {
        //        while (OpenList.Count != 0)
        //        {//拓展一个点时赋予状态ID，并给其子节点赋值fatherID
        //            SID++;
        //            state oneS = OpenList[0];
        //            //更新SID的数值
        //            oneS.sID = SID;
        //            ClosedList.Add(oneS);

        //            //打开opened表的一个节点,，判断是否成功.成功则返回成功
        //            if (isSuccess(oneS))
        //            {//成功找到                                   
        //                findSucessList(oneS);
        //                return true;
        //            }
        //            else
        //            { //不成功则扩展该节点，将新节点加入open列表                     
        //                List<state> temp = new List<state>();
        //                List<state> tempNext = new List<state>();
        //                tempNext = findNextState(oneS);

        //                foreach (state s1 in tempNext)
        //                {
        //                    temp.Add(s1);
        //                }
        //                if (temp.Count != 0)
        //                {
        //                    for (int k = 0; k < temp.Count; k++)
        //                    {
        //                        state kone = temp[k];
        //                        OpenList.Add(kone);
        //                    }
        //                }
        //                OpenList.RemoveAt(0);
        //            }
        //        }
        //    }
        //    else 
        //    {
        //        while (OpenList.Count != 0)
        //        {//拓展一个点时赋予状态ID，并给其子节点赋值fatherID
        //            SID++;
        //            state oneS = OpenList[0];
        //            //更新SID的数值
        //            oneS.sID = SID;
        //            ClosedList.Add(oneS);

        //            //打开opened表的一个节点,，判断是否成功.成功则返回成功
        //            if (isSuccess(oneS))
        //            {//成功找到                                   
        //                findSucessList(oneS);
        //                return true;
        //            }
        //            else
        //            { //不成功则扩展该节点，将新节点加入open列表                     
        //                List<state> temp = new List<state>();
        //                List<state> tempNext = new List<state>();
        //                tempNext = findNextState(oneS);

        //                foreach (state s1 in tempNext)
        //                {
        //                    temp.Add(s1);
        //                }
        //                if (temp.Count != 0)
        //                { //先进后出，新节点加到前面
        //                        temp = OpenList;
        //                        temp.Reverse();
        //                        tempNext.Reverse();
        //                        temp.AddRange(tempNext);
        //                        //OpenList.Clear();
        //                        OpenList = temp;
        //                        OpenList.Reverse();
        //                }
        //                OpenList.RemoveAt(0);
        //            }
        //        }
        //    }
        //    return false;//搜索失败
        //}


       /*算法思路：
        * 1.将s0加入open表
        * 2.检查open表是否为空，空返回失败
        * 3.取出一个节点，判断是否成功.成功则返回成功
        * 4.不成功则扩展该节点，将新节点加入open列表
        * 5.closed列表存储已经扩展的节点
        */
     
        private List<state> findState(state a1)
        {//找到某一状态的所有下一状态,并且赋值fatherID   
            byte[,] pltempS0 = state.Num2Plcomputer(a1.plstateNum);

            //show a1
            byte[,] showA1 = new byte[5, 4];
            showA1 = state.plComputer2show(state.Num2Plcomputer(a1.plstateNum));
            //每次的初始状态都相同

            List<state> nextS = new List<state>();
            for (byte id = 1; id < 11; id++)
            {//每个人物
                for (int dir = 4; dir > 0; dir--)
                {//每个方向 
                    byte[,] plshowS0 = new byte[5, 4];
                    plshowS0 = state.plComputer2show(pltempS0);
                    byte[,] plnextshow = new byte[5, 4];
                    Operate tempOp = new Operate();
                    tempOp.PersonID = id;
                    tempOp.dir = (Direction)dir;
                    state oneOfNextS = new state();
                    //得到PLcomputer

                    //byte[,] tempshow1 = new byte[5, 4];
                    //tempshow1 = state.plComputer2show(state.Num2Plcomputer(plnum));

                    //判断某个操作是否可行,可以就返回执行后的状态，否则false
                    if (state.calculateState(plshowS0, tempOp, out plnextshow))
                    {//该操作可行
                        //对父节点赋值
                        byte[,] tempPlnextshow = plnextshow;
                        oneOfNextS.plstateNum = state.Plcomputer2Num(state.plShow2computer(tempPlnextshow));
                        oneOfNextS.FatherID = a1.sID;
                        //public static byte correctSelectID(byte[,] pl,byte  selectID)
                        oneOfNextS.selectID = state.correctSelectID(plnextshow, id);
                        nextS.Add(oneOfNextS);
                    }
                }
            }
            //显示
            //for (int i = 0; i < nextS.Count; i++)
            //{
            //    //
            //    byte[,] a = new byte[5, 4];
            //    ulong plnum = nextS[i].plstateNum;
            //    a = state.plComputer2show(state.Num2Plcomputer(plnum));
            //}
            return nextS;
        }
        private List<state> findNextState(state a1)
        {//找到该状态的可加入表的下一状态
            List<state> tpSNext = new List<state>();
            List<state> NextState = new List<state>();
            tpSNext = state.findState(a1);

            //去掉已经有的状态
            for (int k = 0; k < tpSNext.Count; k++)
            {
                bool flagOpen = false;
                bool flagClosed = false;

                for (int i = 0; i < ClosedList.Count; i++)
                {
                    //当2个不同小兵移动时，数表相同就算相同
                    //if (ClosedList[i].plstateNum == tpSNext[k].plstateNum)
                    if (state.istheSameState(ClosedList[i].plstateNum, tpSNext[k].plstateNum))
                        flagClosed = true;
                }
                if (flagClosed)
                    continue;

                for (int i = 0; i < OpenList.Count; i++)
                {
                    if (state.istheSameState(OpenList[i].plstateNum, tpSNext[k].plstateNum))
                        // if (OpenList[i].plstateNum == tpSNext[k].plstateNum)
                        flagOpen = true;
                }
                if (flagOpen || flagClosed)
                {//不加入
                }
                else
                { //将新状态加入到opened列表
                    NextState.Add(tpSNext[k]);
                }
            }

            //显示
            //for (int i = 0; i < NextState.Count;i++ ) 
            //{
            //    //
            //    byte[,] a = new byte[5, 4];
            //    ulong plnum = NextState[i].plstateNum;
            //    a = state.plComputer2show(state.Num2Plcomputer(plnum));
            //}

            return NextState;
        }
    
        private bool isSuccess(state s1) 
        {//判断是否成功
            //输入人物ID，输出人物左上角点坐标
            int tempX = 11, tempY = 11;
            byte[,] S1state = new byte[5, 4];
            S1state = state.Num2Plcomputer(s1.plstateNum);
            S1state = state.plComputer2show(S1state);
            for (int i = 0; i < S1state.GetLength(0); i++)
            {
                for (int j = 0; j < S1state.GetLength(1); j++)
                {
                    if (S1state[i, j] == 1)
                    {
                        if (tempX > i) { tempX = i; }
                        if (tempY > i) { tempY = j; }
                    }
                }
            }
            if (tempX == 3 && tempY == 1)
                return true;
            else
                return false;
        }
        private void addStateToListBFS(state a1) 
        {//输入广度优先，将状态加入到尾巴
            List<state> temp = new List<state>();
            temp = findNextState(a1);
            if (temp.Count!=0) 
            {
                foreach(state one in temp)
                {
                    OpenList.Add(one);
                }
            }
        }

        private void findSucessList(state ssuc) 
        {//给出成功节点，找到最优解
            sucStateList.Add(ssuc);
            uint tempFID = ssuc.FatherID;
            while (tempFID!=1)
            {
                for (int i = 0; i < ClosedList.Count;i++ )
                {
                    if (tempFID == ClosedList[i].sID) 
                    {
                        sucStateList.Add(ClosedList[i]);
                        tempFID = ClosedList[i].FatherID;
                    }
                }
            }
            //sucStateList.Add(ssuc);

        }
    }
}
