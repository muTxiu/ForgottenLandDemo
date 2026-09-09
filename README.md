# Forgotten Land Demo（遗忘之地 Demo）

基于 **Unity 2022.3 LTS** 开发的 **2D 动作 RPG 风格**游戏 Demo，个人游戏策划 / 技术练习作品。

## 🎮 玩法内容
- 玩家角色移动与控制
- 远程攻击系统（箭矢投射 + 命中判定）
- 敌人 AI（追击 / 攻击触发）
- 胜负判定（玩家死亡 / 击败目标获胜）
- 开始界面与游戏场景流程切换
- 攻击特效与销毁反馈

## 🗺️ 场景
| 场景 | 说明 |
| --- | --- |
| `StartScene` | 开始界面（进入游戏） |
| `GameScene` | 核心玩法场景 |

## 🧩 核心脚本（Assets/Script）
- `Player.cs`：玩家移动与行为
- `EnemyBase.cs`：敌人基类与行为
- `Arrow.cs` / `WeaponPivot.cs`：远程攻击与武器挂点
- `PlayerAttackTrigger.cs` / `EnemyAttackTrigger.cs`：攻击判定
- `DeadUI.cs` / `WinUI.cs`：胜负 UI
- `StartGameCanvas.cs`：开始界面逻辑

## 🚀 运行方式
1. 使用 **Unity 2022.3.62f3c1**（或 2022.3 LTS）打开本项目
2. 打开场景 `Assets/Scenes/StartScene.unity`
3. 点击 Play 运行

## 📂 目录结构
- `Assets/Ani`：动画资源
- `Assets/Materials`：材质
- `Assets/Prefab`：预制体
- `Assets/Scenes`：场景
- `Assets/Script`：C# 脚本
- `Assets/Sprites`：精灵图（UI / 角色）
- `Assets/Tilemap`：瓦片地图
- `Assets/TextMesh Pro`：字体与 TMP 资源

## 📌 说明
本项目为个人学习与求职作品集 Demo；素材仅用于学习与展示，若涉及第三方资源版权归原作者所有。