# 太空RTS遊戲

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
