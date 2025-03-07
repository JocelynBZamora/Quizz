using QuizzClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizzClient.Services
{
    internal class RespuestaCliente
    {
        private UdpClient cliente;

        public RespuestaCliente()
        {
            cliente = new();
            cliente.EnableBroadcast = true;

        }
        public void Enviar(RespuestaModel r)
        {
          
            //destino 
            IPEndPoint servidor = new(IPAddress.Broadcast, 65000);

            //paquete
            var json = JsonSerializer.Serialize(r);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            //envia
            cliente.Send(buffer,buffer.Length,servidor);
        }

 
    }
}
