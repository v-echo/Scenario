### Implementation 3

Here we showcase 2 different approaches to client-server result streaming:
1. Polling to a WebAPI endpoint
2. Real-time communication using a persistent SignalR connection

The client here is a Blazor server-side application.

#### Usage
Just build and run the projects (requires Visual Studio 2022 and .NET 6)

Each calculation has a random delay, which can be changed by user input. I recommend using shorter values for these, for faster feedback.

Note that for the WebAPI version, the polling interval is set to 2 seconds in code, which means that sequence generation can outpace the requests if set to a very short interval (like 1 second minimum, 1 second maximum). Not a problem, just an fyi.