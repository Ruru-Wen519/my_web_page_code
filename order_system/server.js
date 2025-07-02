// import express from 'express';
// import path from 'path';
const express = require('express');
const cors = require('cors');
const path = require('path');

const app = express();
const port = process.env.PORT || 3000;
app.use(cors());

// 設置靜態檔案目錄
app.use(express.static(path.join(__dirname, 'order_system')));
// 設置靜態資源目錄並手動設定 MIME 類型
// app.use('/static', express.static(path.join(__dirname, 'order_system'), {
//   setHeaders: (res, filePath, stat) => {
//     if (filePath.endsWith('.css')) {
//       res.setHeader('Content-Type', 'text/css');
//     } else if (filePath.endsWith('.js')) {
//       res.setHeader('Content-Type', 'application/javascript');
//     }
//   }
// }));

// 處理所有路由,將其指向 index.html
app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'index.html'));
});

// 處理 API 請求
app.get('/api/data', (req, res) => {
  // 在這裡實現您的 API 邏輯
  const data = { message: 'Hello from the server!' };
  res.json(data);
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});