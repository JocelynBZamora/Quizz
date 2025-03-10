﻿using QuizzServer.Model;
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
    public class ListaServer
    {
        UdpClient Servidor;
        public ListaServer()
        {
            Servidor = new(65000);
            Servidor.EnableBroadcast = true;

            Thread hilo = new(ResivirRespuesta);
            hilo.IsBackground = true;
            hilo.Start();

        }
        public event Action<Respuesta>? PersonaResivida;

        void ResivirRespuesta()
        {
            while (true)
            {
                IPEndPoint cliente = new(IPAddress.Any, 0);
                byte[] Buffer = Servidor.Receive(ref cliente);

                var json = Encoding.UTF8.GetString(Buffer);


                var rect = JsonSerializer.Deserialize<Respuesta>(json);
                if (rect != null)
                {
                    try
                    {

                        PersonaResivida?.Invoke(rect);
                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex.Message);
                    }
                }

            }
        }
        void EnviarTiempo(Tiempo r)
        {
            //destino 
            IPEndPoint servidor = new(IPAddress.Broadcast, 65000);

            //paquete
            var json = JsonSerializer.Serialize(r);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            //envia
            Servidor.Send(buffer, buffer.Length, servidor);
        }
    }
}

