# Game

[English](./README.md) | 繁體中文

一個使用 C# 開發的簡單終端機數學遊戲，玩家需要回答隨機產生的數學題目，答對即可獲得分數。

![Screenshot](./Screenshot.png)

---

## Features

- 使用選單選擇想要挑戰的數學模式 (+, -, ×, ÷)
- 每局至少 5 題
- 分數追蹤系統
- 遊戲記錄儲存在記憶體中
- 可以查看之前的遊戲結果

---

## Tech Stack

- C# / .NET
- 控制台應用程式

---

## Getting Started

### Run on Linux / macOS
1. 從 [Releases page](../../releases) 下載最新的版本。
2. 打開終端機並移動到您的下載資料夾：
```bash
   cd ~/Downloads
```
3. 讓檔案可執行化:
```bash
   chmod +x Game
```
4. 運行遊戲:
```bash
   ./Game
```

---

## How to Play

1. 啟動遊戲並從選單中選擇一個數學模式。
2. 回答至少 5 個隨機產生的問題。
3. 每答對一題即可獲得分數。
4. 遊戲結束後查看您的總得分。
5. 從歷史記錄查看之前的遊戲分數。

---

## Roadmap

- [ ] 難度等級 (Easy / Medium / Hard)
- [ ] 計時功能
- [ ] 將歷史記錄儲存到文字檔
- [ ] 排行榜

---

## License

本專案採用 [MIT License](./LICENSE.md) 授權。