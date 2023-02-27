using CRUD.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace CRUD.Application.Services
{
    public class RabbitMQService : IRabbitMQ
    {
        public void Add()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Empregado",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            const string message = "Empregado";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "Empregado",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
