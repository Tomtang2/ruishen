using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;


namespace ruishen.数据库公告类
{
    class MysqlHelper
    {
        MySqlConnection conn = null;
        MySqlCommand com = null;
        MySqlDataReader rd = null;
        string constr = "server=localhost;database=faultdiagnosis;uid=root;pwd=ttb1996;charset=utf8;Allow User Variables=True";
        #region 连接数据库
        public bool ConnectMySql()
        {   // 连接数据库
            try
            {
                conn = new MySqlConnection(constr);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public bool CreateTable(string sql) 
        {
            try
            {
                ConnectMySql();   //打开连接
                com = new MySqlCommand(sql, conn);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
             finally //关闭连接
            {
                closeConn();
            }
        }

        #region 实现增删改操作
        public bool MySqlPour(string sql, Dictionary<string, object> dic)
        {   //可完成增删改
            try
            {
                ConnectMySql();   //打开连接
                com = new MySqlCommand(sql, conn);
                if (dic != null)
                {
                    foreach (var item in dic)
                    {
                        com.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally //关闭连接
            {
                closeConn();
            }
        }
        #endregion
        #region 实现查询操作
        public ArrayList SelectInfo(string sql, Dictionary<string, object> dic)
        {   //可完成查找操作，以Object存取放入ArrayList返回
            try
            {
                ConnectMySql();   //打开连接
                com = new MySqlCommand(sql, conn);
                ArrayList al = new ArrayList();
                if (dic != null)
                {
                    foreach (var item in dic)
                    {   //遍历参数并进行赋值，防止sql注入
                        com.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                
                rd = com.ExecuteReader();
                int clumn = 0;  //得到数据的列数
                if (rd.Read())
                {
                    clumn = rd.FieldCount;
                }
                else
                {
                    return null;
                }
                do
                {   //读取每行每列的数据并放入Object数组中
                    Object[] obj = new object[clumn];
                    for (int i = 0; i < clumn; i++)
                    {
                        obj[i] = rd[i];
                    }
                    al.Add(obj);    //将一行数据放入数组中
                } while (rd.Read());
                return al;
            }
            catch
            {
                return null;
            }
            finally
            {
                closeConn();
            }

        }
        #endregion

        #region 关闭数据库连接
        public void closeConn()
        {   //关闭数据库连接
            try
            {
                if (conn != null) { conn.Close(); }
                if (rd != null) { rd.Close(); }
            }
            catch
            {
                return;
            }

        }
        #endregion



    }
}
