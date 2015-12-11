using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIHuaRongDao
{
    internal struct state
    {
        private ulong PlstateNum;
        public ulong plstateNum
        {
            get { return PlstateNum; }
            set { PlstateNum = value; }
        }
        //public byte[,] PlState;  //状态表 5*4
        public byte selectID;    //该状态下，被选中的人 
        private uint stateID;//状态的唯一编号
        private uint fatherID; //状态的唯一父节点标号
        
        //public uint StateID { set; get; }     
        //public uint FatherID { set; get; }   
            //PlState = new byte[5, 4];
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        PlState[i, j] = NumState[i, j];
            //    }
            //}
        public state(byte[,] NumState) 
        {   
            selectID = 0;
            fatherID = 1;
            stateID = 1;
            //更新被选中的人物序号
            selectID = correctSelectID(NumState, selectID);
            PlstateNum = Plcomputer2Num(NumState);
        }

        public static ulong Plcomputer2Num(byte[,] pl)
        { //将一个数字表转化为一个数字
            //1.将数字表的小兵改为7
            //2.将对应的selectedID同时改掉，看小兵所在的顺序改
            //3.然后转化为数字
            // public static byte[,] stateNum7(byte[,] plstate,byte selectID,out byte newID) 

            byte[,] pltemp = new byte[5, 4];
            pltemp = pl;

            ulong numS = 0;
            ulong tempNum = 0;           
            for (int i = 0; i < pl.GetLength(0);i++ )
            {
                for (int j = 0; j < pl.GetLength(1); j++)
                {
                    tempNum = (ulong)pl[i, j];                    
                    numS = numS | tempNum;
                    numS = numS << 3;                 
                }
            }
            return numS;
        }

        public static byte correctSelectID(byte[,] pl,byte  selectID) 
        {//将小兵序号都变成7时，同时修改被选中的小兵序号，按照先后排
            //1.找到选中小兵的按顺序序号
            if (selectID < 7) 
                return selectID;
             byte count = 0;
            for (int i = 0; i < pl.GetLength(0); i++)
            {
                for (int j = 0; j < pl.GetLength(1); j++)
                {
                    if (pl[i, j] >= 7 && pl[i, j]<11)
                    {
                        count++;                        
                    }
                    if (pl[i, j] == selectID)
                    {
                        return (byte)(selectID + count-1);                      
                    }
                }
            }
            return selectID;
        }
        public static  byte[,]  Num2Plcomputer(ulong numState) 
        {
            //将一个数字转化为一个数字表
            byte[,] myPlState = new byte[5, 4];
            ulong standNum = 7;
            ulong temp = 0;
            numState = numState >> 3;
            for (int i = 4; i >= 0;i-- )
            {
                for (int j = 3; j >= 0; j--)
                {                   
                    temp = standNum & numState;                 
                    myPlState[i, j] = Convert.ToByte(temp); 
                    numState = numState >> 3;
                }
            }
            return myPlState;
        }
       

        public uint sID
        {
            get { return stateID; }
            set { stateID = value; }
        }
       
        public uint FatherID
        {
            get { return fatherID; }
            set { fatherID = value; }
        }
        public static Point getLocation(byte[,] S0state, byte PersonID)
        {//输入数表和人物ID，输出人物左上角点坐标
            int tempX = 11, tempY = 11;
            ////得到有4个7的数表
            //S0state = state.BinNum2PlState(S0.plstateNum);
            ////将4个7按照顺序赋值，还原为7、8、9、10
            //S0state = state.stateNum78910(S0state);
            for (int i = 0; i < S0state.GetLength(0); i++)
            {
                for (int j = 0; j < S0state.GetLength(1); j++)
                {
                    if (S0state[i, j] == PersonID)
                    {
                        if (tempX > i) { tempX = i; }
                        if (tempY > j) { tempY = j; }
                    }
                }
            }
            return new Point(tempY, tempX);
        }

        public static Point[] getZero(byte[,] plshow) 
        {//输入数表plshow，输出2个0的位置
            Point[] zeroL = new Point[2];
            int k = 0;
            //byte[,] S0state = new byte[5, 4];
            //S0state = state.BinNum2PlState(S0.plstateNum);
            for (int i = 0; i < plshow.GetLength(0); i++)
            {
                for (int j = 0; j < plshow.GetLength(1); j++)
                {
                    if (plshow[i, j] == 0)
                    {
                        zeroL[k].X = j;
                        zeroL[k].Y = i;
                        if (k == 0) k = 1;
                    }
                }
            }
            return zeroL;
        }
        //public static bool calculateState(state S0, operate op, out state nextS)
     
        
        /// <summary>
        /// 判断某个操作是否可行,可以移动就返回执行后的状态plshow，否则false
        /// </summary>
        /// <param name="S0state" plshow></param>
        /// <param name="op"></param>
        /// <param name="nextStste"></param>
        /// <returns></returns>
        public static bool calculateState(byte[,] S0state, operate op, out byte[,] nextStste)
        {
             nextStste = new byte[5, 4];
             byte[,] temps0 = new byte[5, 4];
             temps0 = S0state;
             nextStste = S0state;
            //byte[,] S0state = new byte[5, 4];
            ////将数字转化为数表，并将4个7还原为7、8、9、10
            //S0state = state.BinNum2PlState(S0.plstateNum);
            //S0state = state.stateNum78910(S0state);
             Point LocP = getLocation(temps0, op.PersonID);
            Point[] zero = new Point[2];
            zero = getZero(temps0);
           // Point size = findPersonLSize(op.PersonID);           
            //nextS = S0;//赋初值   
            //nextS.selectID = op.PersonID;
            //找到移动人物的方格种类
            PStyles style = findStyle(op.PersonID);
            Point zero1 = new Point(zero[0].Y,zero[0].X);
            Point zero2 = new Point(zero[1].Y, zero[1].X);
            //人物方块在数表中的位置 pox为第几行poy为第几列
            int pRow = LocP.Y;
            int pCol = LocP.X;
 
            switch (op.dir)
            {
                case Direction.UP:
                    if (pRow - 1 < 0 )//边界控制 
                        return false;    
                    switch (style)
                    {//向上时
                        //case 1://直接换
                        case PStyles.P1://直接换
                            if (new Point( pRow - 1,pCol) == zero1 || new Point( pRow - 1,pCol) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow-1, pCol] = op.PersonID;
                                return true;
                            }
                            else 
                                return false;                               
                        //case 2: //日
                        case PStyles.P2V: //日
                            if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow - 1, pCol) == zero1 || new Point(pRow - 1,pCol) == zero2)
                            {
                                nextStste[pRow+ 1, pCol ] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;                                 
                        //case 3: //口口
                        case PStyles.P2H:  //口口
                             if (pCol+ 1 > 3) return false;//-------------
                            if (new Point(pRow- 1, pCol ) == zero1 && new Point(pRow - 1, pCol+ 1 ) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                nextStste[pRow - 1, pCol+ 1 ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;  
                        //case 4: //田
                        case PStyles.P4:  //田
                             if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow- 1, pCol ) == zero1 || new Point(pRow- 1, pCol ) == zero2)
                            {
                                nextStste[pRow + 1, pCol ] = 0;
                                nextStste[pRow + 1, pCol + 1] = 0;
                                nextStste[pRow- 1, pCol ] = op.PersonID;
                                nextStste[pRow- 1 , pCol+ 1 ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;  
                    }
                    break;
                case Direction.down:
                    if (pRow + 1 > 4) //边界控制
                        return false;
                    switch (style)
                    {       //向下时
                        case PStyles.P1://直接换
                            if (new Point(pRow+ 1, pCol ) == zero1 || new Point(pRow + 1, pCol) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 1, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2V: //日
                            if (pRow + 2 > 4) //边界控制
                                return false;
                            if (new Point(pRow+ 2, pCol ) == zero1 || new Point(pRow+ 2, pCol) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 2, pCol ] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2H:  //口口
                             if (pCol + 1 > 3) return false;//-------------
                            if (new Point(pRow+ 1, pCol ) == zero1 && new Point(pRow+1, pCol + 1) == zero2)
                            {  
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol + 1] = 0;
                                nextStste[pRow+ 1, pCol ] = op.PersonID;
                                nextStste[pRow+ 1, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P4:  //田
                            if (pRow + 2 > 4 || pCol + 1 > 3) //边界控制
                                return false;
                            if (new Point(pRow+ 2, pCol ) == zero1 && new Point(pRow+2, pCol + 1) == zero2)
                            {  
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow+ 2, pCol] = op.PersonID;
                                nextStste[pRow + 2, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
                case Direction.left:
                    if (pCol -1 < 0) //边界控制
                        return false;
                    switch (style)
                    {           //向左时
                        case PStyles.P1://直接换
                            if (new Point(pRow, pCol-1) == zero1 || new Point(pRow, pCol-1 ) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2V: //日
                             if (pRow + 1 > 4) return false;//-------------
                            if (new Point(pRow, pCol-1) == zero1 && new Point(pRow+1, pCol-1) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+ 1, pCol ] = 0;
                                nextStste[pRow , pCol - 1] = op.PersonID;
                                nextStste[pRow +1, pCol - 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2H:  //口口 
                            if (pCol+ 1 > 3) return false;//-------------
                            if (new Point(pRow, pCol-1) == zero1 || new Point(pRow, pCol -1) == zero2)
                            { 
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P4:  //田
                             if (pCol+ 1 > 3||pRow+ 1>4) return false;//-------------
                            if (new Point(pRow, pCol-1 ) == zero1 && new Point(pRow + 1, pCol - 1) == zero2)
                            {
                                nextStste[pRow , pCol+ 1] = 0;
                                nextStste[pRow+ 1, pCol + 1] = 0;
                                nextStste[pRow , pCol- 1] = op.PersonID;
                                nextStste[pRow + 1, pCol - 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
                case Direction.right:
                    if (pCol + 1 > 3) //边界控制
                        return false;
                    switch (style)
                    {           //向右时
                        case PStyles.P1://直接换
                            if (new Point(pRow, pCol+1) == zero1 || new Point(pRow , pCol+ 1) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol+ 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2V: //日
                             if (pRow + 1>4) return false;//-------------
                            if (new Point(pRow, pCol+1) == zero1 && new Point(pRow + 1, pCol + 1) == zero2)
                            { 
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+1,pCol] = 0;
                                nextStste[pRow , pCol+ 1] = op.PersonID;
                                nextStste[pRow + 1, pCol + 1] = op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P2H:  //口口
                            if (pCol + 2 > 3) //边界控制
                                return false;
                            if (new Point(pRow, pCol+2) == zero1 || new Point(pRow , pCol+ 2) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow, pCol + 2] = (byte)op.PersonID;
                                return true;
                            }
                            else
                                return false;
                        case PStyles.P4:  //田
                            if (pCol + 2 > 3) //边界控制
                                return false;
                            if (new Point(pRow, pCol+2) == zero1 && new Point(pRow + 1, pCol + 2) == zero2)
                            {
                                nextStste[pRow, pCol] = 0;
                                nextStste[pRow+1, pCol ] = 0;
                                nextStste[pRow , pCol+ 2] = op.PersonID;
                                nextStste[pRow+1,pCol +2] = op.PersonID;
                                return true;
                            }
                            else
                                return false; 
                    }
                    break;
            }

            return true;
        }
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
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public static Point findPersonLSize(int ID)
        //{
        //    switch (ID)
        //    {
        //        case 1: return new Point(2, 2);
        //        case 2: return new Point(2, 1);
        //        case 3: return new Point(1, 2);
        //        case 4: return new Point(1, 2);
        //        case 5: return new Point(1, 2);
        //        case 6: return new Point(1, 2);
        //        case 7: return new Point(1, 1);
        //        case 8: return new Point(1, 1);
        //        case 9: return new Point(1, 1);
        //        case 10: return new Point(1, 1);
        //        default: return new Point(0, 0);
        //    }
        //}

        //P1 = 0,//口
        //P4 = 1,//田
        //P2V = 2,//日
        //P2H = 3,//口口
        //P0 = 5 空格       
        
        public static PStyles findStyle(int ID) 
        {
            PStyles myStyle ;
            switch (ID)
            {
                case 1: 
                    myStyle = PStyles.P4;
                    break;
                case 2: 
                       myStyle = PStyles.P2H; 
                    break;
                case 3: 
                    myStyle = PStyles.P2V; 
                    break;
                case 4: 
                    myStyle = PStyles.P2V; 
                    break;
                case 5: 
                    myStyle = PStyles.P2V; 
                    break;
                case 6: 
                    myStyle = PStyles.P2V;
                    break;
                case 7: 
                    myStyle = PStyles.P1;
                    break;
                case 8: 
                    myStyle = PStyles.P1;
                    break;
                case 9:
                    myStyle = PStyles.P1;
                    break;
                case 10: 
                    myStyle = PStyles.P1;
                    break;
                default: 
                    myStyle = PStyles.P0;
                    break;
            }
            return myStyle;
        }
      
        /// <summary>
        /// 将小兵的序号全部变成7,从显示状态变为存储状态
        /// </summary>
        ///同时考虑修改selectedID 
        /// <param name="plstate"></param>
        /// <returns></returns>
        public static byte[,] plShow2computer(byte[,] plstate) 
        {
            byte[,] temp = new byte[5, 4];
            for (int i = 0; i < plstate.GetLength(0); i++)
            {
                for (int j = 0; j < plstate.GetLength(1); j++)
                {
                    if (plstate[i, j] > 7) 
                        plstate[i, j] = 7;                   
                    temp[i, j] = plstate[i, j];
                }
            }
            return temp;
        }      

        /// <summary>
        /// 将小兵序号从全7变为7\8\9\10,方便显示
        ///由于4个小兵样子一样，所以位置可以对调，所以共有11-3=8种可能性
        /// </summary>
        /// <param name="plstate"></param>
        /// <returns></returns>
        public static byte[,] plComputer2show(byte[,] plstate)
        {
            byte[,] newplState = new byte[5, 4];
            newplState = plstate;
            byte[,] temp = new byte[5, 4];
            byte count = 0;
            for (byte i = 0; i < newplState.GetLength(0); i++)
            {
                for (byte j = 0; j < newplState.GetLength(1); j++)
                {
                    if (newplState[i, j] == 7)
                    {
                        temp[i, j] = (byte)(newplState[i, j] + count);
                        count++;
                    }
                    else 
                    {
                        temp[i, j] = newplState[i, j];
                    }
                }
            }
            return temp;
        }
        /// <summary>
        /// 判断2个状态是否相同
        /// </summary>
        /// <param name="a 状态1"></param>
        /// <param name="b 状态2"></param>
        /// <returns></returns>
        public static bool istheSameState(ulong a,ulong b) 
        {         
            ulong stand = 7;
            ulong tempa = 0;
            ulong tempb = 0;
            a = a >> 3;
            b = b >> 3;           
            for (int j = 0; j < 20; j++)
            {
                tempa = stand & a;
                tempb = stand & b;
                if (tempa != tempb) 
                {
                    if (tempa < 7 && tempa > 2 && tempb > 2 && tempb < 7)
                    { }
                    else
                        return false;
                }                   
                a = a >> 3;
                b = b >> 3;
            }            
             return true;             
        }

        /// <summary>
        /// 输入某状态，输出所有可行的下一状态，并且赋值fatherID   
        /// </summary>
        /// <param name="a1"></param>
        /// <returns></returns>
        internal static List<state> findState(state a1)
        {
            byte[,] pltempS0 = state.Num2Plcomputer(a1.plstateNum);

            //show a1
            //byte[,] showA1 = new byte[5, 4];
            //showA1 = state.plComputer2show(state.Num2Plcomputer(a1.plstateNum));
            //每次的初始状态都相同
            List<state> nextS = new List<state>();
            for (byte id = 1; id < 11; id++)
            {//每个人物
                for (int dir = 4; dir > 0; dir--)
                {//每个方向 
                    byte[,] plshowS0 = new byte[5, 4];
                    plshowS0 = state.plComputer2show(pltempS0);
                    byte[,] plnextshow = new byte[5, 4];
                    operate tempOp = new operate();
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

    }
     
   

}
