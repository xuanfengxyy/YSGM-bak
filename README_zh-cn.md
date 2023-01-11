[EN](README.md) | [简中](README_zh-CN.md) 

# YSGM

某动漫游戏的CLI管理工具

## 设置
编辑包含在 MUIP 服务器 IP 和服务器 SSH 凭据中的配置文件。
![image](https://user-images.githubusercontent.com/27217031/199267587-c7d1f8ed-535e-49e6-ae63-ef8c16a46086.png)

如果你只使用 GM / MUIP 相关命令，则不需要 SSH 凭据。

## 指令

### shell
```html
> shell cat gameserver/conf/gameserver.xml | grep GmTalk
    <GmTalk open="true" />
```

### sql
```html
> sql hk4e_db_user_32live select * from t_player_data_0;

<row>
    <field name="uid">10000</field>
    <field name="nickname">Aqua</field>
    <field name="level">56</field>
    <field name="exp">8160</field>
    <field name="vip_point">0</field>
    <field name="json_data">{ "is_proficient_player": true}</field>
    <field name="bin_data">0x...</field>
    <field name="extra_bin_data">0x...</field>
    <field name="data_version">887</field>
    <field name="tag_list"></field>
    <field name="create_time">2022-10-26 12:25:05</field>
    <field name="last_save_time">2022-10-31 22:47:35</field>
    <field name="is_delete">0</field>
    <field name="reserved_1">0</field>
    <field name="reserved_2">0</field>
    <field name="before_login_bin_data">0x...</field>
</row>
```

### gm
在指定的 UID 上执行 GM 命令
```jsonc
// gm <uid> <cmd>
> gm 10000 KILL SELF
{"data":{"msg":"KILL SELF","retmsg":"KILL SELF"},"msg":"succ","retcode":0,"ticket":"YSGM@1667316780"}
```

### 邮件
向玩家发送邮件。使用[这个网站](https://memetrolls.net/miniprojects/mailparser/) 解析输出。
```
用法: mail <output>
```

### muip
创建你自己的自定义 MUIP 查询
```
用法: muip <cmd_id> [key=value,key2=value2]
```

### 拉取
从数据库中拉取玩家数据并保存它
```
用法: pull <uid>
```

### 推送
将玩家数据推送到数据库
```
用法: push <uid>
```
