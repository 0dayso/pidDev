using System;
using System.Net;
using System.Net.Sockets;

namespace PBPid.Base
{
    /// <summary>
    /// Address ��ժҪ˵����
    /// </summary>
    public class Address
    {
        public Address()
        {
        }
        //��ȡ����IP�����û�����ȡ192�ĵ�ַ
        public static IPAddress GetExternalIPAddress()
        {
            IPAddress ret = null;
            string host = Dns.GetHostName();
            IPHostEntry ety = Dns.GetHostByName(host);

            //��¼192�ĵ�ַ

            foreach (IPAddress ip in ety.AddressList)
            {
                byte cls = ip.GetAddressBytes()[0];
                if (cls != 127 && cls != 169 && cls != 10 && cls != 192 && (cls < 224 || cls > 239))
                {
                    ret = ip;
                    break;
                }
                else if(cls==192)
                {
                    ret = ip;
                }
            }
            return ret;
        }

        //��ȡ��һ��IP
        public static IPAddress GetFirstIPAddress()
        {
            string host = Dns.GetHostName();
            return Dns.GetHostByName(host).AddressList[0];
        }

        //ȡ��10.150��IP��ַ�������ƶ�����̨��
        public static string GetDlanIP()
        {
            string host = Dns.GetHostName();
            IPHostEntry ety = Dns.GetHostByName(host);

            //��¼192�ĵ�ַ

            foreach (IPAddress ip in ety.AddressList)
            {
                byte cls = ip.GetAddressBytes()[0];
                byte cls2 = ip.GetAddressBytes()[1];
                if (cls == 10)
                {
                    return ip.ToString();
                }
            }
            return "";
        }
    }
}
