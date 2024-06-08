### Simple and Powerful Static HTTP Server
This repository provides a lightweight and easy-to-use static file server for your development needs. It offers multithreading for performance, timeout control for connection management, and broad file support for serving various static content.

### Key Features:
- TCP Server: Registers a socket to handle incoming requests, reading, writing, and closing connections.
- Multithreading: Utilizes multiple threads to process requests concurrently, improving performance and scalability.
- Data Interpretation: Parses HTTP requests and serves the appropriate static content based on the URL.
- Thread Pool: Implements a thread pool to manage resources efficiently, reusing threads to handle requests without creating new ones each time.
- Timeout Mechanism: Ensures server efficiency by canceling long-running processes and reallocating resources to handle new requests.
- Expanded File Support: Serves a variety of static files beyond basic HTML and CSS, including:
   - HTML (.html)
   - Cascading Style Sheets (CSS)
   - Favicons (ICO)
   - JavaScript (JS)
   - Images (e.g., JPG, PNG, GIF)
   - And more! (depending on configuration)

### Technologies:
- C#
- .NET
- TCP/IP

### How to use
1. Using command prompt
  You can move into the webserver.exe folder and run in the command prompt
  ```
  webserver <path-to-the-folder> <port>
  ```

2. Using application prompt
