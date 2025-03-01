using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace QuizzServer.Services
{
    internal class ListaServer
    {
        UdpClient Servidor;
        public ListaServer()
        {
            Servidor = new(65000);
            Servidor.EnableBroadcast = true;

        }
        void ResivirRespuesta()
        {
            while (true)
            {
                IPEndPoint cliente = new(IPAddress.Any, 0);
                byte[] Buffer = Servidor.Receive(ref cliente);
                
                var json =Encoding.UTF8.GetString(Buffer);
               
                //var rect = JsonSerializer.Deserialize
            }
        }
    }
}

