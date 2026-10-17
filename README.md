# Rotate the Fate

2D pixel platformer made in Unity by a four-person team for NUS 24SWS (2D Game Development), July 2024.
四人团队在 NUS 24SWS 暑期课程中开发的 2D 像素平台跳跃游戏。

- **Authors**: Liang Chenhao 梁辰浩, Hou Guangyu 侯光宇, He Hui 何晖, Zhang Hongjian 张宏建
- **Original repo**: [KouHiiChan/NUS_24SWS_2D_Game_Development](https://github.com/KouHiiChan/NUS_24SWS_2D_Game_Development) (full history migrated here)
- **Showcase build**: tag `v1.0-showcase`
- **Design doc**: [Game_Design_Document.md](Game_Design_Document.md)

## 打开工程

1. 安装 Unity **2022.3.34f1**（见 `Rotate_the_Fate/ProjectSettings/ProjectVersion.txt`）。
2. 在 Unity Hub 里选择 `Rotate_the_Fate/` 目录打开。
3. 最终关卡在 `Assets/Scenes/Final/`（`B0` → `F1` … `F9`）。

## 代码结构（`Rotate_the_Fate/Assets/Scripts/`）

| 目录 | 内容 |
|---|---|
| `Cupid/` | 主角：移动、跳跃、攻击、血量 |
| `Magic/` | 魔法：火焰、冰冻、闪电链、时间 |
| `TimeManager/` | 时停系统 |
| `World/` | 世界旋转（核心机制） |
| `NewEnemySystem/` | 敌人状态机（蝙蝠、蘑菇、骷髅），新敌人都写在这里 |
| `Enemy/` | 仍在使用的旧敌人脚本：`BatHealth`、`EnemyMaster`、Boss（SlimeDemon、Twinsnap）、Bush |
| `Cameras/`、`Minimap/` | 相机切换、小地图 |
| `UI/`、`Start-up/`、`Loading/` | 血条、技能 UI、开始界面、加载 |

## 协作规则

1. `main` 永远是能运行的版本，不直接推送。
2. 新功能从 `main` 拉分支：`feature/<名字>-<功能>`，例如 `feature/leo-bat-timestop`。
3. 通过 Pull Request 合并，至少一人看过；合并后删除分支。
4. 同一个场景（`.unity`）同一时间只让一个人改，改之前在群里说一声。
5. 提交信息写清楚做了什么，例如 `feat: 蝙蝠时停动画`、`fix: 蘑菇飞出地图`。
