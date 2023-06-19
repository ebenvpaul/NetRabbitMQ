# NetRabbitMQ
RabbitMQ Message Broker with C# Console Application
## Prerequisites

- [.NET Core 7 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)

## Getting Started

1. Clone the repository:

```
git clone https://github.com/ebenvpaul/NetRabbitMQ.git
cd your-repo
```

2. Build the Rabbit MQ Docker image from the root folder where yaml file is present:

```
docker-compose up -d
```
### Navigate to localhost:8080
```
http://localhost:8080/
Username:guest
Password:guest
```
![image](https://github.com/ebenvpaul/NetRabbitMQ/assets/24457351/09a788e2-45b8-41b9-960e-9a1bea1dd10f)


3. Run the RabbitSender:

```
dotnet run --project RabbitSender/RabbitSender.csproj  
```
4. Run the RabbitReciever:

```
dotnet run --project RabbitReceiver/RabbitReceiver.csproj 
```
5. Run the RabbitReciever1:

```
dotnet run --project RabbitReceiver1/RabbitReceiver1.csproj 
```
6. Run the RabbitReciever2:

```
dotnet run --project RabbitReceiver2/RabbitReceiver2.csproj 
```

## License

This project is licensed under the [MIT License](LICENSE).
