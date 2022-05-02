using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
public class CDBSQLBase
{
 //建立数据库连接
        public static SqlConnection connection = new SqlConnection(CommonInfo.connString);
        
        //使用SqlCommand对象，执行查询操作，返回SqlDataReader对象。
        public static SqlDataReader executeSelectSql(string selectSql)
        {
            SqlDataReader sdr = null;

            try
            {
                SqlCommand command = new SqlCommand(selectSql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                sdr = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return sdr;
        }

        //使用SqlCommand对象，执行查询操作，返回单一值。
        public static Object executeScalar(string selectSql)
        {
            Object result = null;

            try
            {
                SqlCommand command = new SqlCommand(selectSql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }   

        //使用SqlCommand对象，执行添加操作。
        public static int executeInsertSql(string intsertSql)
        {
            int result = 0;
            
            try
            {
                SqlCommand command = new SqlCommand(intsertSql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"添加失败",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        //使用SqlCommand对象，执行删除操作。
        public static int executeDeleteSql(string deleteSql)
        {
            int result = 0;

            try
            {
                SqlCommand command = new SqlCommand(deleteSql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        //使用SqlCommand对象，执行修改操作。
        public static int executeUpdateSql(string updateSql)
        {
            int result = 0;

            try
            {
                SqlCommand command = new SqlCommand(updateSql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        //使用数据适配器填充数据集，返回DataSet对象。
        public static DataSet getDataSet(string selectSql, string tableName)
        {
            DataSet dataSet = new DataSet(tableName);
            
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, connection);

                dataAdapter.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataSet;
        }
}
}