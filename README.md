# 太空RTS遊戲

## 專案注意項目
- Unity 引擎統一使用6000.0.33f1
- 盡量在自己的分支進行變更
- 需要pull 就盡量pull
- 有任何程式上的問題一律建議瑞爾
- Git/Github 有問題找帝江

## Git 常用指令(用github desktop的可以理解一下)
- git branch
  - 確認目前分支
- git checkout branch "branch_name"
  - 切換所在分支
- git add .
  - 所有檔案加入索引
- git status
  - 查詢現在這個目錄的狀態
- git push
  - 將目前分支推送至git hub 
- git pull origin branch_name
  - 將目標分支的檔案merge進目前的branch

## 架構

1. 開始頁面
2. (過場動畫)
3. 生成基礎設施
4. 給基本的$ & 艦
   - 造採礦艦
5. 敵人(摧毀陣地/回合守衛主堡)
   - (影響故事劇情)
6. 結束
7. 結束動畫
8. OVER


## 遊戲角色(Prefab)
- 我方主堡
- 驅逐艦(敵/我)
- 巡洋艦(敵/我)
- 戰列艦(敵/我)
- 採礦船(敵/我)
- 隕石
- 礦物

## 數值
- Ship
  - HP
  - ATK
  - DEF
  - SPD
  - CD
  - (特殊能力)
- 隕石
  - HP
  - Break_Times(?)
    

## Code
- Game
- Canvas
- OBJ
  - interface(四種艦的)
- GameManager
- AudioManager
- Tilemap(?)

## Scene
- Main Scene
- (過場)
- Game Scene
- (過場)
- End Scene
