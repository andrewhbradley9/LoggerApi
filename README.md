# LoggerApi

A RESTful logging API built with ASP.NET Core and AWS DynamoDB, 
following a clean service/repository architecture.

## Tech Stack
- ASP.NET Core Web API (.NET 10)
- AWS DynamoDB
- Service/Repository pattern
- Dependency Injection
- Global exception handling

## Architecture
```
Controller → Service → Repository → DynamoDB
```

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/logs | Create a new log entry |
| GET | /api/logs | Get all logs |
| GET | /api/logs?userId=x | Get logs for a specific user |

## Setup

### Prerequisites
- .NET 10 SDK
- AWS account with DynamoDB access
- AWS credentials configured locally

### DynamoDB Table Setup
Create a table in AWS DynamoDB:
- Table name: `Logs`
- Partition key: `UserId` (String)
- Sort key: `Timestamp` (String)

### Running Locally
1. Clone the repo
```bash
git clone https://github.com/andrewhbradley9/LoggerApi.git
cd LoggerApi
```

2. Configure AWS credentials
```bash
aws configure
```

3. Run the API
```bash
dotnet run
```

4. Open Swagger UI at `http://localhost:5050/openapi`

## Design Decisions
- **DynamoDB** was chosen for its ability to scale horizontally 
and its natural fit for time-series log data using UserId as 
the partition key and Timestamp as the sort key
- **Repository pattern** abstracts the data layer making the 
service layer portable and independently testable
- **Global exception handling** middleware ensures consistent 
error responses without try/catch on every endpoint
