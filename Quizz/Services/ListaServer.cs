using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace QuizzServer.Services
{
    internal class ListaServer
    {
        TcpListener server;
        List<TcpClient> clients;

        public ListaServer()
        {
            clients = new List<TcpClient>(); // Inicializa la lista
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Thread peticiones = new Thread(AceptarPeticiones)
            {
                IsBackground = true
            };
            peticiones.Start();
        }

        void AceptarPeticiones()
        {
            try
            {
                while (true)
                {
                    TcpClient tcpClient = server.AcceptTcpClient();
                    lock (clients) // Bloqueo para evitar conflictos de hilos
                    {
                        clients.Add(tcpClient);
                    }

                    Thread hilo = new Thread(EscucharCliente)
                    {
                        IsBackground = true
                    };
                    hilo.Start(tcpClient); // Ahora pasa el cliente como argumento
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en AceptarPeticiones: " + ex.Message);
            }
        }

        void EscucharCliente(object cliente)
        {
            if (cliente is TcpClient Client)
            {
                NetworkStream stream = Client.GetStream();
                byte[] buffer = new byte[1024];

                try
                {
                    while (Client.Connected)
                    {
                        int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                        if (bytesLeidos == 0) break; // Cliente desconectado

                        string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                        Debug.WriteLine($"Mensaje recibido: {mensaje}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error en EscucharCliente: " + ex.Message);
                }
                finally
                {
                    lock (clients)
                    {
                        clients.Remove(Client);
                    }
                    Client.Close();
                }
            }
        }
    }
}
