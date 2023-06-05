# LocationDetector

This project is my solution to the technical challenge for the backend developer opportunity at [Croct](https://www.linkedin.com/company/croct/), is a standalone application that translates IP addresses from a stream of events into geographical locations. It reads input events, translates the IP addresses to location information, and writes the processed events to an output stream. The application is built using .NET Core 7 and follows the specified requirements.

## Requirements

- .NET Core 7 SDK

## Getting Started

1. Clone the repository:

   ```shell
   git clone https://github.com/highotz/LocationDetector.git
   cd LocationDetector

2. Install the .NET Core 6 SDK (if not already installed). Refer to the official documentation for instructions: [Download .NET Core 7 SDK](https://dotnet.microsoft.com/pt-br/download)

3. Configure the application, update the configuration file to specify the desired input stream reader Upload:(CSV or JSONL), TranslationChannel(CSV or API), and output stream writer Response(CSV or JSONL).

3. Build the application:
   ```shell
   dotnet build

4. Run the application:
   ```shell
   dotnet run --configuration Debug --project LocationDetector.API/LocationDetector.API.csproj

