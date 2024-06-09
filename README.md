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
 - Framework Build Support: Can build files of popular frameworks like Angular and React.

### Technologies:
- C#
- .NET
- TCP/IP

### How to use
1. Using the command prompt
  You can move into the webserver.exe folder and run in the command prompt
  ```
  webserver <path-to-the-folder> <port>
  ```
2. Using application prompt ( demo )
   
https://github.com/mathanraj0601/http-server/assets/98396468/b59ca401-dc1c-4a5f-87d6-0a4c9548650a


#### Learnings and Documentation:
Curious to dive deeper? I've documented my learnings and insights throughout this project. Read the [documentation](https://deeply-sneeze-d1c.notion.site/Simple-HTTP-Server-ab6f5c5e16d4411da70d8b85971f268b) here.


#### Download and Installation:
Ready to give it a try? You can download and install the executable [here](https://github.com/mathanraj0601/http-server/releases). 
 Password for setup : mr


