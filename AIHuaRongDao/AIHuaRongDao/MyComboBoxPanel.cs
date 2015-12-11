using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIHuaRongDao
{
    internal class MyComboBoxPanel
    {
        //internal StartPanel selectPanel;  
       internal  List<StartPanel> list ;
     
        public MyComboBoxPanel(string Temptext) 
        {
            list = new List<StartPanel>();    
            CreateStartPanel(Temptext);           
        }

        /// 项目被选中时执行的操作
        /// </summary>

        internal void initStartPanel(StartPanel P) 
        {
            switch (P.name)
            {
                case "天罗地网":
                    P.PlState = new byte[5, 4]  {   //59k 347s                        
                        { 3, 1, 1, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 2, 2, 6 },
                        { 5, 7, 8, 6 },
                        { 9, 0, 0, 10 } };
                    P.level = "简单";
                    break;
                case "山在虚无缥缈问":
                    P.PlState = new byte[5, 4]  {   //59k 347s                        
                        { 3, 1, 1, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 2, 2, 6 },
                        { 5, 7, 8, 6 },
                        { 9, 0, 0, 10 } };
                    P.level = "简单";
                    break;
                case "相看雨不下":
                    P.PlState = new byte[5, 4]  {   //59k 347s                        
                        { 3, 1, 1, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 2, 2, 6 },
                        { 5, 7, 8, 6 },
                        { 9, 0, 0, 10 } };
                    P.level = "简单";
                    break;
                default:
                    P.PlState = new byte[5, 4]  {   //59k 347s                        
                        { 3, 1, 1, 4 },
                        { 3, 1, 1, 4 },
                        { 5, 2, 2, 6 },
                        { 5, 7, 8, 6 },
                        { 9, 0, 0, 10 } };
                    P.level = "简单";
                    break;
            }
        }

        internal  void CreateStartPanel(string level)
        {
            if(level == "简单")
            {
                list.Add(new StartPanel("天罗地网"));
                list.Add(new StartPanel("山在虚无缥缈问"));
                list.Add(new StartPanel("相看雨不下"));          
            }
            else if(level =="中等")
            {
                list.Add(new StartPanel("天罗地网"));
            }
            else
            {
                list.Add(new StartPanel("天罗地网"));
            }
        }
    }
}
