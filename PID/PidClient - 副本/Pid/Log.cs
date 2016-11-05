using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PBPid.Base
{
    /// <summary>
    /// Log ��ժҪ˵����
    /// </summary>
    public class Log
    {
        //���ͻ��˶���
        public static object lockclient = new object();

        //������˶���
        public static object lockserver = new object();

        //��־�ļ��洢·��
        public static string filepath = "c:\\PidLog";

        public static void Record(string filename,System.Exception ex)
        {
            //Kevin 2009-08-30 ����
            //���ļ���ǰ�����ں�ʱ�䣬������־�ļ�����
            string tmpdir = filepath+ "\\log";
            string tmpdate=DateTime.Now.ToString("yyyy-MM-dd HH");
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            tmpdir += "\\" + tmpdate.Substring(0, 10);
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            string file = tmpdir +"\\"+tmpdate+"-"+ filename;
            try
            {
                if(filename.ToLower()=="client.log")
                {
                    lock (lockclient)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        sw.WriteLine("message:" + ex.Message);
                        sw.WriteLine("Source:" + ex.Source);
                        sw.WriteLine("StackTrace:" + ex.StackTrace);
                        sw.WriteLine("InnerException:" + ex.InnerException);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }
                else
                {
                    lock(lockserver)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        sw.WriteLine("message:" + ex.Message);
                        sw.WriteLine("Source:" + ex.Source);
                        sw.WriteLine("StackTrace:" + ex.StackTrace);
                        sw.WriteLine("InnerException:" + ex.InnerException);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
        }

        public static void Record(string filename,string head,byte[] buf,int count)
        {
            string tmpdir = filepath+ "\\log";
            string tmpdate = DateTime.Now.ToString("yyyy-MM-dd HH");
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            tmpdir += "\\" + tmpdate.Substring(0, 10);
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            string file = tmpdir + "\\" + tmpdate + "-" + filename;
            try
            {
                if(filename.ToLower()=="client.log")
                {
                    lock (lockclient)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                        string rstr = "";
                        for (int i = 0; i < count; i++)
                        {
                            if (i == 0)
                            {
                                rstr = "0x" + buf[i].ToString("X");
                            }
                            else
                            {
                                rstr += (", 0x" + buf[i].ToString("X"));
                            }
                        }

                        sw.WriteLine("message:" + head + rstr);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }
                else
                {
                    lock (lockserver)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                        string rstr = "";
                        for (int i = 0; i < count; i++)
                        {
                            if (i == 0)
                            {
                                rstr = "0x" + buf[i].ToString("X");
                            }
                            else
                            {
                                rstr += (", 0x" + buf[i].ToString("X"));
                            }
                        }

                        sw.WriteLine("message:" + head + rstr);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }
                
            }
            catch
            {
            }
        }

        public static void Record(string filename,string message)
        {
            string tmpdir = filepath + "\\log";
            string tmpdate = DateTime.Now.ToString("yyyy-MM-dd HH");
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            tmpdir += "\\" + tmpdate.Substring(0, 10);
            if (!Directory.Exists(tmpdir))
            {
                Directory.CreateDirectory(tmpdir);
            }

            string file = tmpdir + "\\" + tmpdate + "-" + filename;
            try
            {
                if(filename.ToLower()=="client.log")
                {
                    lock (lockclient)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        sw.WriteLine("message:" + message);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }
                else
                {
                    lock (lockserver)
                    {
                        System.IO.StreamWriter sw = new StreamWriter(file, true);
                        sw.WriteLine("#######################################");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        sw.WriteLine("message:" + message);
                        sw.WriteLine("#######################################");
                        sw.Close();
                    }
                }

            }
            catch
            {
            }
        }
    }
}
