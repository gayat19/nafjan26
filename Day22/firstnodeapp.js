// server.mjs
import fs from 'node:fs';
import { createServer } from 'node:http';

const server = createServer((req, res) => {
  var data = fs.readFileSync('MyPage.html');
  res.writeHead(200, { 'Content-Type': 'text/html' });
  res.end(data);

});

// starts a simple http server locally on port 3000
server.listen(3000, '127.0.0.1', () => {
  console.log('Listening on 127.0.0.1:3000');
});

// run with `node server.mjs`