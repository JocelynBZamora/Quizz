using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Services
{
    internal class ListaServer
    {
        TcpListener server;
        List<TcpClient> clients;
        public ListaServer()
        {
            server = new(System.Net.IPAddress.Any, 5000);
            server.Start();
            Thread periciones = new(AceptarPeticiones);
            periciones.IsBackground = true;
            periciones.Start();
        }
        void AceptarPeticiones()
        {
            try
            {
                while (true)
                {
                    TcpClient tcpClient = server.AcceptTcpClient();
                    clients.Add(tcpClient);
                    Thread hilo = new(EscucharCliente);
                    hilo.IsBackground = true;
                    hilo.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);    
            }
        }
        void EscucharCliente(object cliente)
        {
            if (cliente != null)
            {
                TcpClient Client = (TcpClient) cliente;
                while (Client.Connected)
                {

                }
            }
        }
    }
}
